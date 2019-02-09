using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignEditeurMap.Constant
{
    public class AtouinConstants
    {
        public static bool DEBUG_FILES_PARSING = false;

        public static bool DEBUG_FILES_PARSING_ELEMENTS = false;

        public static uint MAP_WIDTH = 14;

        public static uint MAP_HEIGHT = 20;

        public static uint MAP_CELLS_COUNT = 560;

        public static uint ADJACENT_CELL_LEFT_MARGIN = 5;

        public static uint ADJACENT_CELL_RIGHT_MARGIN = 5;

        public static uint CELL_WIDTH = 86;

        public static uint CELL_HALF_WIDTH = 43;

        public static uint CELL_HEIGHT = 43;

        public static double CELL_HALF_HEIGHT = 21.5;

        public static uint ALTITUDE_PIXEL_UNIT = 10;

        public static int LOADERS_POOL_INITIAL_SIZE = 30;

        public static int LOADERS_POOL_GROW_SIZE = 5;

        public static int LOADERS_POOL_WARN_LIMIT = 100;

        public static double OVERLAY_MODE_ALPHA = 0.7;

        public static int MAX_ZOOM = 4;

        public static int MAX_GROUND_CACHE_MEMORY = 5;

        public static int GROUND_MAP_VERSION = 2;

        public static double MIN_DISK_SPACE_AVAILABLE = Math.Pow(2, 20) * 512;

        public static int PSEUDO_INFINITE = 63;

        public static int PATHFINDER_MIN_X = 0;

        public static int PATHFINDER_MAX_X = 33 + 1;

        public static int PATHFINDER_MIN_Y = -19;

        public static int PATHFINDER_MAX_Y = 13 + 1;

        public static int VIEW_DETECT_CELL_WIDTH = (int)(2 * CELL_WIDTH);

        public static int MIN_MAP_X = -255;

        public static int MAX_MAP_X = 255;

        public static int MIN_MAP_Y = -255;

        public static int MAX_MAP_Y = 255;

        public static uint MOVEMENT_WALK = 1;

        public static uint MOVEMENT_NORMAL = 2;

        public static uint WIDESCREEN_BITMAP_WIDTH = 0;

    }
}
