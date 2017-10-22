using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunControls : MonoBehaviour {

    float xRot, yRot;
    public float rotSpeed = 60;
    public Vector2 xClamp, yClamp;

    void Start ()
    {
        yClamp.x = Mathf.Sin(yClamp.x * Mathf.Deg2Rad);
        yClamp.y = Mathf.Sin(yClamp.y * Mathf.Deg2Rad);
        xClamp.x = Mathf.Sin(xClamp.x * Mathf.Deg2Rad);
        xClamp.y = Mathf.Sin(xClamp.y * Mathf.Deg2Rad);
    }
	
	void Update ()
    {
        xRot = Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        yRot = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;

        Vector3 eulerAngles = transform.localEulerAngles + xRot * Vector3.right + yRot * Vector3.up;

        eulerAngles.x = Mathf.Rad2Deg * Mathf.Asin(Mathf.Clamp(Mathf.Sin(eulerAngles.x * Mathf.Deg2Rad), yClamp.x, yClamp.y));
        eulerAngles.y = Mathf.Rad2Deg * Mathf.Asin(Mathf.Clamp(Mathf.Sin(eulerAngles.y * Mathf.Deg2Rad), xClamp.x, xClamp.y));
    
        transform.localEulerAngles = eulerAngles;
    }
}
