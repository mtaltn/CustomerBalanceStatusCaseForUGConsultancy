using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerBalanceStatus.Models.Entities
{
    [Table("musteri_fatura_table")]
    public class MusteriFatura
    {
        public int ID { get; set; }
        public int MUSTERI_ID { get; set; }
        public DateTime FATURA_TARIHI { get; set; }
        public decimal FATURA_TUTARI { get; set; }
        public DateTime ODEME_TARIHI { get; set; }
    }
}