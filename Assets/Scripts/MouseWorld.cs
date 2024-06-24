using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public static MouseWorld Instance { get; private set; }
    [SerializeField] private LayerMask mouseLayerMask;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("There is more than one Instance of MouseWorld");
        }
        Instance = this;

    }

    void Update()
    {
        // transform.position = MouseWorld.GetPosition();
    }

    public static Vector3 GetPosition()
    {
        // Fire a ray from the Main Camera to the current Mouse Position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, Instance.mouseLayerMask);
        return raycastHit.point;
    }
    
}
