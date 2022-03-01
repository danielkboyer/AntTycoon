using Assets.Scripts.PersistentStorage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Map Map;
    public Player Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void SaveLevel()
    {
        StorageManager.WriteFile("Campaigns/", "Level1Map", JsonUtility.ToJson(Map),true);
        StorageManager.WriteFile("Campaigns/", "Level1Player", JsonUtility.ToJson(Player), true);
    }

    void SaveStartLevel()
    {
        StorageManager.WriteFile("Campaigns/", "Map", JsonUtility.ToJson(Map), false);
        StorageManager.WriteFile("Campaigns/", "Player", JsonUtility.ToJson(Player), false);
    }
    void LoadStartLevel()
    {
        JsonUtility.FromJsonOverwrite(StorageManager.ReadFile("Campaigns/", "Map", false), Map);
        JsonUtility.FromJsonOverwrite(StorageManager.ReadFile("Campaigns/", "Player", false), Player);
    }
    void LoadLevel()
    {
        JsonUtility.FromJsonOverwrite(StorageManager.ReadFile("Campaigns/", "Level1Map", true),Map);
        JsonUtility.FromJsonOverwrite(StorageManager.ReadFile("Campaigns/", "Level1Player", true), Player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
