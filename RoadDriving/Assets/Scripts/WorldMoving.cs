using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMoving : MonoBehaviour
{
    public static float speed = -10.0f;
    private static float computedSpeed;
    private float boostingAt = 0;
    public static float GetSpeed() => computedSpeed;
    private float defaultFov = 34;
    
    void Start()
    {
        computedSpeed = speed;
    }

    void Update()
    {   
        if (!GameBehaviour.isGameStarted && GameBehaviour.isGameOver) return;
        
        gameObject.transform.Translate(computedSpeed * Time.deltaTime, 0, 0);
        ScoreCounter.AddScore();

        speed = -10.0f - (ScoreCounter.GetScore() / 5);

        Debug.Log("speed: " + speed);

        if (GameBehaviour.isGameStarted)
        {
            BoostImplementation();
        }        
    }
    
    void BoostImplementation() 
    {
        if (Input.GetButtonDown("P1_B1")) {
            computedSpeed = speed * 2;
            boostingAt = Time.time;
            GameBehaviour.isBoosting = true;
        }

        if (Time.time - boostingAt > 3 && boostingAt != 0) {
            computedSpeed = speed;
            boostingAt = 0;
            GameBehaviour.isBoosting = false;
        }

        if (Camera.main)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, defaultFov + (GameBehaviour.isBoosting ? 10 : 0), Time.deltaTime * 2);
        }
    }
}
