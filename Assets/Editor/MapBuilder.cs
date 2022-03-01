using Assets.Scripts.BlockInfos;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
[CanEditMultipleObjects]
public class MapBuilder : Editor
{
    private bool paint;
    private bool addFood;
    Color GroundColor;
    Color PathColor;
    int XSize;
    int ZSize;
    float CellSpace;

    Player player;
    Map map;
    private void OnEnable()
    {
        map = ((GameManager)target).Map;
        player = ((GameManager)target).Player;
        GroundColor = map.GroundColor;
        PathColor = map.PathColor;
        XSize = map.XSize;
        ZSize = map.ZSize;
        CellSpace = map.CellSpace;
    }


    private void OnSceneGUI()
    {
        HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
        Event e = Event.current;
        
        if ((e.type == EventType.MouseDown || e.type == EventType.MouseDrag ) && e.button == 0 && paint)
        {
            RaycastHit hit;
            var ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Map")
                {

                    var pos = hit.transform.InverseTransformPoint(hit.point);
                    map.Paint(pos.x, pos.z, 1);
                    
                }
            }
        }

        if ((e.type == EventType.MouseDown || e.type == EventType.MouseDrag) && e.button == 0 && addFood)
        {
            RaycastHit hit;
            var ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Map")
                {

                    var pos = hit.transform.InverseTransformPoint(hit.point);
                    map.AddBlockInfo(pos.x, pos.z,new Food(new Vector3(pos.x,pos.y,pos.z)));

                }
            }
        }
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GameManager gameManager = (GameManager)target;
        EditorGUILayout.ColorField(GroundColor);
        EditorGUILayout.ColorField(PathColor);
        EditorGUILayout.IntField(XSize);
        EditorGUILayout.IntField(ZSize);
        EditorGUILayout.FloatField(CellSpace);
        EditorGUILayout.ObjectField("Script: ",MonoScript.FromMonoBehaviour(map),typeof(Map),true);
        EditorGUILayout.ObjectField("Script: ", MonoScript.FromMonoBehaviour(player), typeof(Player), true);
        if (GUILayout.Button("Load Map"))
        {
            gameManager.LoadStartLevel();
        }
        if(GUILayout.Button("Save Map"))
        {
            gameManager.SaveStartLevel();
        }
        if(GUILayout.Button("Create Blank Map"))
        {
            gameManager.CreateBlankMap();
        }
        if (GUILayout.Toggle(paint, "Paint"))
        {
            paint = true;
            addFood = false;
        }
        else
        {
            paint = false;
        }

        if(GUILayout.Toggle(addFood,"Add Food"))
        {
            paint = false;
            addFood = true;
        }
        else
        {
            addFood = false;
        }
        serializedObject.ApplyModifiedProperties();
    }
}
