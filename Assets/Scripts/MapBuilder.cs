using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Map))]
[CanEditMultipleObjects]
public class MapBuilder : Editor
{
    SerializedProperty GroundColor;
    SerializedProperty PathColor;
    SerializedProperty XSize;
    SerializedProperty ZSize;
    SerializedProperty CellSpace;


    private void OnEnable()
    {
        GroundColor = serializedObject.FindProperty("GroundColor");
        PathColor = serializedObject.FindProperty("PathColor");
        XSize = serializedObject.FindProperty("XSize");
        ZSize = serializedObject.FindProperty("ZSize");
        CellSpace = serializedObject.FindProperty("CellSpace");
    }

    

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(GroundColor);
        EditorGUILayout.PropertyField(PathColor);
        EditorGUILayout.PropertyField(XSize);
        EditorGUILayout.PropertyField(ZSize);
        EditorGUILayout.PropertyField(CellSpace);

        serializedObject.ApplyModifiedProperties();
    }
}
