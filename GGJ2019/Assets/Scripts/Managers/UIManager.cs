using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject splashPanel;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartButtonOnClick);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void StartButtonOnClick()
    {
        splashPanel.gameObject.SetActive(false);

        LevelManager.InitLevel(1);
    }
}
