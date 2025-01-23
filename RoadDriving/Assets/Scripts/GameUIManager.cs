using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameObject startPanel;
    private List<GameObject> menuButtons;
    private int selectedButton = 0;
    private float lastTime = 0;
    
    void Start()
    {
        startPanel.SetActive(true);
        
        menuButtons = new List<GameObject>();
        for (int i = 0; i < startPanel.transform.childCount; i++)
        {
            menuButtons.Add(startPanel.transform.GetChild(i).gameObject);
        }
        SelectButton(0);
    }

    void Update()
    {
        if (GameBehaviour.isGameStarted || GameBehaviour.isGameOver)
        {
            startPanel.SetActive(false);
        }
        else
        {
            MenuButtonSelector();
        }    
    }

    private void MenuButtonSelector()
    {
        var axis = Input.GetAxis("P1_Vertical");

        if (lastTime + 0.2f > Time.time) return;
        
        if (axis > 0)
        {
            SelectButton(selectedButton == 0 ? menuButtons.Count - 1 : selectedButton - 1);
            lastTime = Time.time;
        }
        else if (axis < 0)
        {
            SelectButton(selectedButton == menuButtons.Count - 1 ? 0 : selectedButton + 1);
            lastTime = Time.time;
        }
        
        if (Input.GetButtonDown("P1_B2"))
        {
            menuButtons[selectedButton].GetComponent<Button>().onClick.Invoke();
            lastTime = Time.time;
        }
    }

    private void SelectButton(int index)
    {
        menuButtons[selectedButton].transform.localScale = new Vector3(1, 1, 1);
        selectedButton = index;
        menuButtons[selectedButton].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
}
