using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMoving : MonoBehaviour
{
    public static float speed = -10.0f;
    private static float computedSpeed;
    private float boostingAt = 0;
    
    void Start()
    {
        computedSpeed = speed;
    }

    void Update()
    {
        if (GameBehaviour.isGameStarted)
        {
            BoostImplementation();
        }
        
        
        if (!GameBehaviour.isGameStarted && GameBehaviour.isGameOver) return;
        
        gameObject.transform.Translate(computedSpeed * Time.deltaTime, 0, 0);
        ScoreCounter.AddScore();
    }
    
    void BoostImplementation() 
    {
        if (Input.GetButtonDown("P1_B1")) {
            computedSpeed = speed * 2;
            boostingAt = Time.time;
        }

        if (Time.time - boostingAt > 3 && boostingAt != 0) {
            computedSpeed = speed;
            boostingAt = 0;
        }
    }
}
