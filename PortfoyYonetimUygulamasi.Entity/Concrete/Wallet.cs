using System;
using System.Collections.Generic;
using System.Text;
using PortfoyYonetimUygulamasi.Shared.Entities.Abstract;

namespace PortfoyYonetimUygulamasi.Entity.Concrete
{
    public class Wallet: EntityBase,IEntity
    {
        /// <summary>
        ///ortalama satın alma fiyatı,her transaction tablosunda işlem olduğunda hesaplanarak geçmiş alış satışlar üzerinden hesaplanarak yazdırılır.
        /// </summary>
        public string AvarageBuyPrice { get; set; }

        /// <summary>
        /// toplam varlık, transaction tablosunda işlem olduğunda hesaplanır.
        /// </summary>
        public string TotalWealth { get; set; }
        /// <summary>
        /// toplam coin sayısı transaction tablosunda işlem olduuğnda hesaplanır. eldeki toplam coini gösterir. 
        /// </summary>
        public string AmountOfCoin { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; } //bir wallet bir portföye ait olabilir

        public ICollection<Coin> Coins { get; set; } //bir walletta çok sayıda coin olabilir.

    }
}
