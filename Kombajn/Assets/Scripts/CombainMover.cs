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
        lookingPoint = transform.Find(lookingPointString);
    }

    private void Translate(){
        Vector3 movement = (transform.position - lookingPoint.position).normalized * translationSpeed;
<<<<<<< HEAD
        movement.y = 0f;
        rb.velocity = Input.GetAxis(vertical) *  movement;
=======
        rb.velocity = Input.GetAxis(vertical) * movement;
>>>>>>> 5191da7e389e99d61c902ca02ef603fdbdc88ac3
    }

    private void Rotate(){
        Quaternion  deltaRotation = Quaternion.Euler(angularRotation * Input.GetAxis(horizontal) * angularSpeed);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public void Update(){
        Rotate();
        Translate();
    }
}