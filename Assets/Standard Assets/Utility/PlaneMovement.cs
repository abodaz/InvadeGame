using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {
    public float speed = 15, rotSpeed = 60, yMin, yMax;
    void Start ()
    {
        yMin = Mathf.Sin(yMin * Mathf.Deg2Rad);
        yMax = Mathf.Sin(yMax * Mathf.Deg2Rad);
    }

    void Update () {
        float xRot = Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        float yRot = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        Vector3 eulerAngles = transform.eulerAngles + xRot * Vector3.right + yRot * Vector3.up;
        //Debug.Log(Mathf.Sin(eulerAngles.x));
        
        eulerAngles.x = Mathf.Rad2Deg * Mathf.Asin(Mathf.Clamp(Mathf.Sin(eulerAngles.x*Mathf.Deg2Rad), yMin, yMax));
        transform.eulerAngles = eulerAngles;
    }
}
