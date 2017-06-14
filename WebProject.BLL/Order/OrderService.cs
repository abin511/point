using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebProject.DAL;
using WebProject.Model;

namespace WebProject.BLL
{
    public class OrderService
    {
        public OrderModel Get(string orderNo)
        {
            return OrderRepository.Get(orderNo);
        }
        public Result<dynamic> Add(string orderNo, int memberId, int orderFee)
        {
            try
            {
                OrderRepository.Add(new OrderModel()
                {
                    OrderNo = orderNo,
                    MemberId = memberId,
                    OrderFee = orderFee,
                    OrderStatus = 0,
                    NotifyTime = DateTime.Now,
                    CreateTime = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "生成订单失败"
                };
            }
            return new Result<dynamic>()
            {
                Code = ResultCode.Success,
                Message = "生成订单成功"
            };
        }

        public Result<dynamic> Complete(string orderNo)
        {
            var order = OrderRepository.Get(orderNo);
            if (order == null)
            {
                return new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "订单不存在"
                };
            }
            if (order.OrderStatus == 1)
            {
                return new Result<dynamic>()
                {
                    Code = ResultCode.Success,
                    Message = "订单状态更新成功"
                };
            }
            order.OrderStatus = 1;
            order.NotifyTime = DateTime.Now;
            if (!OrderRepository.Update(order))
            {
                return new Result<dynamic>()
                {
                    Code = ResultCode.Error,
                    Message = "订单状态更新失败"
                };
            }
            try
            {
                var memberService = new MemberService();
                memberService.UpdateUserBalance(order.MemberId, order.OrderFee);
            }
            catch { }
            return new Result<dynamic>()
            {
                Code = ResultCode.Success,
                Message = "订单状态更新成功"
            };
        }
    }
}
