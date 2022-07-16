using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitActionSystem : MonoBehaviour
{
    

    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;

    InputMaster input;

    private void Awake()
    {
        input = new InputMaster();

        input.PlayerInputs.LeftClick.started += context =>
        {
            LeftClick(context);
        };
        input.PlayerInputs.RightClick.started += context =>
        {
            RightClick(context);
        };
    }
    private void Update()
    {
        
    }

    private void RightClick(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            HandleUnitSelection();
        }
    }

    private void LeftClick(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }

    private void HandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                selectedUnit = unit;
            }
        }
    }

    private void OnEnable()
    {
        input.PlayerInputs.Enable();
    }
    private void OnDisable()
    {
        input.PlayerInputs.Disable();
    }
}
