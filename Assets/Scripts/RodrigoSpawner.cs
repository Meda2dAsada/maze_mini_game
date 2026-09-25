using UnityEngine;

public class RodrigoSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint; 

   
    public void InstantiatePrefab()
    {
        if (prefabToSpawn != null)
        {
            Vector3 position = spawnPoint != null ? spawnPoint.position : Vector3.zero;
            Quaternion rotation = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;

            Instantiate(prefabToSpawn, position, rotation);
        }
        else
        {
            Debug.LogWarning("Tas Troleando");
        }
    }
}