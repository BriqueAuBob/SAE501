using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallBehaviour : MonoBehaviour
{
    public bool toLeft = false;
    public float force = 1;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var currentRotationDirection = other.gameObject.transform.rotation;
            other.gameObject.GetComponent<Rigidbody>().AddForce(-other.gameObject.transform.forward * force * (toLeft ? -1 : 1), ForceMode.Impulse);
            other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
