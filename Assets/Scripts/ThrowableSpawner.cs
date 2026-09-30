using UnityEngine;

public class ThrowableSpawner : MonoBehaviour
{
    public GameObject gameObject;
    public Transform spawnPoint; 

   
    public void InstantiateThrowablePrefab()
    {
        if (gameObject != null)
        {
            Vector3 position;
            Quaternion rotation;

            if(spawnPoint != null){
                position = spawnPoint.position;   
                rotation = spawnPoint.rotation;
            }else{
                position = Vector3.zero;
                rotation = Quaternion.identity;
            }

            Instantiate(gameObject, position, rotation);
        }

    }
}