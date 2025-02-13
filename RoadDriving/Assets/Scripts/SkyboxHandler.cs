using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxHandler : MonoBehaviour
{
    public Material skybox;
    public Color sunColor = new Color(1f, 0.9597363f, 0.5896226f);
    public float sunIntensity = 1.2f;
    
    void Start()
    {
        RenderSettings.skybox = skybox;
        
        var sun = GameObject.Find("Sun");
        var light = sun.GetComponent<Light>();
        light.color = sunColor;
        light.intensity = sunIntensity;
    }
}
