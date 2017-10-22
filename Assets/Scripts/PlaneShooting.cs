using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShooting : MonoBehaviour {

//  public GameObject bulletPrefab, bulletShell;
//    public Transform bulletSpawn;
    public AudioClip sfx;
    public float range = 100;
    public GameObject particalSystem;

    private Transform camera;
    private float spareCount = 30;
    private GameObject machinegun;
    private bool cooldownUP = true, reload = false;
    private void Start()
    {
        camera = GameObject.Find("Main Camera").transform;
        machinegun = GameObject.Find("lines");
    }

    void Update ()
    {
        if (reload = spareCount <= 0)
        {
            Invoke("ResetReload", 2.5f);
        }

        if (Input.GetMouseButton(0) && cooldownUP && !reload)
        {
            if (!SFX_Manager.theAudioSource.isPlaying)
            {
                SFX_Manager.PlaySFX(sfx);
                SFX_Manager.theAudioSource.pitch = 1.5f;
            }
            cooldownUP = false;
            Fire();
        }
        else if (Input.GetMouseButtonUp(0) || reload)
        {
            SFX_Manager.StopSFX();
            SFX_Manager.theAudioSource.pitch = 1f;
        }
    }

    void Fire()
    {

        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            GameObject temp = Instantiate(particalSystem, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(temp, 2f);
        }

        /*var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        bullet.transform.parent = bulletSpawn.parent;
        bullet.transform.position = bulletSpawn.position;
        bullet.transform.rotation = bulletSpawn.rotation;
        bullet.transform.localScale = bulletSpawn.localScale;

        bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * -500);

        var shell = (GameObject)Instantiate(
        bulletShell,
        bulletSpawn.position,
        bulletSpawn.rotation);

        shell.transform.parent = bulletSpawn.parent;
        shell.transform.position = bulletSpawn.position;
        shell.transform.rotation = bulletSpawn.rotation;
        shell.transform.localScale = bulletSpawn.localScale;

        float ran = Random.Range(20, 50);
        shell.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-ran, ran, -ran * 2));
        */
        machinegun.transform.localEulerAngles = Vector3.Lerp(machinegun.transform.localEulerAngles, machinegun.transform.localEulerAngles + Vector3.up * 360 / 3, Time.deltaTime * 5);
        //transform.position = Vector3.Lerp(transform.position,transform.position + Vector3.forward * 0.3f, Time.deltaTime * 5f);
    
        Invoke("ResetCooldown", 0.1f);
        //Destroy(bullet, 2.0f);
        //Destroy(shell, 3f);
    }

    private void ResetCooldown()
    {
        spareCount--;
        cooldownUP = true;
        //transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.forward * -0.3f, Time.deltaTime * 5);
    }

    private void ResetReload()
    {
        spareCount = 30;
    }
}
