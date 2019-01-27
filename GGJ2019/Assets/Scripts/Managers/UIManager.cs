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
    }

    void StartButtonOnClick()
    {
        splashPanel.gameObject.SetActive(false);
        countdownText.SetActive(true);
        countdownText.GetComponent<Text>().text = "01:00";

        LevelManager.InitLevel(1);
    }
}
