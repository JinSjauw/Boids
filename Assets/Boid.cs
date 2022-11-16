using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity = new Vector3();
    public float moveSpeed;
    public int ID;
    public List<Boid> boidsList;

    public int collisionDistance = 5;
    public int perceiveDistance = 30;
    public int perceiveVelocity = 30;
    public float boidMoveSpeed = 4;
    // Update is called once per frame

    void Update()
    {
        MoveBoids();
    }

    private void MoveBoids()
    {
        Vector3 v1, v2, v3;

        v1 = Cohesion();
        v2 = Avoid();
        v3 = MatchingVelocity();

        //Debug.Log("V1 " + v1 + " V2 " + v2 + " V3 " + v3);
        velocity = velocity + v1 + v2 + v3;
        transform.position = transform.position + velocity * moveSpeed * Time.deltaTime;
    }

    private float GetBoidDistance(Boid boid)
    {
        return Vector3.Distance(boid.transform.position, transform.position);
    }

    private Vector3 Cohesion() 
    {
        Vector3 perceivedCenter = new Vector3();
        int count = 0;

        foreach(Boid boid in boidsList) 
        {
            if(boid.ID != ID) 
            {
                if(GetBoidDistance(boid) < perceiveDistance) 
                {
                    perceivedCenter = perceivedCenter + boid.transform.position;
                    count++;
                }
            }
        }

        if (count == 0) 
        {
            return Vector3.zero;
        }

        perceivedCenter = perceivedCenter / count;

        return (perceivedCenter - transform.position) / 100;
    }

    private Vector3 Avoid()
    {
        Vector3 avoidVector = Vector3.zero;

        foreach(Boid boid in boidsList) 
        {
            if(boid.ID != ID) 
            {
                if(GetBoidDistance(boid) < collisionDistance) 
                {
                    avoidVector = avoidVector - (boid.transform.position - transform.position);
                }
            }
        }
        return avoidVector;
    }

    private Vector3 MatchingVelocity()
    {
        Vector3 perceivedVelocity = new Vector3();
        int count = 0;
        foreach(Boid boid in boidsList) 
        {
            if(boid.ID != ID) 
            {
                if(GetBoidDistance(boid) < perceiveVelocity) 
                {
                    perceivedVelocity = perceivedVelocity + boid.velocity;
                    count++;
                }
            }
        }

        if(count == 0) 
        {
            return Vector3.zero;
        }
        
        perceivedVelocity = perceivedVelocity / count;

        return (perceivedVelocity - velocity) / 8;
    }
}
