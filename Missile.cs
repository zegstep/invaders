using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Missile
    {
        public Vecteur2D position;
        public Vecteur2D vitesse;
        public int lives;
        public Bitmap image;
        public bool alive
        {
            private set;
            get;
        }

        public Missile(Vecteur2D position, Vecteur2D vitesse, int lives)
        {
            this.position = position;
            this.vitesse = vitesse;
            this.lives = lives;
            this.image = new Bitmap("../../resources/shoot1.png");
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, new Point((int)position.x, (int)position.y));
        }

        public void move()
        {
            this.position=this.position.addition(this.vitesse);
        }
    }
}
