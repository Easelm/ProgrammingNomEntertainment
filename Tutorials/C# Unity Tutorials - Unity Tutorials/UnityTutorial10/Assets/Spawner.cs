using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("SpawnEnemyWaitTime");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnEnemyWaitTime()
    {
        yield return new WaitForSeconds(3);

        GameObject enemy = (GameObject)Instantiate(enemyPrefab, new Vector3(Random.Range(-2, 2), 5), Quaternion.identity);

        StartCoroutine("SpawnEnemyWaitTime");
    }
}
