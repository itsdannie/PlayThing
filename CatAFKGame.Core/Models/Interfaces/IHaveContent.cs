using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAFKGame.Core.Models.Interfaces
{
    public interface IHaveContent
    {
        void LoadContent(ContentManager content, GraphicsDeviceManager _graphics);
    }
}
