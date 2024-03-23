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

            var e = new KeyEventArgs(Keys.Z); // Simuler la touche Z press�e
            game.KeyIsDown(null, e);

            game.wavewait = false;
            game.firstrender = false;
            game.GameTimer_Tick(null,null);

           

       
            Assert.AreEqual("up", game.direction); // V�rifier si la direction est correctement d�finie
            Assert.IsTrue(game.goUp); // V�rifier si goUp est d�fini sur true
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


            Assert.IsTrue(game.health==(initialHealth-25)); // V�rifier si la vie du joueur descend bien
        }

        [TestMethod]
        public void Test_GameOver()
        {
       
            var game = new ZombieGame();
            game.ZombieSpawn();

            game.health = 0;
           
            game.GameOver();

           
            Assert.IsTrue(game.gameOver); // V�rifier si gameOver est d�fini sur true
        }

        [TestMethod]
        public void Test_DropItem()
        {
           
            var game = new ZombieGame();
            game.munitions = 0; // Simuler le joueur sans munitions

         
            game.DropItem();

          
            Assert.IsTrue(game.drop); // V�rifier si drop est d�fini sur true apr�s avoir v�rifi� que le joueur n'a pas de munitions
        }

        [TestMethod]
        public void Test_ZombieSpawn()
        {
       
            var game = new ZombieGame();
            game.ZombieSpawn();


            Assert.IsTrue( game.zombies[0] !=null); // V�rifier si un PictureBox de tag "zombie" est pr�sent dans les contr�les
        }

        [TestMethod]
        public void Test_ZombieMove()
        {
         
            var game = new ZombieGame();

          
            game.ZombieSpawn();
            var originalLeft = game.zombies[0].Left; // R�cup�rer la position initiale en X du premier zombie
            var originalTop = game.zombies[0].Top; // R�cup�rer la position initiale en Y du premier zombie
            game.ZombieMove();
            var newLeft = game.zombies[0].Left; // R�cup�rer la nouvelle position en X du premier zombie
            var newTop = game.zombies[0].Top; // R�cup�rer la nouvelle position en Y du premier zombie

            var origindDffLeft = originalLeft - game.player.Left;
            var origindDffTop = originalTop - game.player.Top;

            var newDiffLeft = newLeft - game.player.Left;
            var newDiffTop = newTop - game.player.Top;

            Assert.AreNotEqual(originalLeft, newLeft); // V�rifier si la position en X a chang�
            Assert.AreNotEqual(originalTop, newTop); // V�rifier si la position en Y a chang�
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

         
            Assert.IsTrue(game.Collision(game.zombies[1])); // V�rifier si la collision est d�tect�e entre le zombie et l'autre PictureBox
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

            Assert.IsTrue((!game.drop) && (game.munitions == 6)); // V�rifier si drop est d�fini sur true apr�s avoir v�rifi� que le joueur n'a pas de munitions
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


            Assert.IsTrue(game.player.Top == expectedTop  && game.player.Left == expectedLeft); ; // V�rifier si le bool�en goUp est d�fini sur true
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

