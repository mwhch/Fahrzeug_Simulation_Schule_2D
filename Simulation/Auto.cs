using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Simulation
{
    public class Auto : Fahrzeug
    {
        public Auto(int pos_x, int pos_y, int speed, Color color, Form1 f, char pRichtung) : base(f)
        {
            position_x = pos_x;
            position_y = pos_y;
            geschwindigkeit = speed;
            farbe = color;
            richtung = pRichtung;
            temp_geschwindigkeit = geschwindigkeit;
        }

        public override void fahren()
        {
            Fahrzeug f;
            int entfernung = 10000;
            if (richtung == 'l')
            {
                int distanceUp = 10000;
                int distanceDown = 10000;
                Fahrzeug closestFahrzeugUp;
                closestFahrzeugUp = form.getFahrzeugYHigh(this);
                Fahrzeug closestFahrzeugDown;
                closestFahrzeugDown = form.getFahrzeugYLow(this);
                int closestFahrzeugUppositionX = 10000;
                int closestFahrzeugDownpositionX = 10000;
                if (closestFahrzeugUp != null)
                {
                    distanceUp = this.position_y - closestFahrzeugUp.position_y + 20;
                    closestFahrzeugUppositionX = closestFahrzeugUp.position_x;
                }
                else
                {
                    closestFahrzeugUppositionX = 10000;
                    distanceUp = 10000;
                }
                if (closestFahrzeugDown != null)
                {
                    distanceDown = this.position_y - closestFahrzeugDown.position_y - 20;
                    closestFahrzeugDownpositionX = closestFahrzeugDown.position_x;
                }
                else
                {
                    closestFahrzeugDownpositionX = 10000;
                    distanceDown = 10000;
                }


                if (((distanceUp < 100 && distanceUp > 0 && distanceUp != 10000 )&& (closestFahrzeugUppositionX < (this.position_x - 20))) || ((distanceDown < 100 && distanceDown > 0 && distanceDown != 10000) && (closestFahrzeugDownpositionX < (this.position_x - 20))))
                {
                    //temp_geschwindigkeit = geschwindigkeit;
                    geschwindigkeit = 0;
                }
                else
                {
                    f = form.getNextFahrzeugX(this);
                    if (f != null)
                    {
                        entfernung = f.position_x - this.position_x;
                    }
                    if (entfernung < 30)
                    {
                       geschwindigkeit = form.getNextFahrzeugX(this).geschwindigkeit;
                    }
                    else
                    {
                        geschwindigkeit = temp_geschwindigkeit;
                    }
                }
                position_x -= geschwindigkeit * 1; //nach links bewegen
            }
            if (richtung == 'r')
            {
                int distanceUp = 10000;
                int distanceDown = 10000;
                Fahrzeug closestFahrzeugUp;
                closestFahrzeugUp = form.getFahrzeugYHigh(this);
                Fahrzeug closestFahrzeugDown;
                closestFahrzeugDown = form.getFahrzeugYLow(this);
                int closestFahrzeugUppositionX = 10000;
                int closestFahrzeugDownpositionX = 10000;
                if (closestFahrzeugUp != null)
                {
                    distanceUp = this.position_y - closestFahrzeugUp.position_y + 20;
                    closestFahrzeugUppositionX = closestFahrzeugUp.position_x;
                }
                else
                {
                    closestFahrzeugUppositionX = 10000;
                    distanceUp = 10000;
                }
                if (closestFahrzeugDown != null)
                {
                    distanceDown = this.position_y - closestFahrzeugDown.position_y - 20;
                    closestFahrzeugDownpositionX = closestFahrzeugDown.position_x;
                }
                else
                {
                    closestFahrzeugDownpositionX = 10000;
                    distanceDown = 10000;
                }


                if (((distanceUp < 70 && distanceUp > 0 && distanceUp != 10000) && (closestFahrzeugUppositionX > (this.position_x))) || ((distanceDown > -100 && distanceDown < 0 && distanceDown != 10000) && (closestFahrzeugDownpositionX > (this.position_x - 20))))
                {
                    //temp_geschwindigkeit = geschwindigkeit;
                    geschwindigkeit = 0;
                }
                else
                {
                    f = form.getNextFahrzeugX(this);
                    if (f != null)
                    {
                        entfernung = f.position_x - this.position_x;
                    }
                    if (entfernung < 30)
                    {
                        geschwindigkeit = form.getNextFahrzeugX(this).geschwindigkeit;
                    }
                    else
                    {
                        geschwindigkeit = temp_geschwindigkeit;
                    }
                }

                position_x += geschwindigkeit * 1; //nach unten bewegen (down)

            }
            //Drive if Richtung is up
            if (richtung == 'u')
            {
                f = form.getNextFahrzeugYup(this);
                if (f != null)
                {
                    entfernung = this.position_y - (f.position_y);
                }
                if (entfernung < 30)
                {
                    geschwindigkeit = form.getNextFahrzeugYup(this).geschwindigkeit;
                }
                position_y -= geschwindigkeit * 1; //nach oben bewegen (up)
            }

            //Drive if Richtung is down
            if (richtung == 'd')
            {
                f = form.getNextFahrzeugYdown(this);
                if (f != null)
                {
                    entfernung = f.position_y - this.position_y - 20;
                }
                if (entfernung < 30)
                {
                    geschwindigkeit = form.getNextFahrzeugYdown(this).geschwindigkeit;
                }
                position_y += geschwindigkeit * 1; //nach unten bewegen (down)

            }
        }

    }
}
