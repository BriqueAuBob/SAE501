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
