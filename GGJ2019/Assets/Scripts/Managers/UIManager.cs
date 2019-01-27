using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject splashPanel;
    public Button startButton;

    public GameObject countdownText;

    public GameObject timesUpPanel;
    public Button timesUpButton;

    private bool isLevelRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartButtonOnClick);

        countdownText.SetActive(false);

        timesUpPanel.SetActive(false);
        timesUpButton.onClick.AddListener(TimesUpButtonOnClick);
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

    private void StartButtonOnClick()
    {
        splashPanel.gameObject.SetActive(false);
        countdownText.SetActive(true);
        countdownText.GetComponent<Text>().text = "00:00:00";

        LevelManager.InitLevel(1);
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
        countdownText.SetActive(true);
        countdownText.GetComponent<Text>().text = "00:00:00";

        timesUpPanel.SetActive(false);
    }

    public void TimesUp()
    {
        countdownText.SetActive(false);
        timesUpPanel.SetActive(true);
    }
}
