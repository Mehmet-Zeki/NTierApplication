using NTierAplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierAplicationBLL.Repository
{
   public class CategoryRepository
    {
       
        // Ekleme 
        // Silme
        // Guncelleme
        // Listeleme
        // id ye göre bilgi getirme
        //gibi işlemler burada olacak

        NorthwindEntities db = new NorthwindEntities();

        //Categorilere bir ürün eklemek isteseydik ?

        //bir metod açılması gerekiyor
        //Kategori ekle
        public void Insert(Category item)
        {
            db.Categories.Add(item);
            db.SaveChanges();
        }
        // silme
        // id buluyoruz,silme işlemi hep id uzerinden olucak
        public void Delete(int itemid)
        {
            Category silinen = db.Categories.Find(itemid);
            db.Categories.Remove(silinen);
            db.SaveChanges();
        }

        //update 
        //Categorilere göre de yapabiliriz
        /*
         Delete il Update her iki metoduda yapabilir yani Delete metdonu update te yaptıgımız gibi Category item deye id bulup siliebilir

        */

        public void Update(Category item)
        {
            Category guncellenen = db.Categories.Find(item.CategoryID);

          //  once guncellenecek elemanı al,sonra gecerli veri ile yeni veriyi degiştir
            db.Entry(guncellenen).CurrentValues.SetValues(item);
            db.SaveChanges();
        }

        //Tüm kategorilerimi getir metodum
        //Tüm veriler benim için buyuk bir liste olarak geliyor
        //buna geri donuslü bir metod yapmak istedigim için list tipinde tutup geriye liste donduruyorum
        //butonun altında çagırırken to list yapmama gerek kalmıyor.

        public List<Category> SelectAll()
        {
            return db.Categories.ToList();
        }


        public Category SelectById(int itemid)
        {
            return db.Categories.Find(itemid);
            db.SaveChanges();
        }
     
        public List<Category> selectById2(int item)
        {
            return db.Categories.Where(p => p.CategoryID == item).ToList();
        }
    }
}
