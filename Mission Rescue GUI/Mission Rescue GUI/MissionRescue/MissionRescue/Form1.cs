using MissionRescue.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MissionRescue
{
    public partial class Form1 : Form
    {
        GamePlayer nick;
        HorizontalEnemy hEnemy;
        verticalEnemy vEnemy;
        RandomEnemy rEnemy;

        List<Enemy> enemies = new List<Enemy>();
        List<PlayerBullet> nickBullets = new List<PlayerBullet>();
        List<EnemyBullet> hEnemyBullets = new List<EnemyBullet>();
        List<EnemyBullet> vEnemyBullets = new List<EnemyBullet>();

        int enemyTick = 0;
        int bulletTick = 0;
        int enemyBulletTick = 0;
        public int score = 0;
        bool isKeyRight, isKeyLeft, isKeyDown, isKeyUp, isKeySpace;
        
        public int nickHealth = 100;
        public int nickLives = 3;

        public int rEnemyHealth = 100;

        GameGrid maze;

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            maze = new GameGrid("maze.txt", 25, 68);
            Image pacmanImage = Game.getGameObjectImage('P');
            GameCell startCell = maze.GetCell(16, 4);

            GameCell hEnemyStart = maze.GetCell(3, 51);
            GameCell vEnemyStart = maze.GetCell(9, 65);
            GameCell rEnemyStart = maze.GetCell(18, 44);

            hEnemy = new HorizontalEnemy(hEnemyStart);
            vEnemy = new verticalEnemy(vEnemyStart);
            rEnemy = new RandomEnemy(rEnemyStart);
            nick = new GamePlayer(pacmanImage, startCell);
            enemies.Add(hEnemy);
            enemies.Add(vEnemy);
            enemies.Add(rEnemy);
            printMaze(maze);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                isKeyUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                isKeyDown = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                isKeyRight = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                isKeyLeft = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                isKeySpace = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                isKeyUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                isKeyDown = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                isKeyRight = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                isKeyLeft = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                isKeySpace = false;
            }
        }



        


        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {

                for (int y = 0; y < grid.Columns; y++)
                {
                    GameCell cell = grid.GetCell(x, y);
                    this.Controls.Add(cell.PictureBox);
                }
            }
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void gameLoop_Tick_Tick(object sender, EventArgs e)
        {

            GameCell nextCell = null;
            if (isKeyLeft)
            {
                nick.Direction = GameDirection.LEFT;

                nextCell = nick.Move();
                DetectCollision(nextCell);
            }
            if (isKeyRight)
            {

                nick.Direction = GameDirection.RIGHT;
                nextCell = nick.Move();
                DetectCollision(nextCell);
            }
            if (isKeyUp)
            {
                nick.Direction = GameDirection.UP;
                nextCell = nick.Move();
                DetectCollision(nextCell);
            }
            if (isKeyDown)
            {
                nick.Direction = GameDirection.DOWN;
                nextCell = nick.Move();
                DetectCollision(nextCell);
            }
            if (isKeySpace && bulletTick >= 3)
            {
                int x = nick.CurrentCell.X;
                int y = nick.CurrentCell.Y;
                if(y+2 < 67)
                {
                    GameCell startCell = maze.GetCell(x, y + 2);
                    PlayerBullet b = new PlayerBullet(startCell);
                    nickBullets.Add(b);
                }
                
                bulletTick = 0;
            }
            //Move player bullets
            for (int i = nickBullets.Count - 1; i >= 0; i--)
            {
                PlayerBullet b = nickBullets[i];
                b.Direction = GameDirection.RIGHT;
                GameCell c = b.Move();
                if (c == null)
                {
                    nickBullets.RemoveAt(i);
                }
            }

            if (enemyTick == 5)
            {
                foreach (Enemy enemy in enemies)
                {
                    DetectCollision(enemy.Move());
                }
                enemyTick = 0;
            }

            if(enemies.Count == 0)
            {
                gameLoop.Stop();
                YouWin win = new YouWin();
                win.Show();
                this.Hide();

            }

            //Generate Enemy Bullets
            if(enemyBulletTick > 5)
            {
                //Horizontal Enemy Bullets Generation 
                if (CalculateDistance(hEnemy.CurrentCell.X, hEnemy.CurrentCell.Y) < 50 && hEnemy.Health > 0)
                {
                    int x = hEnemy.CurrentCell.X;
                    int y = hEnemy.CurrentCell.Y;
                    if(y-5 > 2)
                    {
                        GameCell startCell = maze.GetCell(x, y - 1);
                        EnemyBullet bullet = new EnemyBullet(startCell);

                        hEnemyBullets.Add(bullet);
                    }
                }
                else if (hEnemy.Health < 0)
                {
                    EnemyBullet.RemoveEnemyBullets(hEnemyBullets);
                }

                //Vertical Enemy Bullets Generation 
                if (CalculateDistance(vEnemy.CurrentCell.X, vEnemy.CurrentCell.Y) < 50 && vEnemy.Health > 0)
                {
                    int x = vEnemy.CurrentCell.X;
                    int y = vEnemy.CurrentCell.Y;
                    GameCell startCell = maze.GetCell(x, y - 2);
                    EnemyBullet bullet = new EnemyBullet(startCell);

                    vEnemyBullets.Add(bullet);

                    
                }
                else if(vEnemy.Health < 0)
                {
                    EnemyBullet.RemoveEnemyBullets(vEnemyBullets);
                }
                enemyBulletTick = 0;
            }
            //move enemy bullets
            for (int i = vEnemyBullets.Count - 1; i >= 0; i--)
            {
                EnemyBullet b = vEnemyBullets[i];
                b.Direction = GameDirection.LEFT;
                GameCell c = b.Move();
                if (c == null)
                {
                    vEnemyBullets.RemoveAt(i);
                }
            }
            for (int i = hEnemyBullets.Count - 1; i >= 0; i--)
            {
                EnemyBullet b = hEnemyBullets[i];
                b.Direction = GameDirection.LEFT;
                GameCell c = b.Move();
                if (c == null)
                {
                    hEnemyBullets.RemoveAt(i);
                }
            }

            enemyTick++;
            bulletTick++;
            enemyBulletTick++;
        }

        public double CalculateDistance(int enemyX, int enemyY)
        {
            int nickX = nick.CurrentCell.X;
            int nickY = nick.CurrentCell.Y;

            int dx = enemyX - nickX;
            int dy = enemyY - nickY;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        private void DetectCollision(GameCell nextCell)
        {
            if (nextCell == null)
            {

                NickLiveDecrement();
            }
            if (nickLives <= 0)
            {
                gameLoop.Stop();
                GameOver over = new GameOver();
                over.Show();
                this.Hide();
            }
        }

        public void NickLivesDisplay()
        {
            livesLabel.Text = "Lives: " + nickLives;
        }
        public void NickLiveDecrement()
        {
            nickHealth = 100;
            nickLives--;
            NickLivesDisplay();
            nick.CurrentCell.X = 16;
            nick.CurrentCell.Y = 4;
        }

        public void NickHealth(int decrement)
        {
            nickHealth -= decrement;
            if (nickHealth <= 0)
            {
                NickLiveDecrement();
            }
            healthLabel.Text = "Health: " + nickHealth;
        }

        public void REnemyHealth()
        {
            rEnemy.Health-=5;
            ScoreUpdation();
            if(rEnemy.Health <= 0)
            {
                rEnemy.RemoveEnemy();
                enemies.Remove(rEnemy);
            }
            rEnemyHealthL.Text = "R-Health: " + rEnemy.Health;
        }
        public void VEnemyHealth()
        {
            vEnemy.Health -= 5;
            ScoreUpdation();
            if (vEnemy.Health <= 0)
            {
                vEnemy.RemoveEnemy();
                enemies.Remove(vEnemy);
            }
            vEnemyHealthL.Text = "V-Health: " + vEnemy.Health;
        }
        public void HEnemyHealth()
        {
            hEnemy.Health -= 5;
            ScoreUpdation();
            if (hEnemy.Health <= 0)
            {
                hEnemy.RemoveEnemy();
                enemies.Remove(hEnemy);
            }
            hEnemyHealthL.Text = "H-Health: " + hEnemy.Health;
        }
        public void ScoreUpdation()
        {

            score++;
            ScoreLabel.Text = "Score:" + score;

        }
    }
}
