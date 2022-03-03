using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner :MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AntPrefab;
    public Map Map;
    private float _currentSpawnTime = 10f;
    public float SpawnTime;
    void Start()
    {
        Map = GameObject.FindObjectOfType<Map>();
        _currentSpawnTime = SpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        _currentSpawnTime -= Time.deltaTime;
        if(_currentSpawnTime < 0)
        {
            _currentSpawnTime = SpawnTime;
            Spawn();
        }
    }

    void Spawn()
    {
        var UnityObject = Instantiate(AntPrefab, this.transform.position, Quaternion.identity,Map.transform);
        var antScript = UnityObject.GetComponent<Ant>();
        antScript.NavStatus = NavigationStatus.NAVIGATING;
        
        antScript.CurrentFood = null;
    }
}
