using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateScene : MonoBehaviour
{
    public GameObject fence;
    public GameObject wheat;
    public GameObject combayn;
    public GameObject terrain;
    public GameObject steelFence;
    public GameObject player;

    public int sizeX;
    public int sizeZ;

    void generateFencesAroundPlane(GameObject fencePrefab, Vector3 leftBackCorner, float lenX, float lenZ){
        float fenceLen = 4.4f; // how to read it from the object?
        for (Vector3 offset = Vector3.zero; offset.x + fenceLen < lenX; offset += Vector3.right * fenceLen){
            fence = Instantiate(fencePrefab, leftBackCorner + offset, Quaternion.Euler(0, 90, 0));
        }

        for (Vector3 offset = Vector3.right * lenX; offset.z + fenceLen < lenZ; offset += Vector3.forward * fenceLen){
            fence = Instantiate(fencePrefab, leftBackCorner + offset, Quaternion.identity);
        }

        for (Vector3 offset = Vector3.zero; offset.z + fenceLen < lenZ; offset += Vector3.forward * fenceLen){
            fence = Instantiate(fencePrefab, leftBackCorner + offset, Quaternion.identity);
        }

        for (Vector3 offset = Vector3.forward * lenZ; offset.x + fenceLen < lenX; offset += Vector3.right * fenceLen){
            fence = Instantiate(fencePrefab, leftBackCorner + offset, Quaternion.Euler(0, 90, 0));
        }
    }

    void generateWheatInsidePlane(GameObject wheatPrefab, Vector3 leftBackCorner, float lenX, float lenZ, int count){
        for(int i=0;i<count;i++){
            Vector3 position = leftBackCorner + new Vector3(Random.Range(0f, lenX), 0f, Random.Range(0f, lenZ));
            wheat = Instantiate(wheatPrefab, position, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // generate plane with corners in (0, 0, 0) and (sizeX, 0, sizeZ)
        terrain = Instantiate(terrain, new Vector3(sizeX/2.0f, 0, sizeZ/2.0f), Quaternion.identity);
        terrain.transform.localScale = new Vector3(sizeX*0.1f, 0.1f, sizeZ*0.1f); 

        // generate steel fences around the plane
        generateFencesAroundPlane(steelFence, Vector3.zero, sizeX, sizeZ);
        generateWheatInsidePlane(wheat, Vector3.zero, sizeX, sizeZ, 100);

        player = Instantiate(player, new Vector3(3.0f, 0f, 3.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
