using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G18AdSpawner : MonoBehaviour
{
    public float frequency = 1f;
    public GameObject adPrefab;

    [Header("Spawn Area")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public void Start()
    {
        StartCoroutine("SpawnAd");
    }

    public IEnumerator SpawnAd()
    {
        while (true)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Instantiate(adPrefab, new Vector3(randomX, randomY, adPrefab.transform.position.z), Quaternion.identity);

            yield return new WaitForSeconds(frequency); 
        }
    }
}
