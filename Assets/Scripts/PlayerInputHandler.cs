using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public PlayerInputActions playerInputActions;

    InputAction move;
    InputAction fire;

    [SerializeField]
    PlayerMovement playerMovement;
    [SerializeField]
    PlayerGunController gunController;
    
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }



    private void FixedUpdate()
    {
        Move();
    }



    void Move()
    {

        playerMovement.moveDirection =  Vector2.ClampMagnitude(move.ReadValue<Vector2>(),1f);
        playerMovement.Move();
        

    }

    void Fire(InputAction.CallbackContext ctx)
    {
        gunController.StartFire();
    }


    void StopFire(InputAction.CallbackContext ctx)
    {
        gunController.StopFire();
    }

    private void OnEnable()
    {
        move = playerInputActions.Player.Move;
        fire = playerInputActions.Player.Fire;

      

        move.Enable();
        fire.Enable();

        
        fire.performed += Fire;
        fire.canceled += StopFire;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();

        
        fire.performed -= Fire;
        fire.canceled -= StopFire;
    }
}
