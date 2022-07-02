using RT.Contacts.Core.Entities;

namespace RT.Contacts.Domain.Entities
{
    public class Contact : IEntity
    {
        public int UUID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string? Firma { get; set; }
        public virtual ICollection<ContactDetail>? IletisimBilgileri { get; set; }
    }
}
