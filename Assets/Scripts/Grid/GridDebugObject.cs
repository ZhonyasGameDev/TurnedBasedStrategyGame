using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro gridObjectInfo;
    private GridObject gridObject;

    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
        // gridObjectInfo.text = gridObject.gridPosition.ToString();
    }

    private void Update()
    {
        gridObjectInfo.text = gridObject.ToString();
    }


}
