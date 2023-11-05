using System.Windows.Forms;
using ZombiesInvader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SpaceInvadore
{
    public partial class ZombieGame : Form
    {
        #region constantes
        int playerSpeed = 10; // vitesse du joueur
        #endregion

        #region variables
        string direction = "up"; // direction du joueur
        bool goLeft, goRight, goUp, goDown; // booléens pour savoir si le joueur va dans une direction
        bool gameOver = false; // booléen pour savoir si le joueur est mort
        int playerLeft; // position du joueur en abscisse
        int playerTop; // position du joueur en ordonnée
        int score = 0; // score du joueur
        Random random = new Random(); // générateur de nombre aléatoire
        List<PictureBox> zombies = new List<PictureBox>(); // liste des zombies
        #endregion


        public ZombieGame()
        {
            InitializeComponent();
        }

        private void KeyIsUp(object sender, KeyEventArgs e) //action à réaliser quand une touches est relachée
        {
            switch (e.KeyCode) // on regarde quelle touche est relachée et on adapte la direction et l'image du joueur en fonction
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

        private void KeyIsDown(object sender, KeyEventArgs e) //action à réaliser quand une touches est préssée
        {
            switch (e.KeyCode) // on regarde quelle touche est préssée et on adapte la direction et l'image du joueur en fonction
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
                playerLeft = player.Left; // on récupère la position du joueur en abscisse
                playerTop = player.Top; // on récupère la position du joueur en ordonnée

                if (goLeft == true && playerLeft > 0) // si le joueur va à gauche et qu'il n'est pas au bord de l'écran
                {
                    player.Left -= playerSpeed; // on déplace le joueur vers la gauche
                }
                if (goRight == true && playerLeft + player.Width < this.ClientSize.Width) // si le joueur va à droite et qu'il n'est pas au bord de l'écran
                {
                    player.Left += playerSpeed; // on déplace le joueur vers la droite
                }
                if (goUp == true && playerTop > 45) // si le joueur va en haut et qu'il n'est pas au bord de l'écran
                {
                    player.Top -= playerSpeed; // on déplace le joueur vers le haut
                }
                if (goDown == true && playerTop + player.Height < this.ClientSize.Height) // si le joueur va en bas et qu'il n'est pas au bord de l'écran
                {
                    player.Top += playerSpeed; // on déplace le joueur vers le bas
                }

                if (zombies.Count() < 4)
                {
                    ZombieSpawn(); // on fait apparaitre un zombie si il y en a moins de 4 sur la carte
                }

                ZombieMove(); // on déplace les zombies

                DispawnZombie(); // on vérifie si une balle à touchée un zombie
                GameOver();
            }


        }


        /// <summary>
        /// fonction qui permet de tirer une balle
        /// </summary>
        /// <param name="direction"></param>
        private void ShootBullet(string direction)
        {
            Bullet bullet = new Bullet(); // on crée une nouvelle balle
            bullet.bulletLeft = playerLeft + (player.Width / 2); // on place la balle au centre du joueur en abscisse
            bullet.bulletTop = playerTop + (player.Height / 2); // on place la balle au centre du joueur en ordonnée
            bullet.bulletDirection = direction; // on donne la direction de la balle
            bullet.BuilderBullet(this); // on ajoute la balle au form
        }

        private void ZombieGame_Load(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// fonction qui permet de faire apparaitre des zombies aléatoirement sur la carte
        /// </summary>
        private void ZombieSpawn()
        {

            int left = random.Next(20, this.ClientSize.Width - 20); // position en abscisse du zombie 
            int top = random.Next(20, this.ClientSize.Height - 20); // position en ordonnée du zombie



            PictureBox zombos = new PictureBox(); // création d'une picturebox pour mettre un zombie sur la carte
            zombos.SizeMode = PictureBoxSizeMode.AutoSize; // on adapte la taille de la picturebox à l'image
            zombos.Tag = "zombie"; // tag du zombie

           

            if (left < playerLeft) // si le zombie est à gauche du joueur
            {
                zombos.Image = ZombiesInvader.Properties.Resources.zleft; // on met l'image du zombie qui va à gauche
                zombos.Left = left - 20; // on place le zombie à gauche du joueur
            }
            if (left > playerLeft) // si le zombie est à droite du joueur
            {
                zombos.Image = ZombiesInvader.Properties.Resources.zright; // on met l'image du zombie qui va à droite
                zombos.Left = left + 20; // on place le zombie à droite du joueur
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

            zombies.Add(zombos); // on ajoute le zombie à la liste des zombies
            this.Controls.Add(zombos); // on ajoute le zombie sur la carte

            if (zombos.Bounds.IntersectsWith(player.Bounds)) // sécurité pour ne pas mourir à l'apparition d'un zombie
            {
                zombos.Left = 10;
                zombos.Top = 10;
            }

        }

        /// <summary>
        /// fonction qui permet de déplacer les zombies vers player
        /// </summary>
        private void ZombieMove()
        {

            foreach (PictureBox zombie in zombies) // tous les zombies de la carte
            {
                if (!Collision(zombie)) // si il n'y a pas de collision on déplace le zombie
                {
                    if (zombie.Left < playerLeft) // si le zombie est à gauche du joueur
                    {
                        zombie.Left += 1; // on déplace le zombie vers la droite
                        zombie.Image = ZombiesInvader.Properties.Resources.zright; // on met l'image du zombie qui va à droite
                    }
                    if (zombie.Left > playerLeft) // si le zombie est à droite du joueur
                    {
                        zombie.Left -= 1; // on déplace le zombie vers la gauche
                        zombie.Image = ZombiesInvader.Properties.Resources.zleft; // on met l'image du zombie qui va à gauche
                    }
                    if (zombie.Top < playerTop) // si le zombie est au dessus du joueur
                    {
                        zombie.Top += 1; // on déplace le zombie vers le bas
                        zombie.Image = ZombiesInvader.Properties.Resources.zdown; // on met l'image du zombie qui va en bas
                    }
                    if (zombie.Top > playerTop) // si le zombie est en dessous du joueur
                    {
                        zombie.Top -= 1; // on déplace le zombie vers le haut
                        zombie.Image = ZombiesInvader.Properties.Resources.zup; // on met l'image du zombie qui va en haut
                    }
                }
            }
        }

        /// <summary>
        /// fonction qui permet de gérer les collisions entre les zombies
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        private bool Collision(PictureBox picture)
        {
            bool collision = false; // initialisation de la valeur retournée

            foreach (var zombie in zombies) // pour chaque zombie de la map
            {
                if (picture.Bounds.IntersectsWith(zombie.Bounds) && zombie != picture) // si le zombie touche un autre zombie
                {
                    collision = true; // il y a collision
                    if (picture.Left > 1 && picture.Left < zombie.Left) // si le zombie est à gauche du zombie touché
                    {
                        picture.Left -= 1; // on déplace le zombie vers la gauche

                    }
                    else if (picture.Left < this.ClientSize.Width - 5 && picture.Left > zombie.Left) // si le zombie est à droite du zombie touché
                    {
                        picture.Left += 1; // on déplace le zombie vers la droite

                    }
                    else if (picture.Top > 5 && picture.Top < zombie.Top) // si le zombie est au dessus du zombie touché
                    {
                        picture.Top -= 1; // on déplace le zombie vers le haut

                    }
                    else if (picture.Top < this.ClientSize.Height - 5 && picture.Top > zombie.Top) // si le zombie est en dessous du zombie touché
                    {
                        picture.Top += 1; // on déplace le zombie vers le bas
                    }

                }
            }

            return collision; // on retourne la valeur de collision
        }

        /// <summary>
        /// fonction qui permet de supprimer les zombies et les balles quand ils se touchent
        /// </summary>
        private void DispawnZombie()
        {
            foreach (var c in this.Controls) // pour chaque objet du form
            {
                if (c is PictureBox && ((PictureBox)c).Tag == "zombie") // si l'objet est un zombie
                {
                    foreach (var x in this.Controls) // pour chaque objet du form 
                    {
                        if (x is PictureBox && ((PictureBox)x).Tag == "bullet") // si l'objet est une balle
                        {
                            if (((PictureBox)c).Bounds.IntersectsWith(((PictureBox)x).Bounds)) // si le zombie touche la balle
                            {
                                score++;
                                lblScore.Text = "Score : " + score; // on affiche le score
                                this.Controls.Remove((PictureBox)c); // on supprime le zombie
                                this.Controls.Remove((PictureBox)x); // on supprime la balle
                                zombies.Remove((PictureBox)c); // on supprime le zombie de la liste des zombies
                            }
                        }
                    }
                }
            }
        }

        public void GameOver()
        {
            foreach(var z in zombies)
            {
                if(z.Bounds.IntersectsWith(player.Bounds))
                {
                    gameOver = true;
                    GameTimer.Stop();
                    string message = $"Votre score est de : {score}";
                    string caption = "Game Over";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        // Closes the parent form.
                        this.Close();
                    }

                }
            }

        }
    }
}