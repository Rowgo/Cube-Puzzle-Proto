using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _gridWidth;
    [SerializeField] private int _gridHeight;
    //[SerializeField] private GameObject _gameObject;
    [SerializeField] private BlockTypes _blockTypes;

    private Grid _levelGrid;

    public void GenerateLevelGrid()
    {
        if(_levelGrid != null) _levelGrid.DestroyLevel();
        _levelGrid = new Grid(_gridWidth, _gridHeight, _blockTypes);
    }
}
