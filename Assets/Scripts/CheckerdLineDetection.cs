using UnityEngine;

public class CheckerdLineDetection : MonoBehaviour
{
    [SerializeField] bool isStart;

    PlayerMovement playerMovementScript;
    TotalCheckpointsPassed totalCheckpointsPassedScript;

    public float progress;
    void Start()
    {
        playerMovementScript = FindFirstObjectByType<PlayerMovement>();
        totalCheckpointsPassedScript = FindFirstObjectByType<TotalCheckpointsPassed>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isStart = !isStart;
        }
    }
    private void Update()
    {
        if (isStart == true)
        {
            progress += Time.deltaTime;
            Debug.Log("Race Started");
        }

        if (isStart == false && totalCheckpointsPassedScript.allCheckpointsPassed == true)
        {
            Debug.Log(progress);
        }
    }
}
