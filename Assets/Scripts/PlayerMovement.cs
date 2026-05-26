using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float currentSpeed;
    [SerializeField] public float accelerateSpeed;
    [SerializeField] float speedLimitMax;
    [SerializeField] float speedLimitMin;
    [SerializeField] float stopLimit;

    Vector2 directionalInput;
    Vector3 position;

    [SerializeField] float rotateSpeed;
    
    float currentRotation;
    float rotationDirection;

    public bool onOffroad;

    void Start()
    {
        onOffroad = false;
    }

    void FixedUpdate()
    {
        CarAccelerating();
        CarTurning();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        directionalInput = context.ReadValue<Vector2>();
    }

    public void CarAccelerating()
    {
        if (directionalInput.y > 0 && onOffroad == false)
        {
            currentSpeed += accelerateSpeed;

            if (currentSpeed >= speedLimitMax)
            {
                currentSpeed = speedLimitMax;
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
        else if (directionalInput.y == 0 || onOffroad == true)
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
}
