using System;
using System.Runtime.Serialization;

namespace WebProject.Model
{
    /// <summary>
    /// 实体包装类
    /// </summary>
    [DataContract]
    public class Result<T> //where T : new()
    {
        #region 构造方法
        public Result()
        {
            Message = null;
            Code = ResultCode.Error;
            //Data = nul;
        }
        public Result(T content)
        {
            Message = null;
            Code = ResultCode.Error;
            Data = content;
        }
        public Result(string message, ResultCode code, T content)
        {
            Message = message;
            Code = code;
            Data = content;
        }
        #endregion
        /// <summary>
        /// 返回消息
        /// </summary>
        [DataMember]
        public string Message { get; set; }
        /// <summary>
        /// 返回代码 
        /// </summary>
        [DataMember]
        public ResultCode Code { get; set; }
        /// <summary>
        /// 实体内容
        /// </summary>
        [DataMember]
        public T Data { get; set; }
    }

    [Serializable]
    public class KeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}
