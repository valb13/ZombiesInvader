using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ZombiesInvader
{
    public class Bullet
    {
        #region constantes
        private int bulletSpeed = 20; // vitesse de la balle
        private PictureBox bulletPicture = new PictureBox(); // picturebox de la balle
        private System.Windows.Forms.Timer bulletTimer = new System.Windows.Forms.Timer(); // timer de la balle
        private int left;
        private int top;
        #endregion

        #region variables
        public bool shot = false; // booléen pour savoir si la balle est tirée
        public int bulletLeft; // position de la balle en abscisse
        public int bulletTop; // position de la balle en ordonnée
        public string bulletDirection; // direction de la balle
        #endregion

        public void BuilderBullet(Form form)
        {

            bulletPicture.BackColor = Color.White; // couleur de la balle
            bulletPicture.Size = new Size(5, 5); // taille de la balle
            bulletPicture.Tag = "bullet"; // tag de la balle
            left = bulletLeft; // on garde en mémoire la position de la balle en abscisse au moment du tire
            top = bulletTop; // on garde en mémoire la position de la balle en ordonnée au moment du tire
            bulletPicture.Left = bulletLeft; // position de la balle en abscisse
            bulletPicture.Top = bulletTop; // position de la balle en ordonnée
            bulletTimer.Interval = bulletSpeed; // vitesse de la balle
            bulletTimer.Tick += new EventHandler(BulletTimerEvent); // on ajoute l'évènement de la balle au timer

            bulletPicture.BringToFront(); // on met la balle devant les autres objets

            form.Controls.Add(bulletPicture); // on ajoute la balle au form
            bulletTimer.Start(); // on démarre le timer de la balle

        }

        private void BulletTimerEvent(object sender, EventArgs e) // action à réaliser quand le timer de la balle est écoulé
        {
            switch (bulletDirection) // on regarde la direction de la balle
            {
                case "left":
                    bulletPicture.Left -= bulletSpeed; // on déplace la balle vers la gauche
                    break;
                case "right":
                    bulletPicture.Left += bulletSpeed; // on déplace la balle vers la droite
                    break;
                case "up":
                    bulletPicture.Top -= bulletSpeed; // on déplace la balle vers le haut
                    break;
                case "down":
                    bulletPicture.Top += bulletSpeed; // on déplace la balle vers le bas
                    break;
            }

            if (bulletPicture.Left < 10 || bulletPicture.Left > left + 500 || bulletPicture.Left < left - 500 ||bulletPicture.Top < 0 || bulletPicture.Top > top + 500 || bulletPicture.Top < top - 500) // si la balle sort de l'écran ou de la zone de tire
            {
                bulletTimer.Stop(); // on arrête le timer de la balle
                bulletTimer.Dispose(); // on supprime le timer de la balle
                bulletPicture.Dispose(); // on supprime la balle
                bulletPicture = null; // on indique que la balle n'existe plus
                shot = false; // on indique que la balle n'est plus tirée
            }
        }
    }
}
