using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour
{
    private Transform Cameratransform;
    [SerializeField] private bool invert;

    private void Awake()
    {
        Cameratransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        if (invert)
        {
            Vector3 dirCamera = (Cameratransform.position - transform.position).normalized;
            transform.LookAt(transform.position + dirCamera * -1);
        }
        else
        {
            transform.LookAt(Cameratransform);
        }
    }


}
