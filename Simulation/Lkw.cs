using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Simulation
{
    class Lkw : Fahrzeug
    {
        public Lkw(int pos_x, int pos_y, int speed, Color color, Form1 f, char pRichtung) : base(f)
        {
            position_x = pos_x;
            position_y = pos_y;
            geschwindigkeit = speed;
            farbe = color;
            richtung = pRichtung;
        }
        public override void fahren()
        {
            Fahrzeug f;
            int entfernung = 31;

            if (richtung == 'l' || richtung == 'r')
            {
                f = form.getNextFahrzeugX(this);
                if(f != null)
                    entfernung = f.position_x - this.position_x + 20;
                if (entfernung < 30)
                    geschwindigkeit = form.getNextFahrzeugX(this).geschwindigkeit;
                if (richtung == 'l')
                {
                    /*Fahrzeug closestFahrzeugUp;
                    closestFahrzeugUp = form.getFahrzeugYHigh(this);
                    Fahrzeug closestFahrzeugDown;
                    closestFahrzeugDown = form.getFahrzeugYLow(this);

                    if (closestFahrzeugDown != null && closestFahrzeugUp != null)
                    {
                        if ((this.position_y + 40) >= (closestFahrzeugUp.position_y + 20))
                            position_x -= 0 * 1; //nicht nach links bewegen
                        else*/
                            position_x -= geschwindigkeit * 1; //nach links bewegen
                    //}
                }
                else if (richtung == 'r')
                    position_x += geschwindigkeit * 1; //nach rechts bewegen
            }
            else
            {
                f = form.getNextFahrzeugY(this);
                if(f != null)
                    entfernung = f.position_y - this.position_y + 20;

                if (entfernung < 30)
                    geschwindigkeit = form.getNextFahrzeugY(this).geschwindigkeit;
                if (richtung == 'u')
                    position_y -= geschwindigkeit * 1; //nach oben bewegen (up)
                else if (richtung == 'd')
                    position_y += geschwindigkeit * 1; //nach unten bewegen (down)
            }
        }
    }
}
