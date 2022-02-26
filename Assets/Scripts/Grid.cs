using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Grid
    {
        private (bool isPath, IGrid gridObj)[,] _grid;

        private float _cellSize;
        private int _width;
        private int _height;
        public Grid(int width, int height, float cellSize)
        {
            this._width = width;
            this._height = height;
            this._cellSize = cellSize;

            _grid = new (bool isPath, IGrid gridObj)[_height, _width];

            for(int x = 0; x < _height; x++)
            {
                for(int y = 0; y < _width; y++)
                {
                    _grid[x, y] = (false,null);
                }
            }

        }


        public (bool isPath, IGrid gridObj) GetObj(float x, float y)
        {
            int xPos = (int)Math.Floor(x / _cellSize);
            int yPos = (int)Math.Floor(y / _cellSize);

            return _grid[yPos, xPos];
        }

        public void SetObj(float x, float y, IGrid gridObj, bool isPath)
        {
            int xPos = (int)Math.Floor(x / _cellSize);
            int yPos = (int)Math.Floor(y / _cellSize);

            _grid[yPos, xPos].gridObj = gridObj;
            _grid[yPos, xPos].isPath = isPath;
        }
    }
}
