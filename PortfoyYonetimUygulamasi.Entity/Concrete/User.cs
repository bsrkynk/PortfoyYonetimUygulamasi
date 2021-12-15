using System;
using System.Collections.Generic;
using System.Text;
using PortfoyYonetimUygulamasi.Shared.Entities.Abstract;

namespace PortfoyYonetimUygulamasi.Entity.Concrete
{
    public class User: EntityBase,IEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string UserPassword { get; set; }
        public ICollection<Portfolio> Portfolios { get; set; }
    }
}
