using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System;

[RequireComponent(typeof(MeshFilter))]
public class Map : MonoBehaviour, IMap
{
    private Assets.Scripts.Grid _grid;

    Vector3[] vertices;

    int[] triangles;
    Color[] colors;
    public Color GroundColor;
    public Color PathColor;
    Mesh mesh;

    public int XSize;
    public int ZSize;
    public float CellSpace;
    public (bool isPath, IGrid gridObj) GetObj(float x, float y)
    {
        return _grid.GetObj(x, y);
    }

    public void Paint(float x, float y, int size)
    {
        Debug.Log($"({x},{y})");
        Debug.Log($"float to grid ({FloatToGrid(x)},{(XSize+1) * (FloatToGrid(y))})");
        int botLeft = FloatToGrid(x) + (XSize+1) * (FloatToGrid(y));

        Debug.Log($"Bot left: {botLeft}");
        int topLeft = botLeft + XSize+1;
        int topRight = botLeft + XSize + 2;
        int botRight = botLeft + 1;

        if(botLeft < colors.Length)
        {
            colors[botLeft] = PathColor;
        }
        if (topLeft < colors.Length)
        {
            colors[topLeft] = PathColor;
        }
        if (topRight < colors.Length)
        {
            colors[topRight] = PathColor;
        }
        if (botRight < colors.Length)
        {
            colors[botRight] = PathColor;
        }
        SetObj(x, y, null,true);
        SetObj(x+CellSpace, y, null, true);
        SetObj(x, y+CellSpace, null, true);
        SetObj(x+CellSpace, y+CellSpace, null, true);
        UpdateMesh();
    }

    private int FloatToGrid(float toConvert)
    {
        return (int)Math.Floor(toConvert / CellSpace);
    }
    public bool SetObj(float x, float y, IGrid type, bool isPath)
    {
        _grid.SetObj(x, y, type,isPath);
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _grid = new Assets.Scripts.Grid(XSize+1, ZSize+1, CellSpace);
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;
       
        mesh.RecalculateNormals();
        MeshCollider meshCollider = GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }
    void CreateShape()
    {
        vertices = new Vector3[(XSize + 1) * (ZSize+1)];
        for(int i = 0, z = 0; z <= ZSize; z++)
        {
            for(int x = 0; x <= XSize; x++)
            {
                
                vertices[i] = new Vector3(x * CellSpace, 0, z * CellSpace);
                i++;
            }
        }

        int vert = 0;
        int tris = 0;
        triangles = new int[XSize * ZSize * 6];
        for (int z = 0; z < ZSize; z++)
        {
            for (int x = 0; x < XSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + XSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + XSize + 1;
                triangles[tris + 5] = vert + XSize + 2;
                vert++;
                tris += 6;
            }
            vert++;
        }

        colors = new Color[vertices.Length];
        for(int i = 0, z= 0; z <= ZSize; z++)
        {
            for(int x = 0;x<= XSize; x++)
            {
                colors[i] = GroundColor;
                i++;
            }
        }
        colors[0] = PathColor;
        colors[1] = PathColor;
        colors[51] = PathColor;
        colors[52] = PathColor;

    }

    private void OnDrawGizmos()
    {
       
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
