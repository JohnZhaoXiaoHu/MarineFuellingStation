﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MFS.Models
{
    /// <summary>
    /// 销售单 Name字段为单号
    /// </summary>
    public class Order : EntityBase
    {
        public Order()
        {
            if (Payments == null)
                Payments = new List<Payment>();
        }
        public int? SalesPlanId { get; set; }
        [ForeignKey("SalesPlanId")]
        public virtual SalesPlan SalesPlan { get; set; }
        public SalesPlanType OrderType { get; set; }
        /// <summary>
        /// 船号/车号
        /// </summary>
        public string CarNo { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public int? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        /// <summary>
        /// 销售员
        /// </summary>
        public string Salesman { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal TotalMoney
        {
            get
            {
                return Math.Round(Price * Count, 2);
            }
        }
        /// <summary>
        /// 是否开票
        /// </summary>
        public bool IsInvoice { get; set; }
        /// <summary>
        /// 送货上门/自提
        /// </summary>
        public bool IsDeliver { get; set; } = true;
        /// <summary>
        /// 送货上门 运费
        /// </summary>
        public decimal DeliverMoney { get; set; } = 0;
        /// <summary>
        /// 是否打印单价
        /// </summary>
        public bool IsPrintPrice { get; set; } = true;
        /// <summary>
        /// 开票单位
        /// </summary>
        public string BillingCompany { get; set; }
        /// <summary>
        /// 开票单价
        /// </summary>
        public decimal BillingPrice { get; set; }
        /// <summary>
        /// 开票数量
        /// </summary>
        public decimal BillingCount { get; set; }
        /// <summary>
        /// 实际加油数量
        /// </summary>
        public decimal OilCount { get; set; }
        /// <summary>
        /// 实际加油数量 单位：升
        /// </summary>
        public decimal OilCountLitre { get; set; }
        /// <summary>
        /// 生产员 以'|'区分多个
        /// </summary>
        public string Worker { get; set; }
        /// <summary>
        /// 开始装油时间
        /// </summary>
        public DateTime? StartOilDateTime { get; set; }
        /// <summary>
        /// 结束装油时间
        /// </summary>
        public DateTime? EndOilDateTime { get; set; }
        /// <summary>
        /// 表1
        /// </summary>
        public decimal Instrument1 { get; set; }
        /// <summary>
        /// 表2
        /// </summary>
        public decimal Instrument2 { get; set; }
        /// <summary>
        /// 表3
        /// </summary>
        public decimal Instrument3 { get; set; }
        /// <summary>
        /// 密度
        /// </summary>
        public double Density { get; set; }
        /// <summary>
        /// 油温
        /// </summary>
        public decimal OilTemperature { get; set; }
        /// <summary>
        /// 实际与订单差
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal DiffOil
        {
            get
            {
                return OilCount - Count;
            }
        }
        /// <summary>
        /// 皮重 陆上（空车）
        /// </summary>
        public decimal EmptyCarWeight { get; set; }
        /// <summary>
        /// 毛重 陆上(油 + 车)
        /// </summary>
        public decimal OilCarWeight { get; set; }
        /// <summary>
        /// 油重 陆上(净重)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal DiffWeight {
            get {
                return OilCarWeight - EmptyCarWeight;
            }
        }
        /// <summary>
        /// 销售超额提成：高于商品最低限价，按 差值（升） * 数量 * 0.2 或 差值（吨） * 数量 * 0.2
        /// </summary>
        public decimal SalesCommission { get; set; }
        public int? TransportOrderId { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderState State { get; set; } = OrderState.已开单;
        /// <summary>
        /// 订单支付状态
        /// </summary>
        public PayState PayState { get; set; } = PayState.未结算;
        public TicketType TicketType { get; set; }
        /// <summary>
        /// 是否运输
        /// </summary>
        public bool IsTrans { get; set; }
        /// <summary>
        /// 油车磅秤图片地址 陆上装车
        /// </summary>
        public string OilCarWeightPic { get; set; }
        /// <summary>
        /// 空车车磅秤图片地址 陆上装车
        /// </summary>
        public string EmptyCarWeightPic { get; set; }
        /// <summary>
        /// 销售仓Id 陆上装车
        /// </summary>
        public int? StoreId { get; set; }
        /// <summary>
        /// 对应油仓
        /// </summary>
        [ForeignKey("StoreId")]
        public virtual Store Store { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        /// <summary>
        /// 最低限价
        /// </summary>
        public decimal MinPrice { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 收银员
        /// </summary>
        public string Cashier { get; set; }
        /// <summary>
        /// 删单原因
        /// </summary>
        public string DelReason { get; set; }
        

    }
    public enum OrderState
    {
        已开单,
        选择油仓,
        空车过磅,
        装油中,
        油车过磅,
        已完成
    }
    public enum PayState
    {
        未结算,
        已结算,
        挂账
    }
    public enum OrderPayType
    {
        现金,
        微信,
        支付宝,
        桂行刷卡,
        工行刷卡,
        刷卡三,
        账户扣减,
        公司账户扣减
    }
}
