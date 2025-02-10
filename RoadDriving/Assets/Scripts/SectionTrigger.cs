using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;

    private List<GameObject> sections = new List<GameObject>();

    private void Start()
    {
        sections.Add(GameObject.Find("Road_Section"));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            if(sections.Count >= 2) {
                var player = GameObject.Find("Player");
                var cars = GameObject.FindGameObjectsWithTag("Car");
                foreach (var car in cars)
                {
                    if (car.transform.position.x < player.transform.position.x)
                    {
                        Destroy(car);
                    }
                }

                Destroy(sections[0]);
                sections.RemoveAt(0);
            }

            var newSection = Instantiate(roadSection, new Vector3(95, 0, 0), Quaternion.identity);
            sections.Add(
                newSection
            );
        }
    }
}
