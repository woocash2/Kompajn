using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GenerateScene : MonoBehaviour
{

    public GameObject fence;
    public GameObject wheat;
    public GameObject combayn;
    public GameObject terrain;

    public int sizeX;
    public int sizeZ;
    public int grassCount;

    private void fillSquare(int x, int z, int len, int count){
        System.Random random = new System.Random();

        for(int i = 0; i<count; i++){
            int posX = random.Next(x, x + len);
            int posZ = random.Next(z, z + len);

            Instantiate(wheat, new Vector3(posX, 0.0f, posZ), Quaternion.identity);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(terrain, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        fillSquare(0, 0, sizeX, grassCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
