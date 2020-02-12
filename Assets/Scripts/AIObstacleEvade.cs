using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIObstacleEvade : MonoBehaviour
{
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
        avoidObstacles();
    }

    void avoidObstacles()
    {
        Vector3 ahead = transform.forward;
        RaycastHit hit;
        float rayLength = 100.0f;
        ahead = ahead.normalized;

        if(Physics.Raycast(transform.position,ahead,out hit,rayLength))
        {
            ObjectEvade(gameObject, hit.transform.gameObject);
        }
    }

    void ObjectEvade(GameObject Ai, GameObject obstacle)
    {
        Vector3 v = Ai.transform.position - obstacle.transform.position;
        Vector3 force = v.normalized * speed - rb.velocity;
        rb.velocity += force * Time.deltaTime;
        Ai.transform.position += rb.velocity * Time.deltaTime;
        Ai.transform.rotation = Quaternion.LookRotation(v);
    }
}
