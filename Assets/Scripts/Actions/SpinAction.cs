using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    private float totalSpinAmount;

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        float spinAddAmount = 360f * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, spinAddAmount, 0);
        // Debug.Log(transform.eulerAngles.y);

        totalSpinAmount += spinAddAmount;
        if (totalSpinAmount >= 360)
        {
            isActive = false;
            onActionComplete();
        }


    }
    // isActive = false;

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;

        totalSpinAmount = 0f;
        isActive = true;
    }

    public override string GetActionName()
    {
        return "Spin";
    }

     public override List<GridPosition> GetValidActionGridPositionList()
    {
        GridPosition unitGridPosition = unit.GetGridPosition();

        return new List<GridPosition>
        {
            unitGridPosition
        };

    }


}



