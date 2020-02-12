using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIflock : MonoBehaviour
{
    public GameObject[] boids;

    int birdCount = 0;

    Vector3 v1;
    Vector3 v2;
    Vector3 v3;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject bird in boids)
        {
            v1 = Rule1(bird);
            v2 = Rule2(bird);
            v3 = Rule3(bird);

            
        }
        rb.velocity += v1 + v2 + v3;
        transform.position += rb.velocity;
    }

    Vector3 Rule1(GameObject bird)
    {
        Vector3 PCenter = new Vector3(0,0,0);
        birdCount = 0;
        foreach(GameObject b in boids)
        {
            if(b != bird)
            {
                PCenter = PCenter + b.transform.position;
            }
            birdCount++;
        }
        PCenter = PCenter / (birdCount - 1);

        return (PCenter - bird.transform.position).normalized;
    }

    Vector3 Rule2(GameObject bird)
    {
        Vector3 center = new Vector3(0,0,0);

        foreach (GameObject b in boids)
        {
            if (b != bird)
            {
                if((b.transform.position - bird.transform.position).magnitude < 100)
                {
                    center = center - (b.transform.position - bird.transform.position);
                }
            }
            
        }
        return center;
    }

    void Rule3(GameObject bird)
    {
        Vector3 Pvelocity = new Vector3(0, 0, 0);

        foreach (GameObject b in boids)
        {
            if (b != bird)
            {
                Pvelocity += 
            }

        }

    }
}
