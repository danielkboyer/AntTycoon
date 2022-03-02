using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    // Start is called before the first frame update
    public int StartSpawn = 0;
    public float Spacing = 1f;
    public GameObject AntPrefab;
    public Map Map;
    void Start()
    {
        float startX = transform.position.x;
        float startZ = transform.position.z;

        float xP = startX;
        float zP = startZ;
        for(int x = 0; x < StartSpawn; x++)
        {
            xP += Spacing;
            if(x % 10 == 0)
            {
                xP = startX;
                zP += Spacing;
            }
            var position = this.transform.position;
            position.x = xP;
            position.z = zP;

            var ant = Instantiate(AntPrefab, position, Quaternion.identity).GetComponent<Ant>();
            ant.Map = Map;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
