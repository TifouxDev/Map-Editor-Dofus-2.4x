using DesignEditeurMap.Extension;
using DesignEditeurMap.View.Map;
using DesignEditeurMap.View.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignEditeurMap.View
{
    public class UIManager : DataManager<UIManager>
    {
        public Form2 EditorForm;
        public Tiles.TilesExplorer TileExplorer;
        public MapInformations MapInformation;
        public LayerExplorer LayersExplorer;

        public ShadowEmu.Common.GameData.D2I.D2iFile D2I;
        public UIManager()
        {
            EditorForm = new Form2();
            TileExplorer = new Tiles.TilesExplorer();
            MapInformation = new MapInformations();
            LayersExplorer = new LayerExplorer();
            D2I = new ShadowEmu.Common.GameData.D2I.D2iFile(AppDomain.CurrentDomain.BaseDirectory + @"\data\i18n\i18n_fr.d2i");
        }

    }
}
