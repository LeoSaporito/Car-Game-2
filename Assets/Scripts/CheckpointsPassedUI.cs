using TMPro;
using UnityEngine;

public class CheckpointsPassedUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI checkpointText;

    TotalCheckpointsPassed totalCheckpointsPassedScript;

    void Start()
    {
        totalCheckpointsPassedScript = FindFirstObjectByType<TotalCheckpointsPassed>();    
    }
    void Update()
    {
        checkpointText.text = totalCheckpointsPassedScript.checkpointsPassed + "/6";
    }
}
