using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonShoot : MonoBehaviour
{
    public bool isShooting=false;
    public Camera fpsCam;                                
    public LineRenderer laserLine;                                        // Reference to the LineRenderer component which will display our laserline
   private bool allowfire=true;

    [Header("Gun Variables")]
    public float weaponRange=100;
    public int gunDamage = 4;                                            // Set the number of hitpoints that this gun will take away from shot objects with a health script
    public float fireRate = 0.25f;
    public Transform gunEnd;                                            // Holds a reference to the gun end object, marking the muzzle location of the gun

    public int enemyLayer;

    public  void FixedUpdate()
    {
        if(isShooting && allowfire)
        {
            StartCoroutine(ShotEffect());  
        }
    }
    private void Shoot()
    {
        int layerMask = 1 << enemyLayer;
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;
        laserLine.SetPosition(0, gunEnd.position);
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange,layerMask))
        {
            laserLine.SetPosition(1, hit.point);
            Debug.Log("Enemy Shot");
          Health  health=hit.transform.GetComponent<Health>();
                 if (health.health != null)
                {
                    health.Damage (gunDamage);
                }
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
        }
    }

    private IEnumerator ShotEffect()
    {
       allowfire = false;
        laserLine.enabled = false;
        yield return new WaitForSeconds(fireRate);
        Shoot();
        laserLine.enabled = true;
        allowfire = true;

    }
}
