using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public GameObject user;
    public int zombieAmount = 20;
    void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    private IEnumerator SpawnZombies()
    {
        for (int i = 0; i < zombieAmount; i++)
        {
         GameObject _go=   Instantiate(zombiePrefab, new Vector3(Random.Range(-20, 20), 0, Random.Range(-20,20)), Quaternion.identity);
            _go.GetComponent<ZombieController>().target = user.transform;
        }
        yield return new WaitForSeconds(15);
        StartCoroutine(SpawnZombies());
    }
}
