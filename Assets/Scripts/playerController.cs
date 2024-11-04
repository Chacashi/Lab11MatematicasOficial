using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    Rigidbody _compRigidbody;
    [SerializeField] float jumpIntensity;
    [SerializeField] float speed;
    [SerializeField] float ImpactIntensityHorizontal;
    [SerializeField] float ImpactIntensityVertical;
    Quaternion targetAngle_90 = Quaternion.Euler(90, 90, 0);
    Quaternion targetAngle_Minus90 = Quaternion.Euler(-90, 90, 0);
    [SerializeField] Quaternion currentAngle;
    Vector3 jumpPosition;
    public static event Action OnDestroyPlayer;
    public static event Action OnWinPlayer;
    PlayerInput input;

    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        currentAngle = Quaternion.Euler(0, 90, 0);
    }

   

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle_90, 0.05f);
        _compRigidbody.AddForce(Vector3.right*speed * Time.deltaTime );
    }



    private void OnEnable()
    {
        ButtonUI.OnClickFinalizeInteractionUI += ActiveInput;
        ButtonUI.OnClickButtonUI += DesactiveInput;
    }

    private void OnDisable()
    {
        ButtonUI.OnClickFinalizeInteractionUI -= ActiveInput;
        ButtonUI.OnClickButtonUI -= DesactiveInput;
    }



    public void PressLeftClick(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle_Minus90, 0.9f);
            _compRigidbody.AddForce(Vector3.up * jumpIntensity);


        }

    }

    public void PressRightClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _compRigidbody.AddForce(Vector3.down * jumpIntensity);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.gameObject.tag == "Obstacule")
        {
            Destroy(gameObject);
            OnDestroyPlayer?.Invoke();
        }

        if (other != null && other.gameObject.tag == "Win")
        {
            Destroy(gameObject);
            OnWinPlayer?.Invoke();
        }

        if (other != null && other.gameObject.tag == "ImpulseUp")
        {
            _compRigidbody.AddForce(Vector3.left * ImpactIntensityHorizontal);
            _compRigidbody.AddForce(Vector3.up * ImpactIntensityVertical);
        }
        if (other != null && other.gameObject.tag == "ImpulseDown")
        {
            _compRigidbody.AddForce(Vector3.left * ImpactIntensityHorizontal);
            _compRigidbody.AddForce(Vector3.down * ImpactIntensityVertical);
        }




    }

    void DesactiveInput()
    {
        input.enabled = false;
    }

    void ActiveInput()
    {
        input.enabled = true;
    }
}
