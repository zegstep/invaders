using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Vecteur2D
    {
        //private double norme;
        public double x;
        public double y;
       
        public Vecteur2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double Norme
        {
            get
            {
                return Math.Sqrt(x * x + y * y);
            }
            private set{ }
        }

        public Vecteur2D addition (Vecteur2D v)
        {
            return new Vecteur2D(this.x + v.x, this.y + v.y);
        }

        public Vecteur2D soustraction(Vecteur2D v)
        {
            return new Vecteur2D(this.x - v.x, this.y - v.y);
        }

        public Vecteur2D multiplication (Vecteur2D v)
        {
            return new Vecteur2D(this.x * v.x, this.y * v.y);
        }

        public Vecteur2D moinsunitaire ()
        {
            return new Vecteur2D(-this.x, -this.y);
        }
    }
}
