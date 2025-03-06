using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 10.0f;
    private GameObject car;
    private float lastBlinker;
    private GameObject Left_blinker;
    private GameObject Right_blinker;
    private GameObject Smoke;
    public List<GameObject> wheelSmokeParticles;
    public Material bodyMaterial;
    private Rigidbody rb;
    private ParticleSystem Nitro;
    
    private List<Color> COLORS = new List<Color> {
        new Color(0.2335271f, 0.0f, 0.4716981f),
        new Color(0f, 0.1643248f, 0.4705881f),
        new Color(0.4705882f, 0.1949583f, 0f),
        Color.gray,
        Color.white,
        Color.black
    };

    void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.name == "Car")
            {
                car = child.gameObject;

                Left_blinker = car.transform.Find("Left_Blinker").gameObject;
                Right_blinker = car.transform.Find("Right_Blinker").gameObject;
                Smoke = car.transform.Find("Smoke").gameObject;
                var nitroObject = car.transform.Find("Nitro").gameObject;
                Nitro = nitroObject.GetComponent<ParticleSystem>();

                bodyMaterial.SetColor("_BaseColor", COLORS[Random.Range(0, COLORS.Count)]);

                rb = car.GetComponent<Rigidbody>();
            }
        }
    }

    void Update()
    {
        if (!GameBehaviour.isGameStarted) return;
        MovementImplementation();
    }

    void MovementImplementation()
    {
        float axis = -Input.GetAxis("P1_Horizontal");
        if(axis <= 0.1 && axis >= -0.1)
        {
            axis = 0;
        }

        float horizontal = axis * speed;
        horizontal *= Time.deltaTime;

        rb.AddForce(new Vector3(0, 0, horizontal), ForceMode.Impulse);

        if (horizontal != 0) {
            car.transform.rotation = Quaternion.Lerp(car.transform.rotation, Quaternion.Euler(0, horizontal < 0 ? 10f : -10f, 0), Time.deltaTime * 5);
        } else {
            car.transform.rotation = Quaternion.Lerp(car.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5);
        }
        
        // Smoke wheels logic
        if (Mathf.Abs(horizontal) > 0) {
            foreach (GameObject wheelSmoke in wheelSmokeParticles) {
                var ps = wheelSmoke.GetComponent<ParticleSystem>();
                var emission = ps.emission;
                emission.enabled = true;
            }
        } else {
            foreach (GameObject wheelSmoke in wheelSmokeParticles) {
                var ps = wheelSmoke.GetComponent<ParticleSystem>();
                var emission = ps.emission;
                emission.enabled = false;
            }
        }

        // Blinkers logic
        if (lastBlinker + 0.2f < Time.time) {
            if (axis > 0) {
                Right_blinker.SetActive(false);
                MakeBlinkerBlinkering(Left_blinker);
            } else if (axis < 0) {
                Left_blinker.SetActive(false);
                MakeBlinkerBlinkering(Right_blinker);
            } else {
                if(Left_blinker.activeSelf) {
                    Left_blinker.SetActive(false);
                }
                if(Right_blinker.activeSelf) {
                    Right_blinker.SetActive(false);
                }
            }
        }
        
        // Nitro logic
        var nitroEmission = Nitro.emission;
        nitroEmission.enabled = GameBehaviour.isBoosting;
    }

    private void MakeBlinkerBlinkering(GameObject blinker) {
        blinker.SetActive(!blinker.activeSelf);
        lastBlinker = Time.time;
    }
}
