using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health=20f;
    private void Update()
    {   
        CheckHealth();
    }
    public void CheckHealth()
    {
        if(health<=0)Destroy(this.gameObject);
    }

    public void Damage(float damage)
    {
        health -= damage;
    }
}
