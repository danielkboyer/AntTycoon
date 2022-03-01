using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Grid
    {
        [SerializeField]
        private Block[] _grid;
        [SerializeField]
        private float _cellSize;
        [SerializeField]
        private int _width;
        [SerializeField]
        private int _height;

        public Grid()
        {

        }
        public Grid(int width, int height, float cellSize)
        {
            this._width = width;
            this._height = height;
            this._cellSize = cellSize;

            _grid = new Block[_height*_width];

            for(int y = 0; y < _height; y++)
            {
                for(int x = 0; x < _width; x++)
                {
                    _grid[x+y*_width] = new Block(false,false);
                }
            }

        }

        public void DestroyGameObjects()
        {
            foreach(var block in _grid)
            {
                block.DestroyGameObjects();
            }
        }
        public void Update(float deltaTime)
        {
            for(int y = 0; y < +_height; y++)
            {
                for(int x = 0;x< _width; x++)
                {
                    _grid[x + y * _width].Update(deltaTime);
                }
            }
        }
        public Block GetObj(float x, float y)
        {
            int xPos = (int)Math.Floor(x / _cellSize);
            int yPos = (int)Math.Floor(y / _cellSize);

            return _grid[xPos + _width * yPos];
        }

        public void SetVisibility(float x, float y, float time)
        {
            int xPos = GetCoords(x);
            int yPos = GetCoords(y);

            _grid[xPos + _width * yPos].SetVisibility(time);
        }
        public void AddBlockInfo(float x, float y, BlockInfo blockInfo)
        {
            int xPos = GetCoords(x);
            int yPos = GetCoords(y);

            _grid[xPos + _width * yPos].AddBlockInfo(blockInfo);
        }
        public void SetPath(float x, float y, bool isPath)
        {
            int xPos = GetCoords(x);
            int yPos = GetCoords(y);

            _grid[xPos + _width * yPos].IsPathway = isPath;
        }

        int GetCoords(float z)
        {
            return (int)Math.Floor(z / _cellSize);
        }
    }
}
