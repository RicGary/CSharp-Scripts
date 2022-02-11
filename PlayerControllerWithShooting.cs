using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed;
    public float xRange = 10;

    public GameObject projectilePrefab;

    public float fireRate = 2f;
    private bool shooting = false;

    void Start()
    {
        InvokeRepeating("Shoot", 0, 1 / fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        shooting = false;

        if (Input.GetKey(KeyCode.Space))
        {
            shooting = true;
        }

        if (transform.position.x < - xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    void Shoot()
    {
        if (shooting == true)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
