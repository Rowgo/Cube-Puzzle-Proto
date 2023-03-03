using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int _width;
    private int _height;
    private GameObject[,] _gridArray;
    private GameObject _gridBlock = new GameObject("GridBlock");
    private GridBlock1 _gidblockClass;

    public Grid(int width, int height, BlockTypes blockTypes)
    {
        _gidblockClass = _gridBlock.AddComponent<GridBlock1>();
        _gidblockClass.blockTypes = blockTypes;
        
        if (_gridArray != null) { DestroyLevel(); }

        _width = width;
        _height = height;

        if (blockTypes.gridBlocks[0].TryGetComponent<Collider>(out Collider collider))
        {
            _gridArray = new GameObject[width, height];
            Vector3 collidersize = collider.bounds.extents * 2;

            for(int x = 0; x < _gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < _gridArray.GetLength(1); y++)
                {
                    _gridArray[x, y] = Object.Instantiate(_gridBlock, new Vector3(x + collidersize.x, 0, y + collidersize.y), Quaternion.identity);
                }
            }

        }

    }

    public void DestroyLevel()
    {
        if (_gridArray == null) return;

            for (int x = 0; x < _gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < _gridArray.GetLength(1); y++)
                {
                    Object.DestroyImmediate(_gridArray[x, y]);
                    _gridArray[x, y] = null;
                }
            }
    }

    public void DestroyGridObjectAt(int x, int y)
    {
        if (_gridArray[x, y] == null) return;
        
        Object.Destroy(_gridArray[x, y]);
        _gridArray[x, y] = null;
        
    }

    public void SetValue(int x, int y, int value)
    {
        //checks to see if x and y are within the bounds of the array.
        if (x <= 0 || y <= 0 || x > _width || y > _height) return;
        
    }
}
