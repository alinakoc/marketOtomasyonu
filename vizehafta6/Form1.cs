using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //txt dosyasını grid wiew'ın görmesi için ayarladık (IO input output demek)

namespace vizehafta6
{
    public partial class Form1 : Form
    {
        Market market = new Market(); //eğer nesneyi burada tanımlarsak bu nesneden sadece bir kere ve program başlarken kullanılacak demek
        public Form1()
        {
            InitializeComponent();
            // dataGridView1.DataSource = null;//refresh yapmış oluyoruz(mevcut olan bağlantıyı ortadan kaldırıyoruz sonra tekrar datasourceyle bağlıyoruz)
            // dataGridView1.DataSource = market.urunler; //Data Grid Wiew'da market classının içinde oluşturduğumuz(listeyi hangi classta oluşturduysak) urunleri görüntülemesi için birbirilerine bağlıyoruz

            StreamReader sr = new StreamReader("./kategoriler.txt"); //burada projemizin dosyasındaki bin ve debug kısmanda oluşturduğumuz kategoriler.txt dosyasına erişiyoruz.)
            string[] kategoriler = sr.ReadToEnd().Split('\n'); //burada diyoruz ki alt satıra geçildiğini gördüğünde böl ve kategoriler dizisinin içine at
           // MessageBox.Show(kategoriler[0]); //buralarda da kategoriler dizisinin içine atananları index numarasıyla gösteriyoruz
           foreach(string s in kategoriler)
            {
                MarketKategori marketKategori = new MarketKategori();    //kategoriler dizisindeki elemeanları combobox'a ekleme
                marketKategori.Name= s;                                   //Marketkategori adında oluşturduğumuz listeye fshs önce oluştturduğumuz kategoriler dizisindeki isimleri ekledi açıklma ekledi ve combo box'a gönderdi
                marketKategori.Description=RandomString(50);
                comboBox1.Items.Add(marketKategori);


            }
            comboBox1.DisplayMember = "Name"; //burda ise market kategorilerdeki hem ad kısmı hem açıklma kısmının gözükmesi yerine sadece isim kısmının gözükmesini sağladık

        }

        private static Random random = new Random();

        public static string RandomString(int length) //uzunluk olarak bir parametre döndürüyor
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //0'dan başlarsan önce sayaç arttır sonra ata
           //1'den başlarsan önce ata sonra yaç arttır

            //ürün ekleye tıkladığımızda bir urun oluşturması gerekiyor
            //classİsmi  nesneninismi yani:: MarketUrun tipinde bir marketUurun nesnesi tanımlandı
            MarketUrun marketUrun = new MarketUrun();
            market.MaxUrunID += 1;
            marketUrun.Name = textBox1.Text; //marketUrun classından açtığımız özellikleri tasarımda koyduğumuz textbox1'e girilen text'i(yani yazıyı) almasını sağlıyoruz
            marketUrun.Kategori = comboBox1.SelectedItem.ToString();//combobox'ın seçili elemanına ulaşma //item comboboxın içindeki nesnelerden birini seçer //text:: comboboxın içindeki değiştirilebilinen yerdeki yazıyı alır gridwiewdekei kategoriye ekler
            
            //item'ı seçtiğimizde hep içindeki şeyi neye(string int vs) değiştireceğimizi yazmalıyız 

            marketUrun.Barkod = "MRKT" + marketUrun.Kategori + RandomString(5); //başında market ismi ortasında seçili kategorinin adı ve sonunda 5 tane sayı veya harf sallayabileceği bir metod oluşturduk
            marketUrun.Fiyat = Convert.ToDouble(textBox2.Text); //normalde textbox'ın içindeki değerler hep string olarak algılanır fakat biz fiyat girişi olarak double giriş yapacağımız için bu seferki texti double almasını istedik
            //biz burada marketUrun classında tuttuğumuz özellikleri kullanıcıdan alınmasını sağladık bu işlem bittii 
            market.urunler.Add(marketUrun); //burda ise biz MarketUrun diye bir list oluşturmuştuk bu listenin is urunler adında nesneleri vardı marketteki urunler listesine ekle dedik.

            //bu bağlantıyı tekrar aşağı kopyalıyoruz(bunun sebebi verileri tekrar girdikten sonra güncellemek)
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = market.urunler;
           



        }
    }
}
