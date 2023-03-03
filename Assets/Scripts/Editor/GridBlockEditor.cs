using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridBlock1))]
public class GridBlockEditor : Editor
{
    private SerializedProperty _selectedIndex;
    private GameObject[] _blockArray;

    private void OnEnable()
    {      
        _selectedIndex = serializedObject.FindProperty("_selectedIndex");
    }
    public override void OnInspectorGUI()
    {
        GridBlock1 script = (GridBlock1)target;
        _blockArray = script.blockTypes.gridBlocks;
        serializedObject.Update();

        GUILayout.Label("BlockType");

        if (_blockArray != null)
        {
            int newIndex = EditorGUILayout.Popup("Block Type", _selectedIndex.intValue, GetBlockNames());
            if(newIndex != _selectedIndex.intValue)
            {
                script.OnSelectionChanged(_selectedIndex.intValue);
            }
        }
        base.OnInspectorGUI();

        serializedObject.ApplyModifiedProperties();
    }

    private string[] GetBlockNames()
    {
        if (_blockArray == null) { return null; }

        string[] _blockNames = new string[_blockArray.Length];
        for (int i = 0; i < _blockArray.Length; i++)
        {
            _blockNames[i] = _blockArray[i].name;
        }

        return _blockNames;
    }



    //using UnityEditor;
    //using UnityEngine;
    //
    //[CustomEditor(typeof(MyScript))]
    //public class MyScriptEditor : Editor
    //{
    //    public override void OnInspectorGUI()
    //    {
    //        serializedObject.Update();
    //
    //        MyScript myScript = (MyScript)target;
    //
    //        GameObject newGameObject = (GameObject)EditorGUILayout.ObjectField("My Game Object", myScript.myGameObject, typeof(GameObject), true);
    //
    //        if (newGameObject != myScript.myGameObject)
    //        {
    //            // Swap the game object reference
    //            Undo.RecordObject(myScript, "Swap game object");
    //            myScript.myGameObject = newGameObject;
    //            EditorUtility.SetDirty(myScript);
    //        }
    //
    //        serializedObject.ApplyModifiedProperties();
    //    }
    //}

}
