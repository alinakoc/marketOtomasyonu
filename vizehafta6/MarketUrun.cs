using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vizehafta6
{
    public class MarketUrun
    { 
        // classta yazdığım bütün özelliklere erişimini sağlamak istersem c# bunlara erişim sağlamak isterken get ve setleri arar
        public int ID { get; set; }//get üstüne yazar set mevcut olanı okur

        public string Name { get; set; }

        public string Kategori { get; set; }

        public string Barkod { get; set; }

        public double Fiyat { get; set; }//doubleda noktadan sonra iki tane sayı gösterir 
    }
}

// biz datagridwiew'e senin veri kaynağın marketteki ürünler demiştik o da market class'ının içerisine baktı 
//ve orada market urun tipinde bi liste olduğunu gördü bu sefer bu market urununun içindeki urunlerin özelliklerine erişebilmek için 
//marketUrun classının içine geldi ama buradaki proplara getter setter kullanılmadığı için erişmedi bu yüzden datagridwiewda ürünleri göremedik
