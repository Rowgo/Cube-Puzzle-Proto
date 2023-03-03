using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Generate Grid"))
        {
            GameManager gameManager = (GameManager)target;
            gameManager.GenerateLevelGrid();
        }
    }
}
