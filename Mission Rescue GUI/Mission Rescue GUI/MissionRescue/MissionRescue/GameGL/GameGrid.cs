using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MissionRescue.GameGL
{
    public class GameGrid
    {
        private int rows;
        private int columns;
        private GameCell[,] gameCells;

        public GameGrid(string filePath, int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            gameCells = new GameCell[rows, columns];
            LoadGrid(filePath);
        }

        void LoadGrid(string fileName)
        {

            StreamReader fp = new StreamReader(fileName);
            string record;
            for (int row = 0; row < this.rows; row++)
            {
                record = fp.ReadLine();
                for (int col = 0; col < this.columns; col++)
                {
                    GameCell cell = new GameCell(row, col, this);
                    char displayCharacter = record[col];
                    GameObjectType type = GameObject.GetGameObjectType(displayCharacter);
                    Image displayIamge = Game.getGameObjectImage(displayCharacter);
                    GameObject gameObject = new GameObject(type, displayIamge);
                    cell.SetGameObject(gameObject);
                    gameCells[row, col] = cell;
                }
            }

            fp.Close();
        }

        public GameCell GetCell(int x, int y)
        {
            GameCell cell;
            cell = gameCells[x, y];
            return cell;
        }

        public int Rows { get => rows; set => rows = value; }
        public int Columns { get => columns; set => columns = value; }
        public GameCell[,] GameCells { get => gameCells; }
    }

}
