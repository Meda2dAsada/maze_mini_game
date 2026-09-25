using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowablePlayer : MonoBehaviour
{
    public Transform shootPoint;
    public float shootForce = 30f;
    public GameObject bulletPrefab;

    private void Update()
    {

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            Throw();
        }
    }


    void Throw()
    {
        // Instancia la bala
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        Destroy(bullet, 2f);
    }
    
}
