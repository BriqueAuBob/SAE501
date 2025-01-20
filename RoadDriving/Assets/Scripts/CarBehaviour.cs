using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    public float speed = -5.0f;

    void Start()
    {
        speed = Random.Range(-4.0f, -6.0f);
        GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        float forward = speed;
        forward *= Time.deltaTime;

        transform.Translate(forward, 0, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameBehaviour.RestartGame();
        }
    }
}
