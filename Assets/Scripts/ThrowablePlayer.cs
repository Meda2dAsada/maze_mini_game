using System;
using UnityEngine;

public class ThrowablePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform shootPoint;
    public float shootForce = 30f;
    public GameObject bulletPrefab;

    private void Update()
    {
        Move();
        HandleShoot();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ);

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void HandleShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }

    void Throw()
    {
        if (bulletPrefab == null || shootPoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        }

        Destroy(bullet, 2f);
    }
}
