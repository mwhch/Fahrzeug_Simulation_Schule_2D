using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Simulation
{
    public abstract class Fahrzeug
    {
        public int position_x, position_y;
        public int geschwindigkeit;
        public char richtung;
        public int temp_geschwindigkeit = 3;
        public List<Fahrzeug> fahrzeuge;
        public Color farbe;
        public Form1 form;
        public Fahrzeug(Form1 f) { form = f; }
        public virtual void fahren() { }
        public char abbiegen()
        {
            Random nummer;
            nummer = new Random();
            if (nummer.Next(1, 6) == 1)
            {
                return 'r';
            }
            else if (nummer.Next(1, 6) == 2)
            {
                return 'l';
            }
            else
            {
                return 'n';
            }
        }
        
    }
}
