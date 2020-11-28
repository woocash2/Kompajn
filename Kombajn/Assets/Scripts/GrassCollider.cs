using UnityEngine;

public class GrassCollider : MonoBehaviour {
    public int score;
    public int perGrassScore;

    private static string grassTag = "Grass";

    public void Start(){
        score = 0;
    }

    public void OnCollisionEnter(Collider coll){
        if(coll.gameObject.tag == grassTag){
            score += 1;
        }
    }
}