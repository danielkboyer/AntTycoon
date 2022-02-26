using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Assets.Scripts;
public class TestTerrain : MonoBehaviour
{
    Terrain terrain;
    public int paintSize = 1;
    private float[,,] currentTerrain;
    private float[,,] originalTerrain;
    private bool draw;


    public float UpdateRate = 1f;

    public Transform LeftHand;
    private float currentTimeStamp = 0f;


    private Assets.Scripts.Grid _grid;

    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();
      
        originalTerrain = terrain.terrainData.GetAlphamaps(0, 0, terrain.terrainData.alphamapWidth, terrain.terrainData.alphamapHeight);
        currentTerrain = terrain.terrainData.GetAlphamaps(0, 0, terrain.terrainData.alphamapWidth, terrain.terrainData.alphamapHeight);

        //for (int y = 0; y < terrain.terrainData.alphamapHeight; y++)
        //{
        //    for (int x = y; x < terrain.terrainData.alphamapWidth; x++)
        //    {
        //        float a0 = maps[x, y, 0];
        //        float a1 = maps[x, y, 1];


        //        maps[x, y, 0] = 0;
        //        maps[x, y, 1] = 1;
        //    }
        //}
        //maps[0, 0, 0] = 0;
        //maps[0, 0, 1] = 1;

        //maps[terrain.terrainData.alphamapWidth-1, terrain.terrainData.alphamapHeight-1, 0] = 0;
        //maps[terrain.terrainData.alphamapWidth-1, terrain.terrainData.alphamapHeight-1, 1] = 1;
        //Debug.Log("width " + terrain.terrainData.alphamapWidth);
        //terrain.terrainData.SetAlphamaps(0, 0, maps);
    }

    public void TriggerStart()
    {
        draw = true;
    }

    public void TriggerEnd()
    {
        draw = false;
    }
    public void SelectInteraction(XRBaseInteractor obj)
    {
       

    }
    public bool OnPath(Vector3 point)
    {
        int x = (int)((point.x / 500) * terrain.terrainData.alphamapWidth);
        int y = (int)((point.z / 500) * terrain.terrainData.alphamapHeight);

        var map = terrain.terrainData.GetAlphamaps(x, y, 1, 1);

        return map[0, 0, 1] == 1;
    }
    public void Paint(Vector3 point)
    {
        int x = (int)((point.x/500) * terrain.terrainData.alphamapWidth);
        int y = (int)((point.z / 500) * terrain.terrainData.alphamapHeight);
        Debug.Log($"X:{x}, Y:{y}");
        var map = terrain.terrainData.GetAlphamaps(x - paintSize/2,y - paintSize/2, paintSize, paintSize);
        Debug.Log($"Map length {map.Length}");
        for(int p = 0; p < paintSize; p++)
        {
            for(int z = 0; z < paintSize; z++)
            {
                map[p, z, 0] = 0;
                map[p, z, 1] = 1;
            }
        }

        terrain.terrainData.SetAlphamaps( x - paintSize / 2, y - paintSize / 2,map);
      
    }
    // Update is called once per frame
    void Update()
    {
        if (draw)
        {
            RaycastHit hit;
            if (Physics.Raycast(LeftHand.position, LeftHand.forward, out hit, 100))
            {
                if (hit.transform.tag == "Terrain")
                {
                    Debug.Log(hit.transform.tag);
                    Debug.Log(hit.transform.InverseTransformPoint(hit.point));
                    Paint(hit.transform.InverseTransformPoint(hit.point));
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        terrain.terrainData.SetAlphamaps(0, 0, originalTerrain);
    }

    public (bool isPath, IGrid gridObj) GetObj(float x, float y)
    {
        return _grid.GetObj(x, y);
    }

    public void Paint(int x, int y, int size)
    {
        throw new System.NotImplementedException();
    }

    public bool SetObj(float x, float y, IGrid type)
    {
        throw new System.NotImplementedException();
    }

}


