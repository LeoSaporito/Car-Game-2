using UnityEngine;
using TMPro;
using System;
public class TimerUI : MonoBehaviour
{
    [SerializeField] public bool isStart;
    [SerializeField] TextMeshProUGUI timerText;

    PlayerMovement playerMovementScript;
    TotalCheckpointsPassed totalCheckpointsPassedScript;

    public float timerProgress;
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
            print("Start");
        }
    }
    private void Update()
    {
        if (isStart == true)
        {
            timerProgress += Time.deltaTime;
            timerText.text = timerProgress.ToString();

            TimeSpan time = TimeSpan.FromSeconds(timerProgress);
            timerText.text = time.Seconds.ToString() + "." + time.Milliseconds.ToString();
        }

        else if (isStart == false && totalCheckpointsPassedScript.allCheckpointsPassed == true)
        {
            timerProgress += 0;
            playerMovementScript.TrackCompleted();
        }
    }
}
