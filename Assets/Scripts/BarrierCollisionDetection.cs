using UnityEngine;

public class BarrierCollisionDetection : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticles;
    PlayerMovement playerMovementScript;
    TimerUI timerUIScript;

    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
        timerUIScript = FindFirstObjectByType<TimerUI>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Barrier");

        if (collision.gameObject.layer == layerIndex)
        {
            crashParticles.Play();
            playerMovementScript.DisableControls();
            timerUIScript.isStart = false;
        }
    }
}
