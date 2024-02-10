using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _graviti = 9.8f;
    private float _fallVelocity = 0;
    
    public float jumpForce;
    public float speed;
    private Vector3 _MoveVector;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }




    void FixedUpdate()
    {
        
          
                  
                


        _characterController.Move(_MoveVector * speed * Time.fixedDeltaTime);
        _fallVelocity += _graviti * Time.fixedDeltaTime;
        
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        
        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }    
        
       

    }

    private void Update()
    {
        _MoveVector = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            _MoveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _MoveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _MoveVector += transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _MoveVector -= transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        } 
    }
}
