using System;
using System.Collections.Generic;
using System.Text;
using PortfoyYonetimUygulamasi.Shared.Entities.Abstract;

namespace PortfoyYonetimUygulamasi.Entity.Concrete
{
    public class TransactionType:EntityBase,IEntity
    {
        /// <summary>
        /// işlem tipini belirtir. Alış, satış, transfer
        /// </summary>
        public string TransactionTypeName { get; set; }
        public Transaction Transaction {get; set; }
    }
}
