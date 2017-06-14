using System;
using System.Text;
using System.Web.Mvc;
using WebProject.BLL;
using WebProject.Model;
using WebProject.Pay;

namespace WebApi.Site.Controllers
{
    public class PayController : BaseApi
    {
        /// <summary>
        /// 微信app支付
        /// 参见：https://pay.weixin.qq.com/wiki/doc/api/app/app.php?chapter=9_1
        /// </summary>
        /// <returns></returns>
        public JsonResult WxPay(int total_fee)
        {
            var json = new JsonResult();

            var memberService = new MemberService();
            var member = memberService.GetCurrentMember();
            if (member == null || member.id <= 0)
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "用户未登录"
                };
                return json;
            }
            if (total_fee <= 0)
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "订单金额必须大于0"
                };
                return json;
            }
            var orderNo = WxPayApi.GenerateOutTradeNo();
            if (string.IsNullOrWhiteSpace(orderNo))
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "创建订单号失败"
                };
                return json;
            }
            var orderService = new OrderService();
            orderService.Add(orderNo, member.id, total_fee);

            var order = orderService.Get(orderNo);

            if (order == null || order.OrderFee <= 0)
            {
                json.Data = new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "创建订单号失败"
                };
                return json;
            }
            var xml = this.UnifiedOrder(order.OrderNo, order.OrderFee).ToXml();
            json.Data = new Result<dynamic>()
            {
                Code = ResultCode.Success,
                Message = "请求微信APP支付接口成功",
                Data = new { OrderNo = order.OrderNo, Xml = xml }
            };
            return json;
        }

        /// <summary>
        /// 支付回调
        /// </summary>
        /// <returns></returns>
        public ContentResult WxNotify()
        {
            //接收从微信后台POST过来的数据
            System.IO.Stream s = Request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            s.Flush();
            s.Close();
            s.Dispose();

            //转换数据格式并验证签名
            WxPayData notifyData = new WxPayData();
            WxPayData res = new WxPayData();
            try
            {
                notifyData.FromXml(builder.ToString());
            }
            catch (WxPayException ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", ex.Message);
                return Content(res.ToXml());
            }

            //检查支付结果中transaction_id是否存在
            if (!notifyData.IsSet("transaction_id"))
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                return Content(res.ToXml());
            }

            string transaction_id = notifyData.GetValue("transaction_id").ToString();
            string out_trade_no = notifyData.GetValue("out_trade_no").ToString();


            //查询订单，判断订单真实性
            if (!QueryOrder(transaction_id))
            {
                //若订单查询失败，则立即返回结果给微信支付后台
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "订单查询失败");
            }
            //查询订单成功
            else
            {
                var orderService = new OrderService();
                var result = orderService.Complete(out_trade_no);
                if (result.Code == ResultCode.Error)
                {
                    res.SetValue("return_code", "FAIL");
                    res.SetValue("return_msg", "订单查询失败");
                }
                else
                {
                    res.SetValue("return_code", "SUCCESS");
                    res.SetValue("return_msg", "OK");
                }
            }
            return Content(res.ToXml());
        }

        private WxPayData UnifiedOrder(string order_no, int total_fee)
        {
            WxPayData data = new WxPayData();
            data.SetValue("body", "趣赞平台充值");//商品描述
            data.SetValue("attach", "");//附加数据
            data.SetValue("out_trade_no", order_no);//随机字符串
            data.SetValue("total_fee", 1);//总金额
            data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));//交易起始时间
            data.SetValue("time_expire", DateTime.Now.AddMinutes(30).ToString("yyyyMMddHHmmss"));//交易结束时间
            data.SetValue("goods_tag", "");//商品标记
            data.SetValue("trade_type", "APP");//交易类型
            return WxPayApi.UnifiedOrder(data);//调用统一下单接口
        }

        private bool QueryOrder(string transaction_id)
        {
            WxPayData req = new WxPayData();
            req.SetValue("transaction_id", transaction_id);
            WxPayData res = WxPayApi.OrderQuery(req);
            if (res.GetValue("return_code").ToString() == "SUCCESS" &&
                res.GetValue("result_code").ToString() == "SUCCESS")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}