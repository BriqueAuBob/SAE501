using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject logo;
    public Image boostPanel;
    public GameObject speed;
    private Dictionary<string, List<GameObject>> panels = new Dictionary<string, List<GameObject>>();
    private int selectedButton = 0;
    private float lastTime = 0;
    private string currentMenu = "startPanel";

    private float logoY = 0;
    private float logoScale = 0;

    public AudioSource buttonSelectAudio;
    public AudioSource buttonClickAudio;
    
    void Start()
    {
        startPanel.SetActive(true);
        boostPanel.color = new Color(boostPanel.color.r, boostPanel.color.g, boostPanel.color.b, 0);

        getPanelButtons("startPanel", startPanel);
        getPanelButtons("gameOverPanel", gameOverPanel);
        
        SelectButton(0);

        logoY = logo.transform.position.y;
        logoScale = logo.transform.localScale.y;
    }

    void Update()
    {
        if (GameBehaviour.isGameStarted || GameBehaviour.isGameOver)
        {
            startPanel.SetActive(false);
            logo.transform.localScale = Vector3.Lerp(logo.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5);
            logo.transform.position = Vector3.Lerp(logo.transform.position, new Vector3(logo.transform.position.x, 1000f, logo.transform.position.z), Time.deltaTime * 5);
        }
        else
        {
            MenuButtonSelector("startPanel");
        }

        if (GameBehaviour.isGameOver && GameBehaviour.shouldDisplayGameOver)
        {
            currentMenu = "gameOverPanel";
            var shouldSelect0 = !gameOverPanel.activeSelf;
            gameOverPanel.SetActive(true);
            MenuButtonSelector("gameOverPanel");
            if (shouldSelect0)
            {
                SelectButton(0);
            }

            logo.transform.localScale = Vector3.Lerp(logo.transform.localScale, new Vector3(logoScale, logoScale, logoScale), Time.deltaTime * 5);
            logo.transform.position = Vector3.Lerp(logo.transform.position, new Vector3(logo.transform.position.x, logoY, logo.transform.position.z), Time.deltaTime * 5);
        }
        
        if(GameBehaviour.isBoosting && GameBehaviour.isGameStarted)
        {
            boostPanel.color = new Color(boostPanel.color.r, boostPanel.color.g, boostPanel.color.b, Mathf.Lerp(boostPanel.color.a, 1, Time.deltaTime * 5));
        }
        else
        {
            boostPanel.color = new Color(boostPanel.color.r, boostPanel.color.g, boostPanel.color.b, Mathf.Lerp(boostPanel.color.a, 0, Time.deltaTime * 5));
        }

        if(GameBehaviour.isGameStarted && !GameBehaviour.isGameOver)
        {
            speed.SetActive(true);

            var text = speed.GetComponent<TextMeshProUGUI>().text;
            var currentSpeedText = text.Substring(0, text.IndexOf(" "));
            var speedText = 50 + Math.Abs(WorldMoving.GetSpeed());
            var lerpSpeed = Math.Round(Mathf.Lerp(int.Parse(currentSpeedText), speedText, Time.deltaTime * 10));

            speed.GetComponent<TextMeshProUGUI>().text = lerpSpeed.ToString() + " km/h";
        }
        else
        {
            speed.SetActive(false);
        }
    }

    private void MenuButtonSelector(string panelName)
    {
        var axis = Input.GetAxis("P1_Vertical");

        if (lastTime + 0.4f > Time.time) return;
        
        var buttons = panels[panelName];
        if (axis > 0)
        {
            SelectButton(selectedButton == 0 ? buttons.Count - 1 : selectedButton - 1);
            lastTime = Time.time;
        }
        else if (axis < 0)
        {
            SelectButton(selectedButton == buttons.Count - 1 ? 0 : selectedButton + 1);
            lastTime = Time.time;
        }
        
        if (Input.GetButtonDown("P1_B2"))
        {
            buttons[selectedButton].GetComponent<Button>().onClick.Invoke();
            buttonClickAudio.Play();
            lastTime = Time.time;
        }
    }

    private void SelectButton(int index)
    {
        var buttons = panels[currentMenu];
        buttons[selectedButton].transform.localScale = new Vector3(1, 1, 1);
        buttons[selectedButton].GetComponent<Button>().image.color = Color.gray;
        selectedButton = index;
        buttons[selectedButton].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        buttons[selectedButton].GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
        buttonSelectAudio.Play();
    }

    private void getPanelButtons(string panelName, GameObject panel)
    {
        var buttons = new List<GameObject>();
        for (int i = 0; i < panel.transform.childCount; i++)
        {
            buttons.Add(panel.transform.GetChild(i).gameObject);
        }
        panels.Add(panelName, buttons);
    }
}
