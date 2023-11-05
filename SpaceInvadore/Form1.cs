using ZombiesInvader;

namespace SpaceInvadore
{
    public partial class ZombieGame : Form
    {
        #region constantes
        int playerSpeed = 10; // vitesse du joueur

        #endregion

        #region variables
        string direction = "up"; // direction du joueur
        bool goLeft, goRight, goUp, goDown; // bool�ens pour savoir si le joueur va dans une direction
        bool gameOver = false; // bool�en pour savoir si le joueur est mort
        int playerLeft; // position du joueur en abscisse
        int playerTop; // position du joueur en ordonn�e
        Random random = new Random(); // g�n�rateur de nombre al�atoire
        List<PictureBox> zombies = new List<PictureBox>(); // liste des zombies
        #endregion


        public ZombieGame()
        {
            InitializeComponent();
        }

        private void KeyIsUp(object sender, KeyEventArgs e) //action � r�aliser quand une touches est relach�e
        {
            switch (e.KeyCode) // on regarde quelle touche est relach�e et on adapte la direction et l'image du joueur en fonction
            {
                case Keys.Z:
                    goUp = false;
                    break;
                case Keys.S:
                    goDown = false;
                    break;
                case Keys.Q:
                    goLeft = false;
                    break;
                case Keys.D:
                    goRight = false;
                    break;
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e) //action � r�aliser quand une touches est pr�ss�e
        {
            switch (e.KeyCode) // on regarde quelle touche est pr�ss�e et on adapte la direction et l'image du joueur en fonction
            {
                case Keys.Z:
                    direction = "up";
                    goUp = true;
                    player.Image = ZombiesInvader.Properties.Resources.up;
                    break;
                case Keys.S:
                    direction = "down";
                    goDown = true;
                    player.Image = ZombiesInvader.Properties.Resources.down;
                    break;
                case Keys.Q:
                    direction = "left";
                    goLeft = true;
                    player.Image = ZombiesInvader.Properties.Resources.left;
                    break;
                case Keys.D:
                    direction = "right";
                    goRight = true;
                    player.Image = ZombiesInvader.Properties.Resources.right;
                    break;
                case Keys.Space:
                    ShootBullet(direction);
                    break;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                playerLeft = player.Left; // on r�cup�re la position du joueur en abscisse
                playerTop = player.Top; // on r�cup�re la position du joueur en ordonn�e

                if (goLeft == true && playerLeft > 0) // si le joueur va � gauche et qu'il n'est pas au bord de l'�cran
                {
                    player.Left -= playerSpeed; // on d�place le joueur vers la gauche
                }
                if (goRight == true && playerLeft + player.Width < this.ClientSize.Width) // si le joueur va � droite et qu'il n'est pas au bord de l'�cran
                {
                    player.Left += playerSpeed; // on d�place le joueur vers la droite
                }
                if (goUp == true && playerTop > 45) // si le joueur va en haut et qu'il n'est pas au bord de l'�cran
                {
                    player.Top -= playerSpeed; // on d�place le joueur vers le haut
                }
                if (goDown == true && playerTop + player.Height < this.ClientSize.Height) // si le joueur va en bas et qu'il n'est pas au bord de l'�cran
                {
                    player.Top += playerSpeed; // on d�place le joueur vers le bas
                }

                if (zombies.Count() < 4)
                {
                    ZombieSpawn();
                }

                ZombieMove();

                DispawnZombie();
            }


        }

        private void ShootBullet(string direction)
        {
            Bullet bullet = new Bullet(); // on cr�e une nouvelle balle
            bullet.bulletLeft = playerLeft + (player.Width / 2); // on place la balle au centre du joueur en abscisse
            bullet.bulletTop = playerTop + (player.Height / 2); // on place la balle au centre du joueur en ordonn�e
            bullet.bulletDirection = direction; // on donne la direction de la balle
            bullet.BuilderBullet(this); // on ajoute la balle au form
        }

        private void ZombieGame_Load(object sender, EventArgs e)
        {


        }

        private void ZombieSpawn()
        {
            int left = random.Next(20, this.ClientSize.Width - 20); // position en abscisse du zombie 
            int top = random.Next(20, this.ClientSize.Height - 20); // position en ordonn�e du zombie

            PictureBox zombos = new PictureBox(); // cr�ation d'une picturebox pour mettre un zombie sur la carte
            zombos.SizeMode = PictureBoxSizeMode.AutoSize; // on adapte la taille de la picturebox � l'image
            zombos.Tag = "zombie"; // tag du zombie

            if (left < playerLeft) // si le zombie est � gauche du joueur
            {
                zombos.Image = ZombiesInvader.Properties.Resources.zleft; // on met l'image du zombie qui va � gauche
                zombos.Left = left - 20; // on place le zombie � gauche du joueur
            }
            if (left > playerLeft) // si le zombie est � droite du joueur
            {
                zombos.Image = ZombiesInvader.Properties.Resources.zright; // on met l'image du zombie qui va � droite
                zombos.Left = left + 20; // on place le zombie � droite du joueur
            }
            if (top < playerTop) // si le zombie est au dessus du joueur
            {
                zombos.Image = ZombiesInvader.Properties.Resources.zup; // on met l'image du zombie qui va en haut
                zombos.Top = top - 20; // on place le zombie au dessus du joueur
            }
            if (top > playerTop) // si le zombie est en dessous du joueur
            {
                zombos.Image = ZombiesInvader.Properties.Resources.zdown; // on met l'image du zombie qui va en bas
                zombos.Top = top + 20; // on place le zombie en dessous du joueur
            }

            zombies.Add(zombos); // on ajoute le zombie � la liste des zombies
            this.Controls.Add(zombos); // on ajoute le zombie sur la carte

        }

        private void ZombieMove()
        {

            foreach (PictureBox zombie in zombies)
            {
                if (!Collision(zombie))
                {
                    if (zombie.Left < playerLeft) // si le zombie est � gauche du joueur
                    {
                        zombie.Left += 1; // on d�place le zombie vers la droite
                        zombie.Image = ZombiesInvader.Properties.Resources.zright; // on met l'image du zombie qui va � droite
                    }
                    if (zombie.Left > playerLeft) // si le zombie est � droite du joueur
                    {
                        zombie.Left -= 1; // on d�place le zombie vers la gauche
                        zombie.Image = ZombiesInvader.Properties.Resources.zleft; // on met l'image du zombie qui va � gauche
                    }
                    if (zombie.Top < playerTop) // si le zombie est au dessus du joueur
                    {
                        zombie.Top += 1; // on d�place le zombie vers le bas
                        zombie.Image = ZombiesInvader.Properties.Resources.zdown; // on met l'image du zombie qui va en bas
                    }
                    if (zombie.Top > playerTop) // si le zombie est en dessous du joueur
                    {
                        zombie.Top -= 1; // on d�place le zombie vers le haut
                        zombie.Image = ZombiesInvader.Properties.Resources.zup; // on met l'image du zombie qui va en haut
                    }
                }              
            }
        }

        private bool Collision(PictureBox picture)
        {
            bool collision = false;

            foreach(var zombie in zombies)
            {
                if (picture.Bounds.IntersectsWith(zombie.Bounds) && zombie != picture)
                {
                    collision = true;
                    if(picture.Left > 1 && picture.Left < zombie.Left)
                    {
                        picture.Left -= 1;

                    } else if(picture.Left < this.ClientSize.Width - 5 && picture.Left > zombie.Left)
                    {
                        picture.Left += 1;

                    } else if(picture.Top > 5 && picture.Top < zombie.Top)
                    {
                        picture.Top -= 1;

                    } else if(picture.Top < this.ClientSize.Height - 5 && picture.Top > zombie.Top)
                    {
                        picture.Top += 1;
                    }
                                  
                }
            }

            return collision;
        }

        private void DispawnZombie()
        {
            foreach (var c in this.Controls)
            {
                if (c is PictureBox && ((PictureBox)c).Tag == "zombie")
                {
                    foreach (var x in this.Controls)
                    {
                        if(x is PictureBox && ((PictureBox)x).Tag == "bullet")
                        {
                            if (((PictureBox)c).Bounds.IntersectsWith(((PictureBox)x).Bounds))
                            {
                                this.Controls.Remove((PictureBox)c);
                                this.Controls.Remove((PictureBox)x);
                                zombies.Remove((PictureBox)c);
                            }
                        }
                    }
                }
            }
        }
    }
}