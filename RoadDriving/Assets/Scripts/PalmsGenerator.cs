using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmsGenerator : MonoBehaviour
{
    public List<GameObject> palms = new List<GameObject>();
    private List<GameObject> sand = new List<GameObject>();
    public float minScale = 1.0f;
    public float maxScale = 3.0f;
    public float zDist = 30.0f;
    public float xDist = 70.0f;
    
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
            var x = Random.Range(-xDist, xDist);
            var z = Random.Range(-zDist, zDist);
            var scale = Random.Range(minScale, maxScale);

            var palmInstance = Instantiate(palm, new Vector3(position.x + x, position.y, position.z + z), Quaternion.identity);
            palmInstance.transform.localScale = new Vector3(scale, scale, scale);

            palmInstance.transform.parent = sand.transform;
        }
    }
}
