using UnityEngine;

public class TotalCheckpointsPassed : MonoBehaviour
{
    [SerializeField] int allCheckpoints;
    public int checkpointsPassed;
    public bool allCheckpointsPassed;

    void Start()
    {
        allCheckpointsPassed = false;    
    }
    void Update()
    {
        if (checkpointsPassed == allCheckpoints)
        {
            allCheckpointsPassed = true;
        }
    }
}
