using System;
using System.Collections.Generic;
using System.Text;

namespace PortfoyYonetimUygulamasi.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
    }
}
