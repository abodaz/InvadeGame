using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovements : MonoBehaviour {

    public float speed = 15, rotSpeed = 60, yMin, yMax;

    float xRot, yRot, x, y, z;
    private Transform child;
    private Vector3 thePosition;
    private static bool m_cursorIsLocked = true;
    bool outtaRange = false;

    private void Awake()
    {
        child = GetComponentInChildren<Transform>();
    }

    void FixedUpdate()
    {
        MouseLock();

        outtaRange = transform.position.y > yMax || transform.position.y < yMin;

        if (!outtaRange)
        {
            x = -Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            z = -Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(x, 0, z);

            xRot = Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
            yRot = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
            
            child.Rotate(0, yRot, 0, Space.Self);
            transform.Rotate(xRot, 0, 0, Space.Self);
        }
        else
        {
            FixRot(transform.position.y);
        }
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

    private void FixRot(float yPos)
    {

        if(yPos > yMax)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, yMax - 0.5f, transform.position.z), Time.deltaTime);
        }else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, yMin + 0.5f, transform.position.z), Time.deltaTime);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y, transform.rotation.z), Time.deltaTime*2);
    }
}
