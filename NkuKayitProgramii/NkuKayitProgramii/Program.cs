using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace NkuKayitProgramii
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char sec;
            VTislemleri vt1 = new VTislemleri("Data Source=KRISIS\\SQLEXPRESS;Initial Catalog=NkuKayitProgrami;Integrated Security=True");
 do
            {
                sec = vt1.menu();
                switch (sec)
                {
                    case '1': vt1.kayitListele(); break;
                    case '2': vt1.kayitEkle(); break;
                    case '3': break;
                    case '4': break;
                    case '5': break;
                }
            } while (sec != '6');
        }

        class VTislemleri
        {
            SqlConnection bag;
            public VTislemleri(string bc)
            {
                bag = new SqlConnection(bc);
            }
            public void kayitListele()
            {
                int i;
                SqlCommand komut = new SqlCommand("SELECT * FROM Ogrenci", bag);
                DataTable tablo = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(komut);
                adp.Fill(tablo);
                Console.Clear();
                Console.SetCursorPosition(0, 0); Console.Write("NUMARA");
                Console.SetCursorPosition(15, 0); Console.Write("AD");
                Console.SetCursorPosition(35, 0); Console.Write("ADRES");
                Console.SetCursorPosition(55, 0); Console.Write("BÖLÜM");
                Console.SetCursorPosition(0, 1);
                for (i = 0; i < 75; i++) Console.Write("-");
                for (i = 0; i < tablo.Rows.Count; i++)
                {
                    Console.SetCursorPosition(0, i + 2);
                    Console.Write(tablo.Rows[i][0]);
                    Console.SetCursorPosition(15, i + 2);
                    Console.Write(tablo.Rows[i][1]);
                    Console.SetCursorPosition(35, i + 2);
                    Console.Write(tablo.Rows[i][2]);
                    Console.SetCursorPosition(55, i + 2);
                    Console.Write(tablo.Rows[i][3]);
                }
                Console.SetCursorPosition(0, i + 2);
                for (i = 0; i < 75; i++) Console.Write("-");
                Console.ReadKey();
            }
            public void kayitEkle()
            {
                int num; string ad, adres, bolum;
                Console.Clear();
                Console.Write("KAYIT EKLEME\n----------------------\n");
                Console.Write("Numara: ");
                num = int.Parse(Console.ReadLine());
                Console.Write("Ad: ");
                ad = Console.ReadLine();
                Console.Write("Adres: ");
                adres = Console.ReadLine();
                Console.Write("Bölüm: ");
                bolum = Console.ReadLine();
                string kc = "INSERT INTO Ogrenci VALUES(@n,@ad,@adr,@bol)";
                SqlCommand komut = new SqlCommand(kc, bag);
                komut.Parameters.AddWithValue("@n", num);
                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@adr", adres);
                komut.Parameters.AddWithValue("@bol", bolum);
                bag.Open(); komut.ExecuteNonQuery(); bag.Close();
                Console.Write("\nKayıt Eklendi!..");
                Console.ReadKey();
            }
            public char menu()
            {
                Console.Clear();
                Console.Write("KAYIT İŞLEMLERİ\n-----------------\n");
                Console.Write("1-Kayıt Listele\n2-Kayıt Ekle\n");
                Console.Write("3-Kayıt Arama\n4-Kayıt Güncelleme\n");
                Console.Write("5-Kayıt Silme\n6-ÇIKIŞ");
                char sec = Console.ReadKey().KeyChar;
                return sec;
            }
        }

    }
}
