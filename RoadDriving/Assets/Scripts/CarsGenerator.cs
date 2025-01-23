using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsGenerator : MonoBehaviour
{
    public List<GameObject> carsGroup = new List<GameObject>();

    void Start() {
        if (GameBehaviour.isGameStarted)
        {
            GenerateCars();
        }
    }

    public void GenerateCars() {
        var position = transform.position;

        var z = position.x + 50;
        for(int i = 0; i < 4; i++) {
            GameObject carGroup = carsGroup[Random.Range(0, carsGroup.Count)];

            var car = Instantiate(carGroup, new Vector3(z, 1, 0), Quaternion.identity);

            z += 30 + Random.Range(0, 10);
        }
    }
}
