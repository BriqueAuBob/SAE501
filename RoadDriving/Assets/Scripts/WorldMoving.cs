using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMoving : MonoBehaviour
{
    public static float speed = -10.0f;

    void Update()
    {
        gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
        ScoreCounter.AddScore();
    }
}
