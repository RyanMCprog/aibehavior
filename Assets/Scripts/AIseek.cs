using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIseek : MonoBehaviour
{
    public GameObject target;

    public float speed;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = ((target.transform.position - transform.position) * speed).normalized;
        Vector3 force = v - rb.velocity;
        rb.velocity += force * Time.deltaTime;
        transform.position += rb.velocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(v);
    }
}
