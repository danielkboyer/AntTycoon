using Assets.Scripts.PersistentStorage;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Food;
    public Map Map;
    public Player Player;
    // Start is called before the first frame update
    void Start()
    {
        LoadStartLevel();
    }


    public void SaveLevel()
    {
        StorageManager.WriteFile("Campaigns/", "Level1Map", JsonUtility.ToJson(Map),true);
        StorageManager.WriteFile("Campaigns/", "Level1Player", JsonUtility.ToJson(Player), true);
    }

    public void SaveStartLevel()
    {
        Debug.Log("Saving Start Level.....");
        StorageManager.WriteFile("Campaigns/", "Map", JsonUtility.ToJson(Map), false);
        StorageManager.WriteFile("Campaigns/", "Player", JsonUtility.ToJson(Player), false);
        Debug.Log("Saved Start Level.....");
    }

    public void CreateBlankMap()
    {
        Debug.Log("Creating Blank Map.....");
        Map.CreateBlankMap();
        Debug.Log("Created Blank Map......");
    }
    public void LoadStartLevel()
    {
        Debug.Log("Loading Start Level.....");
        Map.DestroyGameObjects();
        JsonUtility.FromJsonOverwrite(StorageManager.ReadFile("Campaigns/", "Map", false), Map);
        JsonUtility.FromJsonOverwrite(StorageManager.ReadFile("Campaigns/", "Player", false), Player);
        Map.LoadGameObjects();
        Map.Init();
        Debug.Log("Loaded Start Level.....");
    }
    public void LoadLevel()
    {
        JsonUtility.FromJsonOverwrite(StorageManager.ReadFile("Campaigns/", "Level1Map", true),Map);
        JsonUtility.FromJsonOverwrite(StorageManager.ReadFile("Campaigns/", "Level1Player", true), Player);
        Map.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
