using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Grid
    {
        private Block[,] _grid;

        private float _cellSize;
        private int _width;
        private int _height;
        public Grid(int width, int height, float cellSize)
        {
            this._width = width;
            this._height = height;
            this._cellSize = cellSize;

            _grid = new Block[_height, _width];

            for(int x = 0; x < _height; x++)
            {
                for(int y = 0; y < _width; y++)
                {
                    _grid[x, y] = new Block(false,false);
                }
            }

        }


        public void Update(float deltaTime)
        {
            for(int x = 0; x < +_height; x++)
            {
                for(int y = 0;y< _width; y++)
                {
                    _grid[x, y].Update(deltaTime);
                }
            }
        }
        public Block GetObj(float x, float y)
        {
            int xPos = (int)Math.Floor(x / _cellSize);
            int yPos = (int)Math.Floor(y / _cellSize);

            return _grid[yPos, xPos];
        }

        public void SetVisibility(float x, float y, float time)
        {
            int xPos = GetCoords(x);
            int yPos = GetCoords(y);

            _grid[yPos, xPos].SetVisibility(time);
        }
        public void AddBlockInfo(float x, float y, IBlockInfo blockInfo)
        {
            int xPos = GetCoords(x);
            int yPos = GetCoords(y);

            _grid[yPos, xPos].AddBlockInfo(blockInfo);
        }
        public void SetPath(float x, float y, bool isPath)
        {
            int xPos = GetCoords(x);
            int yPos = GetCoords(y);

            _grid[yPos, xPos].IsPathway = isPath;
        }

        int GetCoords(float z)
        {
            return (int)Math.Floor(z / _cellSize);
        }
    }
}
