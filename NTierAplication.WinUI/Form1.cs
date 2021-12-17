using NTierAplicationBLL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTierAplication.DAL;

namespace NTierAplication.WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        CategoryRepository cr = new CategoryRepository();
        
        private void buttongetir_Click(object sender, EventArgs e)
        {
            KategorileriGetir();
            Temizle();
        }
        //Birden fazla yerde kullanıyorum bu yuzden getiri metod içine yazıdm kod tekrarını azaltmak için yapıldı
        public void KategorileriGetir()
        {
            dataGridView1.DataSource = cr.SelectAll();
        }








        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonekle_Click(object sender, EventArgs e)
        {
            //Ekleme Yapıyorum
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Kategori adı boş geçilemez");
                return;
            }


            cr.Insert(new Category
            {
                CategoryName = textBox2.Text,
                Description = richTextBox1.Text

            }
                );
            KategorileriGetir();
            Temizle();

        }

        public void Temizle()
        {
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox t = (TextBox)item;
                    t.Clear();
                }
                if (item is RichTextBox)
                {
                    RichTextBox rt = (RichTextBox)item;
                    rt.Clear();
                }
            }
        }

        private void buttonsil_Click(object sender, EventArgs e)
        {
            //bunun içerisine seçili olan satırın idsini verip
            //silme işlemi yapalım

            if (dataGridView1.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value);
                cr.Delete(id);
            }
                
                
           
            KategorileriGetir();
            
        }

        private void buttonbul_Click(object sender, EventArgs e)
        {
            //kategori bul butonun içerindeyim
            //burtadi textbox a kategori ıd giriyorum ve bana o kategoriyi datagride getirsin

            int id = int.Parse(textBox1.Text);
            
            //Bir liste oluşturuyorum
            List<Category> c = new List<Category>();
            //buldugum listeyi kategori listeme eklioyrum
            c.Add(cr.SelectById(id));
            //data source olarak olsuturdugum listeyi veriyorum
            dataGridView1.DataSource = c;

            
            //  2.Yontem
        
            //dataGridView1.DataSource = cr.selectById2(id);

        }
        Category guncellenecek;
        private void buttonguncelle_Click(object sender, EventArgs e)
        {
            //update metodunu kullnarak guncelleme yapalım 
            //datagridwiev in double clickine tıklayıp textboxları dolduralım
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Kategori adı boş geçilemez");
                return;
            }
            //guncelleme işlemi bu kadar
            guncellenecek.CategoryName = textBox2.Text;
            guncellenecek.Description = richTextBox1.Text;
            cr.Update(guncellenecek);

            KategorileriGetir();
            Temizle();

        }
       
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count>0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                //id ye göre getiren metodumu çagırıp guncellenecek içini doldurdum
                guncellenecek = cr.SelectById(id);
                textBox2.Text = guncellenecek.CategoryName;
                richTextBox1.Text = guncellenecek.Description;
            }


        }
     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
