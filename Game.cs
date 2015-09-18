using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class Game
    {
        public SpaceShip playerShip;
        private double playerSpeed;
        public Missile playerMissile;
        public EnemyBlock enemyBlock;
        List<Bunker> bunkers ;
        List<Bunker> bunkertoremove;
        public Bunker bunker;
        //public Bunker bunkers2;
        //public Bunker bunkers3;
        #region fields and properties

        #region gameplay elements
        /// <summary>
        /// A dummy object just for demonstration
        /// </summary>
        //BalleQuiTombe ball = null;
        #endregion

        #region game technical elements
        /// <summary>
        /// Size of the game area
        /// </summary>
        public Size gameSize;

        /// <summary>
        /// State of the keyboard
        /// </summary>
        public HashSet<Keys> keyPressed = new HashSet<Keys>();

        #endregion

        #region static fields (helpers)

        /// <summary>
        /// Singleton for easy access
        /// </summary>
        public static Game game { get; private set; }

        /// <summary>
        /// A shared black brush
        /// </summary>
        private static Brush blackBrush = new SolidBrush(Color.Black);

        /// <summary>
        /// A shared simple font
        /// </summary>
        private static Font defaultFont = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel);
        #endregion

        #endregion

        #region constructors
        /// <summary>
        /// Singleton constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        /// 
        /// <returns></returns>
        public static Game CreateGame(Size gameSize)
        {
            if (game == null)
                game = new Game(gameSize);
            return game;
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        private Game(Size gameSize)
        {
            Bitmap imageShip = new Bitmap("../../Resources/Ship4.png");
            playerShip = new SpaceShip(new Vecteur2D(gameSize.Width / 2-30, gameSize.Height-35), 5, imageShip);
            bunkers = new List<Bunker>();
            for(int i=0;i<3;i++)
            {
                bunker = new Bunker(new Vecteur2D(i * 250, gameSize.Height - 150));
                bunkers.Add(bunker);
            }
            this.gameSize = gameSize;
        }

        #endregion

        #region methods

        /// <summary>
        /// Draw the whole game
        /// </summary>
        /// <param name="g">Graphics to draw in</param>
        public void Draw(Graphics g)
        {
            bunkers.ForEach(delegate(Bunker bunker)
            {
                bunker.Draw(g);
            });

            playerShip.Draw(g);
            if (playerMissile != null)
            {
                playerMissile.Draw(g);
               // g.DrawString("Une balle qui tombe !", defaultFont, blackBrush, 30, 30);
               // ball.Draw(g);
            }
            else
            {
                //g.DrawString("Appuyez sur espace !", defaultFont, blackBrush, 30, 30);
            }
        }

        /// <summary>
        /// Update game
        /// </summary>
        public void Update(double deltaT)
        {
           
            // keyboard events
            if (keyPressed.Contains(Keys.Space))
            {
                if (playerMissile == null)
                {
                    playerMissile = new Missile(new Vecteur2D(playerShip.position.x + 30, playerShip.position.y + 50), new Vecteur2D(0, -5), 1);
                }
            }
            if (playerMissile != null)
            {
                if (playerMissile.position.y > 0)
                {
                    playerMissile.move();
                    bunkers.ForEach(delegate (Bunker bunker)
                    {
                        if (bunker.collision(playerMissile.position.x, playerMissile.position.y))
                        {
                            playerMissile.lives--;
                            bunker.vie--;
                            Console.WriteLine("--> vie --> " + bunker.vie);
                            if (bunker.vie == 0)
                            {
                                bunkers.Remove(bunker);
                               
                                bunker = null;
                            }
                        }
                    });

                    if (playerMissile.lives == 0)
                    {
                        playerMissile = null;
                    }
                }
                else
                {
                    playerMissile = null;
                }
            }
            if (keyPressed.Contains(Keys.Right))
            {
                if (playerShip.position.x < gameSize.Width - 65)
                {
                    playerShip.MoveRight(deltaT);
                }
                //if (ball != null)
                // {
                // ball.MoveRight(deltaT);
                // if (!ball.Alive)
                // ball = null;
                // }
            }
            if (keyPressed.Contains(Keys.Left))
            {
                if (playerShip.position.x > 0)
                {
                    playerShip.MoveLeft(deltaT);
                }
                // if (ball != null)
                // {
                // ball.MoveLeft(deltaT);
                // if (!ball.Alive)
                // {
                // ball = null;
                //}
                //  }
            }
            //move ball
            // if (ball != null)
            // {
            // ball.Move(deltaT);
            // maybe dead
            //  if (!ball.Alive)
            //  ball = null;
            // }


        }
        #endregion


    }

   
}
