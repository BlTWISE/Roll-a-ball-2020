using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    private Rigidbody rb;
    GameObject player;
    bool move = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("plyr");
    }

    void FixedUpdate()
    {
        if (move)
        {
            float x = transform.position.x - player.transform.position.x;
            float z = transform.position.z - player.transform.position.z;

            //Vector3 moveDirection = new Vector3(-x, 0.0f, 0.0f);
            Vector3 moveDirection = new Vector3(x / 20, 0.0f, z / 20);

            rb.MovePosition(transform.position + (moveDirection * 1 * Time.deltaTime));

            Vector3 m_EulerAngleVelocity = new Vector3(15, 30, 45);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);

            rb.MoveRotation(rb.rotation * deltaRotation);
            //transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            move = false;
        }
    }

}
