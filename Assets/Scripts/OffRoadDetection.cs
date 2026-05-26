using UnityEngine;

public class OffRoadDetection : MonoBehaviour
{
    PlayerMovement playerMovementScript;
    [SerializeField] float offroadSpeed;

    void Start()
    {
        playerMovementScript = FindFirstObjectByType<PlayerMovement>();    
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Off Road");

        if (collision.gameObject.layer == layerIndex)
        {
            playerMovementScript.onOffroad = true;            
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerMovementScript.onOffroad = false;
    }
}
