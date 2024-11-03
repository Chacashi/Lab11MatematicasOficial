using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    Rigidbody _compRigidbody;
    [SerializeField] float jumpIntensity;
    [SerializeField] float speed;
  
    Vector3 jumpPosition;
    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }

    public void PressLeftClick(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            print("Aea");
            _compRigidbody.AddForce(Vector3.up * jumpIntensity );
            transform.Rotate(0,0,10 );
        }
       
    }

    public void PressRightClick(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            print("Gaaaa");
            _compRigidbody.AddForce(Vector3.down * jumpIntensity );
        }
    }

    

    private void FixedUpdate()
    {
        transform.Rotate(0,0,10*Time.deltaTime);
        _compRigidbody.AddForce(Vector3.right*speed * Time.deltaTime );
    }

}
