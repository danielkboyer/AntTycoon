using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMap
{
    /// <summary>
    /// Retrieves an object on the grid
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    Block GetBlock(float x, float y);

    /// <summary>
    /// Paints a part of the grid at x and y with size 2 meaning a square around a single unit
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="size"></param>
    void Paint(float x, float y, int size);

    /// <summary>
    /// sets an object on the grid and returns whether or not that object is visible
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    void AddBlockInfo(float x, float y, IBlockInfo blockInfo);

    void SetVisibility(float x, float y, float time);

    void SetPath(float x, float y, bool isPath);

    Transform GetTransform();
}
