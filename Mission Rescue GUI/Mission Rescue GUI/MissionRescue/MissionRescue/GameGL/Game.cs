using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MissionRescue.GameGL
{
    public class Game
    {
        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, MissionRescue.Properties.Resources.simplebox);
            return blankGameObject;
        }
   
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = MissionRescue.Properties.Resources.simplebox;
            if (displayCharacter == '|' || displayCharacter == '%' )
            {
                img = MissionRescue.Properties.Resources.vertical;
            }

            if (displayCharacter == '-' || displayCharacter == '#')
            {
                img = MissionRescue.Properties.Resources.horizontal;
            }

            if (displayCharacter == '3')
            {
                img = MissionRescue.Properties.Resources.heart;
            }
            if (displayCharacter == 'P' || displayCharacter == 'p')
            {
                img = MissionRescue.Properties.Resources.hero;
            }
            if(displayCharacter == '<' || displayCharacter == '>' || displayCharacter == '*')
            {
                img = MissionRescue.Properties.Resources.spikeWall;
            }
            if(displayCharacter == 'f')
            {
                img = MissionRescue.Properties.Resources.fire;
            }
            return img;
        }

        public static Image getGameObjectImage(GameObjectType type)
        {
            Image img = MissionRescue.Properties.Resources.simplebox;
            if (type == GameObjectType.WALL)
            {
                img = MissionRescue.Properties.Resources.horizontal;
            }

            return img;
        }
    }
}
