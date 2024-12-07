using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    public event EventHandler OnStartMoving;
    public event EventHandler OnStopMoving;
    [SerializeField] private int maxMoveDistance = 4;

    private const string IS_WALKING = "IsWalking";
    private Vector3 targetPosition;

    protected override void Awake()
    {
        base.Awake();
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        Vector3 moveDirection = (targetPosition - transform.position).normalized;


        float stoppingDistance = 0.1f;

        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            float moveSpeed = 4f;
            transform.position += moveSpeed * Time.deltaTime * moveDirection;

            OnStartMoving.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnStopMoving.Invoke(this, EventArgs.Empty);

            ActionCompleted();
        }

        //Rotate to the direction
        float rotateSpeed = 5f;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        ActionStart(onActionComplete);
        targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);

        OnStartMoving?.Invoke(this, EventArgs.Empty);
    }

    // A list of grid positions for all of the valid actions for this specific action.
    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = unit.GetGridPosition();

        for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    // Inside of the grid bounds
                    continue;
                }

                if (unitGridPosition == testGridPosition)
                {
                    // Same Grid Position where the unit is already at
                    continue;
                }

                if (LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                {
                    // Grid position already ocuppied with another Unit
                    continue;
                }

                validGridPositionList.Add(testGridPosition);
                // Debug.Log(testGridPosition);

            }
        }

        return validGridPositionList;
    }

    public override string GetActionName()
    {
        return "Move";
    }

}
