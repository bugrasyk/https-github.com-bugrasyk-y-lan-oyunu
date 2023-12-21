using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yılan_oyunu
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
            

        private void label1_Click(object sender, EventArgs e)
        {
            label2.Text = "0";

            parca = new Panel();
            parca.Location = new Point(200, 200);
            parca.Size = new Size(20, 20);
            parca.BackColor = Color.Gray;
            yilan.Add(parca);
            panel1.Controls.Add(yilan[0]);

            timer1.Start();
            elmaOlustur();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int locX = yilan[0].Location.X;
            int locY = yilan[0].Location.Y;

            elmaYedimmi();


            if(yon == "sağ")
            {
                if (locX < 580)
                    locX += 20;
                else
                    locX = 0;
            }
            if (yon == "sol")
            {
                if (locX > 0)
                    locX -= 20;
                else
                    locX = 580;
            }
            if (yon == "aşağı")
            {
                if (locY < 580)
                    locY += 20;
                else
                    locY = 0;
            }
            if (yon == "yukarı")
            {
                if (locY > 0)
                    locY -= 20;
                else
                    locY = 580;
            }
            yilan[0].Location = new Point(locX, locY);
        }

        private void Form1_(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                yon = "sağ";
            if (e.KeyCode == Keys.Left)
                yon = "sol";
            if (e.KeyCode == Keys.Down)
                yon = "aşağı";
            if (e.KeyCode == Keys.Up)
                yon = "yukarı";
        }
        
        void elmaOlustur()
        {
            Random rnd = new Random();
            int elmaX, elmaY;
            elmaX = rnd.Next(580);
            elmaY = rnd.Next(580);

            elmaX -= elmaX % 20;
            elmaX -= elmaY % 20;

            elma.Size = new Size(20,20);
            elma.BackColor = Color.Red;
            elma.Location = new Point(elmaX, elmaY);
            panel1.Controls.Add(elma);
        }
        void elmaYedimmi()
        {
            int puan = int.Parse(label2.Text);
            if (yilan[0].Location == elma.Location)
            {
                panel1.Controls.Remove(elma);
                puan += 50;
                label2.Text = puan.ToString();
                elmaOlustur();
            }
        }
    }

    }

