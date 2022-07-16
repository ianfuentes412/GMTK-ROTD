using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }

    public event EventHandler OnSelectedUnitChange;

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

        if (Instance != null)
        {
            Debug.LogError("There's more than on UnitActionSystem! " + transform + "-" + Instance);
            Destroy(gameObject);

            return;
        }

        Instance = this; 
    }
    private void Update()
    {
        
    }

    private void RightClick(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            TryHandleUnitSelection();
        }
    }

    private void LeftClick(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }

    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                
                SetSelectedUnit(unit);
                return true;
            }
        }
        return false;
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        OnSelectedUnitChange?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
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
