﻿using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject splashPanel;
    public Button splashButton;

    public GameObject startPanel;
    public Button startButton;

    public GameObject countdownText;

    public GameObject timesUpPanel;
    public Button timesUpButton;

    public GameObject theEndPanel;
    public Button theEndButton;

    private bool isLevelRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        splashPanel = GameObject.Find("SplashPanel");
        splashPanel.SetActive(true);
        splashButton = splashPanel.transform.Find("SplashButton").GetComponent<Button>();
        splashButton.onClick.AddListener(SplashButtonOnClick);

        startPanel = GameObject.Find("StartPanel");
        startPanel.SetActive(false);
        startButton.onClick.AddListener(StartButtonOnClick);

        timesUpPanel.SetActive(false);
        timesUpButton.onClick.AddListener(TimesUpButtonOnClick);

        theEndPanel = GameObject.Find("TheEndPanel");
        theEndPanel.SetActive(false);
        theEndButton = theEndPanel.transform.Find("TheEndButton").GetComponent<Button>();
        theEndButton.onClick.AddListener(TheEndButtonOnClick);

        countdownText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.IsLevelRunning())
        {
            UpdateCountdown();
        }

        if (isLevelRunning && !LevelManager.IsLevelRunning())
        {
            isLevelRunning = false;
            TimesUp();
        }
    }

    private void ShowSplashScreen()
    {
        splashPanel.SetActive(true);
        startPanel.SetActive(false);
        timesUpPanel.SetActive(false);
        theEndPanel.SetActive(false);
        countdownText.SetActive(false);

        LevelManager.InitLevel(1);
    }

    private void SplashButtonOnClick()
    {
        splashPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    private void StartButtonOnClick()
    {
        startPanel.SetActive(false);
        countdownText.SetActive(true);
        countdownText.GetComponent<Text>().text = "00:00:00";

        LevelManager.StartLevel();
        isLevelRunning = true;
    }

    private void UpdateCountdown()
    {
        // Time.time - time in seconds
        float timeElapsed = Time.time - LevelManager.levelStartTimeInSeconds;
        float timeRemaining = LevelManager.levelMaxTimeInSeconds - timeElapsed;

        string countdownString = "00:00:00";
        if (timeRemaining > 0)
        {
            string minutes = timeRemaining > 60 ? Mathf.FloorToInt(timeRemaining / 60).ToString("00") : "00";
            string seconds = timeRemaining > 60 ? ((int)(timeRemaining % 60)).ToString("00") : ((int)timeRemaining).ToString("00");
            string milliseconds = ((int)((timeRemaining % 1) * 1000) / 100).ToString("00");

            countdownString = minutes + ":" + seconds + ":" + milliseconds;
        }

        countdownText.GetComponent<Text>().text = countdownString;
    }

    private void TimesUpButtonOnClick()
    {
        countdownText.SetActive(false);
        timesUpPanel.SetActive(false);

        if (LevelManager.currentLevel < LevelManager.numLevels)
        {
            startPanel.gameObject.SetActive(true);
            LevelManager.InitNextLevel();
        }
        else
        {
            // THE END!!!
            theEndPanel.SetActive(true);
        }
    }

    public void TimesUp()
    {
        countdownText.SetActive(false);
        timesUpPanel.SetActive(true);
    }

    private void TheEndButtonOnClick()
    {
        ShowSplashScreen();
    }
}
