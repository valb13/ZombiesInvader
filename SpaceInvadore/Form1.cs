namespace SpaceInvadore
{
    public partial class ZombieGame : Form
    {
        #region variables
        string direction = "up"; // direction du joueur
        bool goLeft, goRight, goUp, goDown; // booléens pour savoir si le joueur va dans une direction
        int playerSpeed = 10; // vitesse du joueur
        int playerLeft; // position du joueur en abscisse
        int playerTop; // position du joueur en ordonnée
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
                    break;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
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

        }
    }
}