using System;
using System.Collections.Generic;
using System.Text;

namespace WX.Model
{
    /// <summary>
    /// 中金支付服务特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class PFPaymentAttribute : System.Attribute
    {
        public PFPaymentAttribute(string xmlExplain)
        {
            XmlPayMentBodyOrHead = xmlExplain;
        }

        /// <summary>
        /// 
        /// </summary>
        public string XmlPayMentBodyOrHead { get; set; }

        /// <summary>
        /// XML保温属性名称
        /// </summary>
        public string XMLBoadName { get; set; }
    }
}
