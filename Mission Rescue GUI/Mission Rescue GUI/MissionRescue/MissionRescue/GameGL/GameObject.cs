using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionRescue.GameGL
{
    public class GameObject
    {
        private char displayCharacter;
        private GameCell currentCell;
        private GameObjectType gameObjectType;
        private Image image;
        public GameDirection Direction;

        public GameObject(GameObjectType type, Image image)
        {
            this.gameObjectType = type;
            this.image = image;
        }
        public GameObject(GameObjectType type, Image image, GameCell startCell)
        {
            this.gameObjectType = type;
            this.image = image;
            this.currentCell = startCell;
            currentCell.SetGameObject(this);
        }
        public GameObject(GameObjectType gameObjectType, char displayCharacter)
        {
            this.displayCharacter = displayCharacter;
            this.gameObjectType = gameObjectType;
        }
        public GameObject(char displayCharacter)
        {
            this.displayCharacter = displayCharacter;
            this.gameObjectType = GameObject.GetGameObjectType(displayCharacter);
        }

        public GameObject(GameObjectType gameObjectType, char displayCharacter, GameCell currentCell)
        {
            this.displayCharacter = displayCharacter;
            this.gameObjectType = gameObjectType;
            this.currentCell = currentCell;
        }
        public static GameObjectType GetGameObjectType(char  displayCharacter)
        {
            if (displayCharacter == '|' || displayCharacter == '%' || displayCharacter == '#' || displayCharacter == '-' || displayCharacter == '_')
            {
                return GameObjectType.WALL;
            }
            else if (displayCharacter == '.')
            {
                return GameObjectType.REWARD;
            }
            
            else if (displayCharacter == 'P')
            {
                return GameObjectType.PLAYER;
            }

            else if(displayCharacter == '*' || displayCharacter == '<' || displayCharacter == '>')
            {
                return GameObjectType.SPIKE;
            }

            else if(displayCharacter == '3' || displayCharacter == 3)
            {
                return GameObjectType.HEART;
            }

            return GameObjectType.NONE;
        }

        public Image Image { get { return image; } set { this.image = value; } }
        public char DisplayCharacter { get => displayCharacter; set => displayCharacter = value;}
        public GameObjectType GameObjectType { get => gameObjectType; set => gameObjectType = value; }
        public GameCell CurrentCell { 
            get => currentCell; 
            set
            {
                currentCell = value;
                currentCell.SetGameObject(this);
               
            } 
        }
    }
}
