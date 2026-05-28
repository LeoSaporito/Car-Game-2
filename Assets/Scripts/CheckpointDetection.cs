using UnityEngine;
using TMPro;
public class CheckpointDetection : MonoBehaviour
{
    TotalCheckpointsPassed totalCheckpointsPassedScript;

    void Start()
    {
        totalCheckpointsPassedScript = FindFirstObjectByType<TotalCheckpointsPassed>();    
    }
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            totalCheckpointsPassedScript.checkpointsPassed++;
            Destroy(gameObject);
        }
    }

}
