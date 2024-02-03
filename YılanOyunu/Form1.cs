using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YılanOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Panel parca;
        Panel elma = new Panel();
        List<Panel> yilan = new List<Panel>();

        string yon = "sağ";

        private void FormuOrtala()
        {
            int ekranGenislik = Screen.PrimaryScreen.Bounds.Width;
            int ekranYukseklik = Screen.PrimaryScreen.Bounds.Height;

            int formGenislik = this.Width;
            int formYukseklik = this.Height;

            int x = (ekranGenislik - formGenislik) / 2;
            int y = (ekranYukseklik - formYukseklik) / 2;

            this.Location = new Point(x, y);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            label2.Text = "0";
            panelTemizle();

            parca = new Panel();
            parca.Location = new Point(200, 200);
            parca.Size = new Size(16, 16);
            parca.BackColor = Color.Gray;
            yilan.Add(parca);
            panel1.Controls.Add(yilan[0]);

            timer1.Start();
            elmaOlustur();
        }

        void carpismaKontrol() { 
            for (int i = 2; i < yilan.Count; i++)
            {
                if(yilan[0].Location == yilan[i].Location)
                {
                    label4.Visible = true;
                    label4.Text = "KAYBETTİNİZ";
                    timer1.Stop();
                }
            }
        }
        void panelTemizle()
        {
            panel1.Controls.Clear();
            yilan.Clear();
            label4.Visible = false;
        }
        void puanKontrol()
        {
            int puan = int.Parse(label2.Text);
            if(puan > 500)
            {
                label4.Text = "KAZANDINIZ";
                label4.Visible = true;
                timer1.Stop();
            }
        }
        


        private void timer1_Tick(object sender, EventArgs e)
        {
            int locX = yilan[0].Location.X;
            int locY = yilan[0].Location.Y;

            elmaYedimmi();
            hareket();
            carpismaKontrol();
            puanKontrol();

            if (yon == "sağ")
            {
                if (locX < 384)    //Panelimin genisligi 400 yılanımın genisligi 16 (400-16=384) oldugu icin 384 dedim.
                    locX += 16;
                else locX = 0;
            }
            if (yon == "sol")
            {
                if (locX > 0)    
                    locX -= 16;
                else locX = 384;
            }
            if (yon == "aşağı")
            {
                if (locY < 384)    
                    locY += 16;
                else locY = 0;
            }
            if (yon == "yukarı")
            {
                if (locY > 0)    
                    locY -= 16;
                else locY = 384;
            }

            yilan[0].Location = new Point(locX, locY);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && yon != "sol")
                yon = "sağ";
            if (e.KeyCode == Keys.Left && yon != "sağ")
                yon = "sol";
            if (e.KeyCode == Keys.Up && yon != "aşağı") 
                yon = "yukarı";
            if (e.KeyCode == Keys.Down && yon != "yukarı")
                yon = "aşağı";
        }
        

        void elmaOlustur()
        {
            Random rnd = new Random();
            int elmaX, elmaY;
            elmaX = rnd.Next(384);
            elmaY = rnd.Next(384);

            elmaX -= elmaX % 16;
            elmaY -= elmaY % 16;

            elma.Size = new Size(16, 16);
            elma.BackColor = Color.Red;
            elma.Location = new Point(elmaX, elmaY);
            panel1.Controls.Add(elma);
        }

        void elmaYedimmi()
        {
            int puan = int.Parse(label2.Text);
            if(yilan[0].Location == elma.Location)
            {
                panel1.Controls.Remove(elma);
                puan += 50;
                label2.Text = puan.ToString();
                elmaOlustur();
                parcaEkle();
            }
        }
        void parcaEkle()
        {
            Panel ekpParca = new Panel();
            ekpParca.Size = new Size(16, 16);
            ekpParca.BackColor = Color.Gray;
            yilan.Add(ekpParca);
            panel1.Controls.Add(ekpParca);
        }

        void hareket()
        {
            for (int i = yilan.Count - 1; i > 0; i--)
                yilan[i].Location = yilan[i - 1].Location;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormuOrtala();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    }

