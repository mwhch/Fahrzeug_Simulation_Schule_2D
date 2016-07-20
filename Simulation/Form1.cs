//Vertikale Fahrbahnen haben Vorfahrt, Autos können abbiegen, horizontale Fahrbahnen müssen Vorfahrt beachten
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation
{
    public partial class Form1 : Form
    {
        Graphics graph_picture_box;
        List<Fahrzeug> fahrzeugeX;
        List<Fahrzeug> fahrzeugeY;
        Random rand;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            graph_picture_box = pictureBox1.CreateGraphics();
            fahrzeugeX = new List<Fahrzeug>();
            fahrzeugeY = new List<Fahrzeug>();

            #region liste autos füllen
            /*fahrzeuge.Add(new Auto(13, 37, rand.Next(1, 5), Color.Blue));
            fahrzeuge.Add(new Auto(13, 58, 4, Color.Red));
            fahrzeuge.Add(new Auto(13, 79, 6, Color.Green));
            fahrzeuge.Add(new Lkw(13, 100, rand.Next(1, 3), Color.Black)); //Mit Ketchup
            fahrzeuge.Add(new Bus(13, 121, rand.Next(4, 8), Color.Brown));*/
            #endregion
        }

        public Fahrzeug getFahrzeugYHigh(Fahrzeug fahrzeug)
        {
            int abstand = 10000;
            Fahrzeug return_auto = null;
            foreach (Fahrzeug a in fahrzeugeY)
            {
                if (a != null)
                {
                    int abstand_new = fahrzeug.position_y - a.position_y;
                    if (abstand > abstand_new && abstand_new > 0)
                    {
                        abstand = abstand_new;
                        return_auto = a;
                    }
                }
            }
            return return_auto;
        }

        public Fahrzeug getFahrzeugYLow(Fahrzeug fahrzeug)
        {
            int abstand = 10000;
            Fahrzeug return_auto = null;
            foreach (Fahrzeug a in fahrzeugeY)
            {
                if (a != null && a != fahrzeug)
                {
                    int abstand_new = a.position_y - fahrzeug.position_y;
                    if (abstand > abstand_new && abstand_new > 0)
                    {
                        abstand = abstand_new;
                        return_auto = a;
                    }
                }
            }
            return return_auto;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Fahrzeug f in fahrzeugeX)        //Fahrzeug bewegt sich
            {
                f.fahren();
            }
            foreach(Fahrzeug g in fahrzeugeY)
            {
                g.fahren();
            }
            Rectangle gras;
            Rectangle horizontale_strasse;
            Rectangle vertikale_strasse;
            SolidBrush bGras; //wird zum Füllen benötigt
            SolidBrush bHorizontale_strasse;
            SolidBrush bVertikale_strasse;
            gras = new Rectangle(0, 0 , 567, 317);
            horizontale_strasse = new Rectangle(0, 120, 567, 62);
            vertikale_strasse = new Rectangle(202, 0, 62, 317);
            bGras = new SolidBrush(Color.Green);
            bGras.Equals(gras);
            bHorizontale_strasse = new SolidBrush(Color.LightSlateGray);
            bHorizontale_strasse.Equals(horizontale_strasse);
            bVertikale_strasse = new SolidBrush(Color.LightSlateGray);
            bVertikale_strasse.Equals(vertikale_strasse);
            graph_picture_box.Clear(Color.WhiteSmoke);           //Fenster wird #gesäubert #Türkiye
            graph_picture_box.DrawRectangle(new Pen(Color.LawnGreen), gras);
            graph_picture_box.FillRectangle(bGras, gras);
            graph_picture_box.DrawRectangle(new Pen(Color.LightSlateGray), horizontale_strasse); //horizontale Straße
            graph_picture_box.FillRectangle(bHorizontale_strasse, horizontale_strasse);
            graph_picture_box.DrawRectangle(new Pen(Color.LightSlateGray), vertikale_strasse); //vertikale Straße
            graph_picture_box.FillRectangle(bVertikale_strasse, vertikale_strasse);
            foreach (Fahrzeug f in fahrzeugeX)        //Fahrzeuge werden gezeichnet
            {
                graph_picture_box.DrawRectangle(new Pen(f.farbe), f.position_x, f.position_y, 20, 20);
            }
            foreach(Fahrzeug g in fahrzeugeY)
            {
                graph_picture_box.DrawRectangle(new Pen(g.farbe), g.position_x, g.position_y, 20, 20);
            }
        }

        private void spawn_fahrzeug()
        {
            Random rand;
            rand = new Random();

            fahrzeugeY.Add(new Auto(237, 250, rand.Next(1,10), Color.Blue, this, 'u'));
            fahrzeugeY.Add(new Auto(209, 13, rand.Next(1, 10), Color.Blue, this, 'd'));
            fahrzeugeX.Add(new Auto(400, 127, rand.Next(1,5), Color.Blue, this, 'l'));
            fahrzeugeX.Add(new Auto(13, 155, 4, Color.Blue, this, 'r'));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //spawn_fahrzeug();
        }

        public Fahrzeug getNextFahrzeugX(Fahrzeug aktuell)
        {
            int abstand = 10000;
            Fahrzeug temp_fahrzeug = null;
            int entfernung;
            foreach (Fahrzeug f in fahrzeugeX)
            {
                if (aktuell != f)
                {
                    entfernung = f.position_x - aktuell.position_x + 20;
                    if (abstand > entfernung && entfernung > 0)
                    {
                        abstand = entfernung;
                        temp_fahrzeug = f;
                    }
                }
            }
            return temp_fahrzeug;
        }

        public Fahrzeug getNextFahrzeugYdown(Fahrzeug aktuell)
        {
            int abstand = 10000;
            Fahrzeug temp_fahrzeug = null;
            int entfernung;
            foreach (Fahrzeug f in fahrzeugeY)
            {
                if (aktuell != f)
                {
                    entfernung = f.position_y - aktuell.position_y + 20;

                    if (abstand > entfernung && entfernung > 0)
                    {
                        abstand = entfernung;
                        temp_fahrzeug = f;
                    }
                }
            }
            return temp_fahrzeug;
        }

        public Fahrzeug getNextFahrzeugYup(Fahrzeug aktuell)
        {
            int abstand = 10000;
            Fahrzeug temp_fahrzeug = null;
            int entfernung;
            foreach (Fahrzeug f in fahrzeugeY)
            {
                if (aktuell != f)
                {
                    entfernung = aktuell.position_y - f.position_y;

                    if (abstand > entfernung && entfernung > 0)
                    {
                        abstand = entfernung;
                        temp_fahrzeug = f;
                    }
                }
            }
            return temp_fahrzeug;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            spawn_fahrzeug();
        }
    }
}