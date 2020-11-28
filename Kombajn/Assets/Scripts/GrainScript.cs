using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrainScript : MonoBehaviour
{
    public Text GrainText;
    public GameObject player;
    
    void Update()
    {
        GrainText.text = player.GetComponentInChildren<GrassCollider>().score.ToString();
    }
}
