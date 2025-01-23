using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anatidae;

public class CarBehaviour : MonoBehaviour
{
    public float speed = -5.0f;
    public List<GameObject> wheels = new List<GameObject>();

    void Start()
    {
        int randomCar = Random.Range(0, transform.childCount); 
        var car = transform.GetChild(randomCar);
        car.gameObject.SetActive(true);

        foreach (Transform child in car)
        {
            if (child.name == "RL" || child.name == "RR" || child.name == "FL" || child.name == "FR")
            {
                wheels.Add(child.gameObject);
            }
        }

        try {
            car.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        } catch (System.Exception e) {
            Debug.LogWarning("No renderer found for car");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameBehaviour.isGameStarted) return;
        
        float forward = speed;
        forward *= Time.deltaTime;

        transform.Translate(forward, 0, 0);

        foreach (GameObject wheel in wheels)
        {
            wheel.transform.Rotate(1, 0, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameBehaviour.EndGame();
            
            var score = ScoreCounter.GetScore();
            if (Anatidae.HighscoreManager.IsHighscore(score))
            {
                if (Anatidae.HighscoreManager.PlayerName == null) {
                    Anatidae.HighscoreManager.ShowHighscoreInput(score);
                }
                else {
                    StartCoroutine(Anatidae.HighscoreManager.SetHighscore(Anatidae.HighscoreManager.PlayerName, score)); 
                }
            }
        }
    }
}
