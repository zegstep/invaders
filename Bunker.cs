using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Bunker
    {
        public Vecteur2D position;
        public int vie;
        public Bitmap image;
        //public bool collision;
        public Bunker(Vecteur2D position)
        {
            this.vie = 5;
            this.position = position;
            this.image = new Bitmap("../../resources/bunker.png");
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, new Point((int)position.x, (int)position.y));
        }

        public bool collision(double x, double y)
        {
            if((this.position.x< x)&&(x<(this.position.x+this.image.Width))&&(this.position.y< y)&&(y<(this.position.y+this.image.Height)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // if (rect1.x < rect2.x + rect2.width &&
        //    rect1.x + rect1.width > rect2.x &&
        //    rect1.y < rect2.y + rect2.height &&
        //    rect1.height + rect1.y > rect2.y)
        // {
        // collision détectée !
        // }
        //if(playerMissile.position.x<bu)
    }
}
