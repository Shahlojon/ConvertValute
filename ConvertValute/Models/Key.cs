using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertValute.Models
{
    public class Key
    {
        public decimal money_transfer_buy_value { get; set; }
        public decimal money_transfer_trade_value { get; set; }
        public decimal non_cash_buy_value { get; set; }
        public decimal non_cash_sell_value { get; set; }
        public string id { get; set; }
        public int currency_code { get; set; }
        public decimal buy_value { get; set; }
        public decimal sell_value { get; set; }
        public decimal nbt_value { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string name { get; set; }
    }
}
