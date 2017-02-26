using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject spawn;
    [SerializeField]
    private int spawnMax = 10;
    [SerializeField]
    private int spawnTimer = 10;

    private int spawnCounter = 0;
    private bool canSpawn = true;

    private void Update()
    {
        
        if (canSpawn && spawnCounter < spawnMax)
        {
            SpawnObject(spawn);
            canSpawn = false;
            StartCoroutine(ResetSpawner());
        }

        if (spawnCounter >= spawnMax)
        {
            Debug.Log("Spawner finished");
            Destroy(gameObject);
        }

    }

    void SpawnObject(GameObject obj)
    {
        GameObject go = Instantiate(obj, transform.localPosition, Quaternion.identity);
        spawnCounter++;
        go.transform.SetParent(transform);
    }

    IEnumerator ResetSpawner()
    {
        yield return new WaitForSeconds(spawnTimer);
        canSpawn = true;
    }

}
