using UnityEngine;
using TMPro;
using System;

public class FinishedMenuUI : MonoBehaviour
{
    [SerializeField] float finishUIDelay;
    
    [SerializeField] GameObject finishUI;
    [SerializeField] GameObject checkpointsUI;
    [SerializeField] GameObject timerUI;
    [SerializeField] GameObject unlockUI;        
    [SerializeField] GameObject starOne;
    [SerializeField] GameObject starTwo;
    [SerializeField] GameObject starThree;

    [SerializeField] TextMeshProUGUI finishTimeText;
    [SerializeField] TextMeshProUGUI checkpointsPassedText;

    TimerUI timerUIScript;
    TotalCheckpointsPassed totalCheckpointsPassedScript;
    void Start()
    {
        timerUIScript = FindFirstObjectByType<TimerUI>();
        totalCheckpointsPassedScript = FindFirstObjectByType<TotalCheckpointsPassed>();
        finishUI.SetActive(false);
    }

    public void DisplayFinishUI()
    {
        Invoke("FinishUI", finishUIDelay);
        checkpointsUI.SetActive(false);
        timerUI.SetActive(false);
    }

    void FinishUI()
    {
        TimeSpan finalTime = TimeSpan.FromSeconds(timerUIScript.timerProgress);
        
        finishTimeText.text = "Time: " + finalTime.Seconds.ToString() + "." + finalTime.Milliseconds.ToString();
        
        checkpointsPassedText.text = totalCheckpointsPassedScript.checkpointsPassed.ToString();
        
        finishUI.SetActive(true);

        if (timerUIScript.timerProgress <= 20)
        {
            starOne.SetActive(true);
            starTwo.SetActive(true);
            starThree.SetActive(true);
            
            unlockUI.SetActive(false);
        }
        else if (timerUIScript.timerProgress <= 25)
        {
            starOne.SetActive(true);
            starTwo.SetActive(true);

            unlockUI.SetActive(false);
        }
        else if (timerUIScript.timerProgress <= 30)
        {
            starOne.SetActive(true);
        }
    }
}
