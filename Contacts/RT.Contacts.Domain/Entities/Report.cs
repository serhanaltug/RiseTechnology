using RT.Contacts.Core.Entities;

namespace RT.Contacts.Domain.Entities
{
    public class Report : IEntity
    {
        public int UUID { get; set; }
        public string Konum { get; set; }
        public int? KayitliKisiSayisi { get; set; }
        public int? KayitliTelefonNumarasiSayisi { get; set; }
        public DateTime RaporTarihi { get; set; } = DateTime.UtcNow;   
        public int RaporDurumu { get; set; } = 0;    
    }
}
