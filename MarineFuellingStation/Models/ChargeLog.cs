﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MFS.Models
{
    /// <summary>
    /// 充值记录
    /// </summary>
    public class ChargeLog: EntityBase
    {
        /// <summary>
        /// 类型
        /// </summary>
        public ChargeType ChargeType { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public OrderPayType PayType { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public int? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        /// <summary>
        /// 标识个人充值和公司充值
        /// </summary>
        public bool IsCompany { get; set; }
    }
    public enum ChargeType
    {
        充值,
        消费
    }
}
