using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using ZombiesInvader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace TestZombinvader
{
    [TestClass]
   public class ZombieGameTests
    {
        [TestMethod]
        public void Test_KeyIsDown()
        {
           
            var game = new ZombieGame();
            game.GameTimer_Tick(null, null);

            var initialTop = game.player.Top;

            var e = new KeyEventArgs(Keys.Z); // Simuler la touche Z pressée
            game.KeyIsDown(null, e);

            game.wavewait = false;
            game.firstrender = false;
            game.GameTimer_Tick(null,null);

           

       
            Assert.AreEqual("up", game.direction); // Vérifier si la direction est correctement définie
            Assert.IsTrue(game.goUp); // Vérifier si goUp est défini sur true
            Assert.IsTrue(initialTop == game.player.Top + game.playerSpeed);
        }
        [TestMethod]
        public void Test_TakingDammage()
        {

            var game = new ZombieGame();
            var initialHealth = game.health;
            game.ZombieSpawn();


            game.zombies[0].Bounds = game.player.Bounds;

            game.GameOver();


            Assert.IsTrue(game.health==(initialHealth-25)); // Vérifier si la vie du joueur descend bien
        }

        [TestMethod]
        public void Test_GameOver()
        {
       
            var game = new ZombieGame();
            game.ZombieSpawn();

            game.health = 0;
           
            game.GameOver();

           
            Assert.IsTrue(game.gameOver); // Vérifier si gameOver est défini sur true
        }

        [TestMethod]
        public void Test_DropItem()
        {
           
            var game = new ZombieGame();
            game.munitions = 0; // Simuler le joueur sans munitions

         
            game.DropItem();

          
            Assert.IsTrue(game.drop); // Vérifier si drop est défini sur true après avoir vérifié que le joueur n'a pas de munitions
        }

        [TestMethod]
        public void Test_ZombieSpawn()
        {
       
            var game = new ZombieGame();
            game.ZombieSpawn();


            Assert.IsTrue( game.zombies[0] !=null); // Vérifier si un PictureBox de tag "zombie" est présent dans les contrôles
        }

        [TestMethod]
        public void Test_ZombieMove()
        {
         
            var game = new ZombieGame();

          
            game.ZombieSpawn();
            var originalLeft = game.zombies[0].Left; // Récupérer la position initiale en X du premier zombie
            var originalTop = game.zombies[0].Top; // Récupérer la position initiale en Y du premier zombie
            game.ZombieMove();
            var newLeft = game.zombies[0].Left; // Récupérer la nouvelle position en X du premier zombie
            var newTop = game.zombies[0].Top; // Récupérer la nouvelle position en Y du premier zombie

            var origindDffLeft = originalLeft - game.player.Left;
            var origindDffTop = originalTop - game.player.Top;

            var newDiffLeft = newLeft - game.player.Left;
            var newDiffTop = newTop - game.player.Top;

            Assert.AreNotEqual(originalLeft, newLeft); // Vérifier si la position en X a changé
            Assert.AreNotEqual(originalTop, newTop); // Vérifier si la position en Y a changé
            Assert.IsTrue(origindDffLeft>newDiffLeft && origindDffTop>newDiffTop);
        }

        [TestMethod]
        public void Test_CollisionZombie()
        {
          
            var game = new ZombieGame();
            game.wave = 2;
            game.ZombieSpawn();
            game.ZombieSpawn();
            game.zombies[0].Bounds = game.zombies[1].Bounds;

         
            Assert.IsTrue(game.Collision(game.zombies[1])); // Vérifier si la collision est détectée entre le zombie et l'autre PictureBox
        }
        [TestMethod]
        public void Test_TakeItem()
        {
            var game = new ZombieGame();
            game.munitions = 0; // Simuler le joueur sans munitions
            game.DropItem();

            foreach (var i in game.Controls)
            {
                if (i is PictureBox && ((PictureBox)i).Tag == "munition")
                {
                    game.player.Left = ((PictureBox)i).Left;
                    game.player.Top = ((PictureBox)i).Top;
                }
            }
            game.TakeItem();

            Assert.IsTrue((!game.drop) && (game.munitions == 6)); // Vérifier si drop est défini sur true après avoir vérifié que le joueur n'a pas de munitions
        }
        [TestMethod]
        public void Test_DiagMove()
        {

            var game = new ZombieGame();

            var expectedTop = game.player.Top - game.playerSpeed;
            var expectedLeft = game.player.Left + game.playerSpeed;


            var z = new KeyEventArgs(Keys.Z);
            var d = new KeyEventArgs(Keys.D);

            game.KeyIsDown(null, z);
            game.KeyIsDown(null, d);

            game.wavewait = false;
            game.firstrender = false;

            game.GameTimer_Tick(game.player, z);


            Assert.IsTrue(game.player.Top == expectedTop  && game.player.Left == expectedLeft); ; // Vérifier si le booléen goUp est défini sur true
        }

        [TestMethod]
        public void Test_DispawnZombieAndScore()
        {
            var game = new ZombieGame();

            game.ZombieSpawn();

            

            var z = new KeyEventArgs(Keys.Z);
            game.KeyIsDown(null, z);

            game.zombies[0].Left = game.player.Left - 20 ;
            game.zombies[0].Top = game.player.Top;
            
            game.ShootBullet("left");
            foreach (var x in game.Controls) 
            {
                if (x is PictureBox && ((PictureBox)x).Tag == "bullet") 
                {
                    ((PictureBox)x).Left = game.zombies[0].Left;
                    ((PictureBox)x).Top = game.zombies[0].Top;
                }   
            }

            game.DispawnZombie();

            Assert.IsTrue(game.zombies.Count == 0 && game.score == 1);
        }


    }
}

