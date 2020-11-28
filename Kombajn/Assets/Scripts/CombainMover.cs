using UnityEngine;

public class CombainMover : MonoBehaviour {
    public float translationSpeed;
    public float angularSpeed;
    
    private static string vertical = "Vertical";
    private static string horizontal = "Horizontal";
    private static string lookingPointString = "lookingPoint";

    private Vector3 angularRotation;
    private Transform lookingPoint;
    private Rigidbody rb;

    public void Start(){
        rb = GetComponent<Rigidbody>();
        angularRotation = new Vector3(0.0f, 1.0f, 0.0f);
        lookingPoint = transform.Find(lookingPoint);
    }

    private void Translate(){
        Vector3 movement = (transform.position - lookingPoint.position).normalized * angularSpeed;
        movement.y = 0.0f;
        rb.velocity = Input.GetAxis(vertical) *  movement;
    }

    private void Rotate(){
        Quaternion  deltaRotation = Quaternion.Euler(angularRotation * Input.GetAxis(horizontal) * translationSpeed);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public void Update(){
        Rotate();
        Translate();
    }
}