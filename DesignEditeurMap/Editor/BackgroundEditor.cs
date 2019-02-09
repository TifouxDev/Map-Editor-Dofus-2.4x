using DesignEditeurMap.Manager;
using SFML.Graphics;
using ShadowEmu.Common.GameData.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignEditeurMap.Editor
{
    public class BackgroundEditor
    {
        public Fixture Fixture { get; set; }
        public Sprite Sprite { get; }

        public BackgroundEditor(Fixture fixture)
        {
            Fixture = fixture;
            Sprite = new Sprite(TextureManager.Instance.GetImageGfx(fixture.FixtureId));
        }
    }
}
