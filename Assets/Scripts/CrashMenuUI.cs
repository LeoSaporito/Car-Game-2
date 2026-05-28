using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CrashMenuUI : MonoBehaviour
{
    [SerializeField] GameObject crashMenuUI;
    [SerializeField] float crashMenuDelay;
    [SerializeField] TextMeshProUGUI checkpointsPassedText;
    [SerializeField] GameObject checkpointsPassedUI;

    TotalCheckpointsPassed totalCheckpointsPassedScript;

    void Start()
    {
        crashMenuUI.SetActive(false);
        totalCheckpointsPassedScript = FindFirstObjectByType<TotalCheckpointsPassed>();
    }

    public void DisplayCrashMenuUI()
    {
        Invoke("CrashMenu", crashMenuDelay);
        checkpointsPassedUI.SetActive(false);
    }

    void CrashMenu()
    { 
        crashMenuUI.SetActive(true);
        checkpointsPassedText.text = totalCheckpointsPassedScript.checkpointsPassed.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);    
    }
}
