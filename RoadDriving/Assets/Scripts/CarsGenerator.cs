using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsGenerator : MonoBehaviour
{
    public List<GameObject> carsGroup = new List<GameObject>();

    void Start() {
        GenerateCars();
    }

    public void GenerateCars() {
        var position = transform.position;

        var z = 200;
        for(int i = 0; i < 4; i++) {
            GameObject carGroup = carsGroup[Random.Range(0, carsGroup.Count)];

            var car = Instantiate(carGroup, new Vector3(z, 1, 0), Quaternion.identity);

            z += 200;
        }
    }
}
