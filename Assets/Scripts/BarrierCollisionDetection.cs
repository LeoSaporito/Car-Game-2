using UnityEngine;

public class BarrierCollisionDetection : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticles;
    PlayerMovement playerMovementScript;

    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Barrier");

        if (collision.gameObject.layer == layerIndex)
        {
            crashParticles.Play();
            playerMovementScript.DisableControls();
        }
    }
}
