using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedScript : MonoBehaviour
{
    public Rigidbody rb;
    public Text textSpeed;

    void Update()
    {
        textSpeed.text = rb.velocity.magnitude.ToString("0") + " km/h";
    }
}
