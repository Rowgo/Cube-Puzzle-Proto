using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBlock1 : MonoBehaviour
{
    [HideInInspector] public BlockTypes blockTypes;


    [HideInInspector][SerializeField] private int _selectedIndex = 0;

    public void OnSelectionChanged(int newIndex)
    {

    }

    //public GameObject[] GridBlocks
    //{
    //    get { return blockTypes.gridBlocks; }
    //    set { blockTypes.gridBlocks = value; }
    //}
    //
    //public GameObject SelectedGameObject
    //{
    //    get { return blockTypes.gridBlocks[_selectedIndex]; }
    //    set
    //    {
    //        for (int i = 0; i < blockTypes.gridBlocks.Length; i++)
    //        {
    //            if (blockTypes.gridBlocks[i] == value)
    //            {
    //                _selectedIndex = i;
    //                return;
    //            }
    //        }
    //    }
    //}
    //
    //private void OnValidate()
    //{
    //    if (_selectedIndex >= blockTypes.gridBlocks.Length)
    //    {
    //        _selectedIndex = 0;
    //    }
    //}
}
