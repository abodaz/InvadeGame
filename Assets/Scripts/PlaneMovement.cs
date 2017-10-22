using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    private static bool m_cursorIsLocked = true;
    private Transform child;
    bool alreadyInReverse = false;

    float xRot, yRot, z;
    public float speed = 15, rotSpeed = 30;
    Quaternion old;
    Quaternion wantedRotation;
    private void Start()
    {
        child = GetComponentInChildren<Transform>();
    }
    void Update ()
    {
        MouseLock();

        xRot = Input.GetAxis("Horizontal");

        z = -Input.GetAxis("Vertical") > 0 ? -Input.GetAxis("Vertical") * Time.deltaTime*speed/2 : -Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(0, 0, z);

        old = child.rotation;

        wantedRotation = Quaternion.Euler(child.rotation.x + 5, child.rotation.y, child.rotation.z);

        if (z > 0 && !alreadyInReverse)
        {
            Debug.Log("1>>> Z > 0: " + alreadyInReverse);
            child.rotation = Quaternion.Lerp(child.rotation, wantedRotation, - Mathf.Abs(Input.GetAxis("Vertical"))/2);
            if (child.rotation.x == wantedRotation.x)
                alreadyInReverse = true;

        } else if(z < 0 && alreadyInReverse)
        {
            Debug.Log("2>>> Z < 0: " + alreadyInReverse);
            child.rotation = Quaternion.Lerp(child.rotation, old, Mathf.Abs(Input.GetAxis("Vertical"))/2);
            if (child.rotation.x == old.x)
                alreadyInReverse = false;
        }


        Vector3 eulerAngles = transform.eulerAngles + -xRot * Vector3.up * Time.deltaTime * -rotSpeed;
        transform.eulerAngles = eulerAngles;
    }

    public static void MouseLock()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }


        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}