using System;

namespace Domain.Entities
{
    public class Users : BaseEntity
    {
        public string Nome { get; set; }

        public DateTime BirthDate { get; set; }

        public string Cpf { get; set; }
    }
}
