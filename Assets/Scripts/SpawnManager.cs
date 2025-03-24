using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] float minSpawnInterval = 1.5f;
    [SerializeField] float maxSpawnInterval = 3.0f;
    [SerializeField] private Vector2 spawnPos;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

        var obj = Instantiate(prefab, container);
        obj.transform.position = new Vector3(spawnPos.x, spawnPos.y, 0);

        StartCoroutine(SpawnRoutine());
    }
}
