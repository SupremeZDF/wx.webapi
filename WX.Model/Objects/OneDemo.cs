using System;
using System.Collections.Generic;
using System.Text;

namespace WX.Model.Objects
{
    public class OneDemo
    {
        /// <summary>
        /// 业务ID
        /// </summary>
        public int? FIndexID { get; set; }

        /// <summary>
        /// 业务类型 默认4 银行贷款
        /// </summary>
        public int businesstype { get; set; }

        /// <summary>
        /// 征信ID
        /// </summary>
        public int creditid { get; set; }

        /// <summary>
        /// 授权ID
        /// </summary>
        public int authorizeid { get; set; }

        /// <summary>
        /// 汇融订单号(业务关联)
        /// </summary>
        public string orderNo { get; set; }

        /// <summary>
        /// e分期方订单号
        /// </summary>
        public string estageOrderNo { get; set; }

        /// <summary>
        /// 实名认证状态
        /// </summary>
        public int authenticationstatus { get; set; }

        /// <summary>
        /// 业务数据json
        /// </summary>
        public string data { get; set; }
    }
}
