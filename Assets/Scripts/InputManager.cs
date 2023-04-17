using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	
	public Rigidbody2D playerRigidbody;

    [SerializeField]
    private float _speed;

    private Vector2 _movement;

    void Update()
    {
        //_movement.x = Input.GetAxis("Horizontal");
        //_movement.y = Input.GetAxis("Vertical");

        float moveSpeed = _speed + Time.fixedDeltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + _movement * moveSpeed) ;
    }

    public void MouvPlayer(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    
}
