
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MissionRescue.GameGL
{
    public class GameCell
    {
        private int x;
        private int y;
        private GameObject currentGameObject;
        private GameGrid gameGrid;
        private const int width = 20;
        private const int height = 20;
        PictureBox cellPicture = new PictureBox();

        public GameCell(int x, int y, GameGrid gameGrid)
        {
            this.x = x;
            this.y = y;
            this.cellPicture = new PictureBox();
            cellPicture.Left = y * width;
            cellPicture.Top = x * height;
            cellPicture.Size = new Size(width, height);
            cellPicture.SizeMode = PictureBoxSizeMode.Zoom;
            cellPicture.BackColor = Color.Transparent;
            this.gameGrid = gameGrid;
        }
        public void SetGameObject(GameObject gameObject)
        {
            this.currentGameObject = gameObject;
            cellPicture.Image = gameObject.Image;
        }

        public GameCell NextCell(GameDirection direction)
        {
            if (direction == GameDirection.LEFT)
            {
                if (y > 0)
                {
                    GameCell nCell = gameGrid.GetCell(x, y - 1);
                    return nCell;
                }
            }
            else if (direction == GameDirection.RIGHT)
            {
                if (y < gameGrid.Columns - 1)
                {
                    GameCell nCell = gameGrid.GetCell(x, y + 1);
                    return nCell;
                }
            }
            else if (direction == GameDirection.UP)
            {
                if (x > 0)
                {
                    GameCell nCell = gameGrid.GetCell(x - 1, y);
                    return nCell;
                }
            }
            else if (direction == GameDirection.DOWN)
            {
                if (x < gameGrid.Rows - 1)
                {
                    GameCell nCell = gameGrid.GetCell(x + 1, y);
                    return nCell;
                }
            }

            return this;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public GameObject CurrentGameObject { get => currentGameObject; set => currentGameObject = value; }
        public PictureBox PictureBox { get => cellPicture; set => cellPicture = value; }
    }
}
