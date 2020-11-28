using UnityEngine;

public class CombainMover : MonoBehaviour {
    public float translationSpeed;
    public float angularSpeed;
    public GameObject lookingPoint;

    private static string vertical = "Vertical";
    private static string horizontal = "Horizontal";

    private Rigidbody rb;

    private bool IsMoving(){
        return !Mathf.Approximately(0.0f, Input.GetAxis(horizontal));
    }

    private bool IsRotating(){
        return Mathf.Approximately(0.0f, Input.GetAxis(vertical));
    }

    private void Translate(){
        if(IsMoving()){
           rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else{
            rb.velocity = (transform.position - lookingPoint.transform.position).normalized;
        }
    }

    public void Start(){
        rb = GetComponent<Rigidbody>();
    }

    public void Update(){
        Translate();
    }
}