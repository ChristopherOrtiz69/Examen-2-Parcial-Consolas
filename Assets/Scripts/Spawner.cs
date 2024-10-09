using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 2f;
    public float spawnDistance = 2f; 

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = transform.position + transform.forward * spawnDistance; // Calcular posición de spawn
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
