using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vizehafta6
{
    public class Market
    {
        internal int MaxUrunID = 0;
        //urunler listesini tanımladı      urunler listesini oluşturdu
        public List<MarketUrun> urunler = new List<MarketUrun>() ;
        public List<MarketKategori> urunKategori = new List<MarketKategori>() ; //kategorileri tutacak bir liste oluşturduk
    }
}
