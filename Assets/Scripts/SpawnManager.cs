using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] float minSpawnInterval = 1.5f;
    [SerializeField] float maxSpawnInterval = 3.0f;
    [SerializeField] private Vector2 spawnPos;
    [SerializeField] private Vector2 spawnPosVariation = Vector2.zero;
    [SerializeField] bool spawnOnStart = true;

    private void Start()
    {
        if (spawnOnStart) StartCoroutine(SpawnRoutine());
    }

    public void SetSpawnPos(Vector2 spawnPos)
    {
        this.spawnPos = spawnPos;
    }

    public GameObject Spawn()
    {
        var obj = Instantiate(prefab, container);

        obj.transform.position = new Vector3(
            spawnPos.x + Random.Range(-spawnPosVariation.x, spawnPosVariation.x),
            spawnPos.y + Random.Range(-spawnPosVariation.y, spawnPosVariation.y),
            0
        );

        return obj;
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

        Spawn();

        StartCoroutine(SpawnRoutine());
    }
}
