using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 10.0f;
    private GameObject car;

    void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.name == "Car")
            {
                car = child.gameObject;
            }
        }
    }

    void Update()
    {
        float horizontal = (-Input.GetAxis("Horizontal")) * speed;
        horizontal *= Time.deltaTime;

        car.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, horizontal), ForceMode.Impulse);

        if (horizontal != 0)
        {
            car.transform.rotation = Quaternion.Lerp(car.transform.rotation, Quaternion.Euler(0, horizontal < 0 ? 10f : -10f, 0), 0.1f);
        } 
        else {
            car.transform.rotation = Quaternion.Lerp(car.transform.rotation, Quaternion.Euler(0, 0, 0), 0.1f);
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
