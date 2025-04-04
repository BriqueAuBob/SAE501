using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public List<GameObject> roadPrefabs;
    private GameObject roadSection;
    private List<GameObject> sections = new List<GameObject>();

    private void Start()
    {
        var prefab = roadPrefabs[Random.Range(0, roadPrefabs.Count)];
        var obj = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        obj.name = "Road_Section";
        sections.Add(GameObject.Find("Road_Section"));

        roadSection = prefab;
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
                    if (car.transform.position.x < player.transform.position.x - 10)
                    {
                        Destroy(car);
                    }
                }

                Destroy(sections[0]);
                sections.RemoveAt(0);
            }

            // calculate position of the new section by using the last section position
            var lastSection = sections[sections.Count - 1];
            var position = lastSection.transform.position + new Vector3(100, 0, 0);

            var newSection = Instantiate(roadSection, position, Quaternion.identity);
            sections.Add(
                newSection
            );
        }
    }
}
