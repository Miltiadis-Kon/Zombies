using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

    public Animator zombieAnimator;
     public Transform target; //the enemy's target
     public float moveSpeed = 2; //move speed
     public float rotationSpeed = 2; //speed of turning
    public float range = 1f;
    void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        //rotate to look at the player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);
        //move towards the player
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        zombieAnimator.SetBool("walk", true);
        AttackPlayer();
    }
    private void AttackPlayer()
    {
        if (Vector3.Distance(this.transform.position, target.position) < range) { zombieAnimator.Play("attack"); zombieAnimator.SetBool("walk", false); }

    }
    public void AttackFromAnimation()
    {
        //player could have moved out of range
        if (Vector3.Distance(this.transform.position, target.position) < range) target.GetComponent<Health>().Damage(20);
    }
}