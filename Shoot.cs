using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float fireRate;
    float nextFireTime = 0;

    private void Update()
    {
        if(Time.time >= nextFireTime)
        {
            GameObject clone =  Instantiate(projectile, firePoint);
            clone.transform.parent = null;
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
