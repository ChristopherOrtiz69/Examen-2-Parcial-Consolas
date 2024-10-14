using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 2f;
    public float spawnDistance = 2f;

    private float nextSpawnTime = 0f;

    void Update()
    {
        // Verifica si es el momento de spawn
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval; // Actualiza el tiempo para el próximo spawn
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = transform.position + transform.forward * spawnDistance; // Calcular posición de spawn
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Establece la velocidad inicial si el objeto tiene un Rigidbody
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * 5f; // Velocidad inicial para evitar que se quede pegado
        }
    }
}
