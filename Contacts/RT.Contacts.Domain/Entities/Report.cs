using RT.Contacts.Core.Entities;

namespace RT.Contacts.Domain.Entities
{
    public class Report : IEntity
    {
        public int UUID { get; set; }
        public string Konum { get; set; }
        public int? KayitliKisiSayisi { get; set; }
        public int? KayitliTelefonNumarasiSayisi { get; set; }
        public DateTime RaporTarihi { get; set; } = DateTime.Now;   
        public int RaporDurumu { get; set; } = 0;    
    }
}
