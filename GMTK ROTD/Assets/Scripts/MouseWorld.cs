using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld Instance;

    [SerializeField] private LayerMask mouseplaneLayerMask;

    private void Awake()
    {
        Instance = this;
    }
 
    private void Update()
    {
        transform.position = MouseWorld.GetPosition(); 
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, Instance.mouseplaneLayerMask);
        return raycastHit.point;
    }
}
