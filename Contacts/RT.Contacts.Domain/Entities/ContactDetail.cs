using RT.Contacts.Core.Entities;

namespace RT.Contacts.Domain.Entities
{
    public class ContactDetail : IEntity
    {
        public int Id { get; set; }
        public BilgiTipi BilgiTipi { get; set; }
        public string BilgiIcerigi { get; set; }
        public int ContactUUID { get; set; }
    }

    public enum BilgiTipi
    {
        TelefonNumarasi = 1, EmailAdresi = 2, Konum = 3
    }
}