using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    public delegate void SpinCompleteDelegate();

    private SpinCompleteDelegate onSpinComplete;

    private float totalSpinAmount;
    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        float spinAddAmount = 360f * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, spinAddAmount, 0);
        Debug.Log(transform.eulerAngles.y);
        // transform.eulerAngles += new Vector3(0, spinAddAmount, 0);

        totalSpinAmount += spinAddAmount;
        if (totalSpinAmount >= 360)
        {
            isActive = false;
            onSpinComplete();
        }


    }
    // isActive = false;

    public void Spin(SpinCompleteDelegate onSpinComplete)
    {
        this.onSpinComplete = onSpinComplete;

        totalSpinAmount = 0f;
        isActive = true;
    }

}



