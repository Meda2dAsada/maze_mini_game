using UnityEngine;
using UnityEngine.EventSystems;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform spawnPoint;

    private GameObject cube;

    public void SpawnCube()
    {
        if (cube == null)
        {
            cube = Instantiate(cubePrefab, spawnPoint.position, spawnPoint.rotation);
        }

        EventSystem.current.SetSelectedGameObject(null);
    }
}
