using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject splashPanel;
    public Button startButton;
    public GameObject countdownText;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartButtonOnClick);
        countdownText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.currentLevel > 0)
        {
            // Time.time - time in seconds
            float timeElapsed = Time.time - LevelManager.levelStartTimeInSeconds;
            float timeRemaining = LevelManager.levelMaxTimeInSeconds - timeElapsed;

            
            string minutes = timeRemaining > 60 ? Mathf.FloorToInt(timeRemaining / 60).ToString() : "00";
            string seconds = timeRemaining > 60 ? ((int)(timeRemaining % 60)).ToString() : ((int)timeRemaining).ToString();
            string milliseconds = ((int)((timeRemaining % 1) * 1000) / 100).ToString("00");

            countdownText.GetComponent<Text>().text = minutes + ":" + seconds + ":" + milliseconds;
        }
    }

    void StartButtonOnClick()
    {
        splashPanel.gameObject.SetActive(false);
        countdownText.SetActive(true);
        countdownText.GetComponent<Text>().text = "00:00:00";

        LevelManager.InitLevel(1);
    }
}
