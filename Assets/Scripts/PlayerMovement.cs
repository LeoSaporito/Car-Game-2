using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float currentSpeed;
    [SerializeField] public float accelerateSpeed;
    [SerializeField] float currentSpeedLimit;
    [SerializeField] float speedLimitMax;
    [SerializeField] float speedLimitMin;
    [SerializeField] float offroadSpeed;
    [SerializeField] float stopLimit;
    [SerializeField] float rotateSpeed;

    Vector2 directionalInput;
    Vector3 position;
    
    float currentRotation;
    float rotationDirection;

    public bool onOffroad;

    bool canControlPlayer;


    void Start()
    {
        onOffroad = false;
        canControlPlayer = true;
        currentSpeedLimit = speedLimitMax;
    }

    void FixedUpdate()
    {
        if (canControlPlayer)
        { 
            CarAccelerating();
            CarTurning();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        directionalInput = context.ReadValue<Vector2>();
    }

    public void CarAccelerating()
    {
        if (onOffroad == true)
        {
            currentSpeedLimit = offroadSpeed;
            currentSpeed -= accelerateSpeed * 4;

            if (currentSpeed <= offroadSpeed)
            { 
            currentSpeed = offroadSpeed;
            }
        }
        else if(onOffroad == false) 
        {
            currentSpeedLimit = speedLimitMax;
        }

        if (directionalInput.y > 0 && onOffroad == false)
        {
            currentSpeed += accelerateSpeed;

            if (currentSpeed >= currentSpeedLimit)
            {
                currentSpeed = currentSpeedLimit;
            }
        }
        else if (directionalInput.y < 0 && onOffroad == false)
        {
            currentSpeed -= accelerateSpeed;

            if (currentSpeed <= speedLimitMin)
            {
                currentSpeed = speedLimitMin;
            }
        }
        else if (directionalInput.y == 0)
        {
            if (currentSpeed > 0.1)
            {
                currentSpeed -= accelerateSpeed * 2;
            }
            else if (currentSpeed < -0.1)
            {
                currentSpeed += accelerateSpeed * 2;
            }
            else
            {
                currentSpeed *= 0;
            }
        }

        position = transform.position;

        position += currentSpeed * Time.deltaTime * transform.up;
        position.z = 0;

        transform.position = position;
    }

    public void CarTurning()
    {
        if (directionalInput.x > 0)
        {
            rotationDirection = -1;
        }
        else if (directionalInput.x < 0)
        {
            rotationDirection = 1;
        }
        else
        {
            rotationDirection = 0;
        }
        currentRotation = rotateSpeed * Time.deltaTime * rotationDirection;

        transform.Rotate(0, 0, currentRotation);
    }

    public void DisableControls()
    {
        canControlPlayer = false;
    }
}
