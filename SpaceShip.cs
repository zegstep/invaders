using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class SpaceShip
    {
        public Vecteur2D position;
        public int lives;
        public Bitmap image;
        public SpaceShip(Vecteur2D position, int nbrevie, Bitmap image)
        {
            this.position = position;
            this.lives = nbrevie;
            this.image = image;
        }
        public bool alive
        {
            private set;
            get;
        }  

        public void Draw(Graphics g)
        {
            g.DrawImage(image, new Point((int)position.x, (int) position.y));
        }

        public void MoveRight(double deltaT)
        {
            position.x += 1;
        }
        public void MoveLeft(double deltaT)
        {
            position.x -= 1;
        }

    }
}
