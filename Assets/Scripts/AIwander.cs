using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIwander : MonoBehaviour
{
    public GameObject target;

    public float speed;

    public float range;

    Rigidbody rb;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Wander();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = ((target.transform.position - transform.position) * speed).normalized;
        Vector3 force = v - rb.velocity;
        rb.velocity += force * Time.deltaTime;
        transform.position += rb.velocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(v);

        if ((transform.position - target.transform.position).magnitude < 3)
        {
            Wander();
        }
    }

    void Wander()
    {
        pos = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), 0.5f, Random.Range(transform.position.z - range, transform.position.z + range));
        target.transform.position = pos;
        
    }
}
