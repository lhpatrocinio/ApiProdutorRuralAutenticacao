using System;
using ProdutorRuralAutenticacao.Domain.Entities.Identity;
using ProdutorRuralAutenticacao.Domain.Enum;

namespace ProdutorRuralAutenticacao.Domain.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public ContactTypeEnum IdContactType { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public UsersEntitie User { get; set; }
    }
}
