using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmsGenerator : MonoBehaviour
{
    public List<GameObject> palms = new List<GameObject>();
    private List<GameObject> sand = new List<GameObject>();
    
    void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.name == "Sand")
            {
                sand.Add(child.gameObject);
            }
        }

        GeneratePalms();
    }

    private void GeneratePalms()
    {
        for(int i = 0; i < sand.Count; i++)
        {
            GeneratePalmForSand(sand[i]);
        }
    }

    private void GeneratePalmForSand(GameObject sand)
    {
        var position = sand.transform.position;
        var count = Random.Range(30, 70);

        for(int i = 0; i < count; i++)
        {
            var palm = palms[Random.Range(0, palms.Count)];
            var x = Random.Range(-70, 70);
            var z = Random.Range(-60, 60);
            var scale = Random.Range(1, 3);

            var palmInstance = Instantiate(palm, new Vector3(position.x + x, position.y, position.z + z), Quaternion.identity);
            palmInstance.transform.localScale = new Vector3(scale, scale, scale);

            palmInstance.transform.parent = sand.transform;
        }
    }
}
