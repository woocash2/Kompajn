using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] float camMoveSpeed = 120.0f;
    public Transform follow;
    [SerializeField] float hiClampAngle = 70.0f;
    [SerializeField] float lowClampAngle = 50.0f;
    [SerializeField] float sensitivity = 100f;

    private float mouseX;
    private float mouseY;

    private float rotX = 0f;
    private float rotY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotX = rot.x;
        rotY = rot.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * sensitivity * Time.deltaTime;
        rotX += mouseY * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -hiClampAngle, lowClampAngle);

        Quaternion localRotation = Quaternion.Euler(-rotX, rotY, 0f);
        transform.rotation = localRotation;
    }

    private void LateUpdate() {
        CameraUpdater();
    }

    void CameraUpdater() {
        float step = camMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, follow.position, step);
    }

    public void AddRecoil(float recoil) {
        rotX += recoil;
    }
}
