using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerBalanceStatus.Models.Entities
{
    [Table("musteri_tanim_table")]
    public class MusteriTanim
    {
        public int ID { get; set; }
        public string UNVAN { get; set; }
    }
}