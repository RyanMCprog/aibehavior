using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIevade : MonoBehaviour
{
    public GameObject target;



    public float speed;

    Rigidbody rb;

    Rigidbody trb;

    // Start is called before the first frame update
    void Start()
    {
        trb = target.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = transform.position - target.transform.position + trb.velocity;
        Vector3 force = v.normalized * speed - rb.velocity;
        rb.velocity += force * Time.deltaTime;
        transform.position += rb.velocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(v);
    }

    
}
