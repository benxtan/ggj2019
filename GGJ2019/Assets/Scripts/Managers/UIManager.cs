using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject splashPanel;
    public Button splashButton;

    public GameObject startPanel;
    public Button startButton;
    public Text startLevelText;

    public GameObject timesUpPanel;
    public Button timesUpButton;

    public GameObject theEndPanel;
    public Button theEndButton;

    public GameObject levelWinPanel;
    public Text levelWinText;
    public Button levelWinButton;

    public GameObject countdownText;
    public static Text peopleScoreText;

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
        startLevelText = startButton.transform.Find("StartLevelText").GetComponent<Text>();

        timesUpPanel.SetActive(false);
        timesUpButton.onClick.AddListener(TimesUpButtonOnClick);

        theEndPanel = GameObject.Find("TheEndPanel");
        theEndPanel.SetActive(false);
        theEndButton = theEndPanel.transform.Find("TheEndButton").GetComponent<Button>();
        theEndButton.onClick.AddListener(TheEndButtonOnClick);

        levelWinPanel = GameObject.Find("LevelWinPanel");
        levelWinPanel.SetActive(false);
        levelWinButton = levelWinPanel.transform.Find("LevelWinButton").GetComponent<Button>();
        levelWinButton.onClick.AddListener(LevelWinButtonOnClick);
        levelWinText = levelWinButton.transform.Find("LevelWinText").GetComponent<Text>();

        peopleScoreText = GameObject.Find("PeopleScoreText").GetComponent<Text>();
        peopleScoreText.gameObject.SetActive(false);

        countdownText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.isLevelRunning)
        {
            UpdateCountdown();
        }

        if (isLevelRunning && !LevelManager.isLevelRunning)
        {
            isLevelRunning = false;

            if (LevelManager.levelFinishedTimeInSeconds > 0)
            {
                ShowLevelWinPanel();
            }
            else
            {
                ShowTimesUpPanel();
            }
        }
    }

    private void ShowSplashScreen()
    {
        splashPanel.SetActive(true);
        startPanel.SetActive(false);
        timesUpPanel.SetActive(false);
        theEndPanel.SetActive(false);
        countdownText.SetActive(false);
        peopleScoreText.gameObject.SetActive(false);

        LevelManager.InitLevel(1);
    }

    private void SplashButtonOnClick()
    {
        splashPanel.SetActive(false);
        startPanel.SetActive(true);
        startLevelText.text = "LEVEL 1";
    }

    private void StartButtonOnClick()
    {
        startPanel.SetActive(false);
        countdownText.SetActive(true);
        countdownText.GetComponent<Text>().text = "00:00:00";
        
        LevelManager.StartLevel();
        isLevelRunning = true;

        UpdatePeopleScore();
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
        peopleScoreText.gameObject.SetActive(false);
        timesUpPanel.SetActive(false);

        if (LevelManager.currentLevel < LevelManager.numLevels)
        {
            startLevelText.text = "LEVEL " + (LevelManager.currentLevel + 1);
            startPanel.SetActive(true);
            
            LevelManager.InitNextLevel();
        }
        else
        {
            // THE END!!!
            theEndPanel.SetActive(true);
        }
    }

    public void ShowLevelWinPanel()
    {
        float timeElapsed = LevelManager.levelMaxTimeInSeconds - LevelManager.levelFinishedTimeInSeconds;
        int minutes = (int) Mathf.Floor(timeElapsed / 60);
        int seconds = (int) Mathf.RoundToInt(timeElapsed % 60);

        string timeString = minutes > 0 ? minutes.ToString() + "m" : "";
        timeString += seconds + "s";

        // > 90 = 3 stars
        // > 84 = 2 stars
        // > 50 = 1 star
        float score = Mathf.RoundToInt((LevelManager.levelFinishedTimeInSeconds / LevelManager.levelMaxTimeInSeconds) * 100);
        Debug.Log("Score:" + score);
        string stars = "";
        if (score >= 90) stars = "* * *";
        else if (score >= 84) stars = "* *";
        else if (score >= 50) stars = "*";
        else stars = "-";

        levelWinText.text = "CONGRATULATIONS!\r\n" +
            "You got " +  LevelManager.numLevelPeople + " " + (LevelManager.numLevelPeople == 1 ? "person" : " people") + " safely home\r\n" +
            "in " + timeString + "\r\n" +
            stars;
        levelWinPanel.SetActive(true);
    }

    public void ShowTimesUpPanel()
    {
        timesUpPanel.SetActive(true);
    }

    private void TheEndButtonOnClick()
    {
        ShowSplashScreen();
    }

    private void LevelWinButtonOnClick()
    {
        levelWinPanel.SetActive(false);
        TimesUpButtonOnClick();
    }

    public static void UpdatePeopleScore()
    {
        peopleScoreText.gameObject.SetActive(true);
        peopleScoreText.text = PeopleManager.GetNumPeopleAtHome() + "/" + LevelManager.numLevelPeople;
    }
}
