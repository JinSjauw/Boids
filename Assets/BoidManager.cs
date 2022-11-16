using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    //Boid prefab
    [SerializeField] private GameObject boidPrefab;
    //Boids list
    [SerializeField] private List<Boid> boidsList;
    //
    [SerializeField] private int boidAmount = 20;
    [SerializeField] private int collisionDistance = 5;
    [SerializeField] private int perceiveDistance = 30;
    [SerializeField] private int perceiveVelocity = 30;
    [SerializeField] private float boidMoveSpeed = 4;



    // Start is called before the first frame update
    void Start()
    {
        //Initialise boids
        InitialiseBoids();
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void InitialiseBoids() 
    {
        boidsList = new List<Boid>();
        //Need to spawn boids somewhere on the screen;
        for (int i = 0; i < boidAmount; i++) 
        {
            Vector3 spawnPosition = new Vector3(Random.Range(0, Screen.width / 2), Random.Range(0, Screen.height / 2), 0);
            GameObject boidObject = Instantiate(boidPrefab, spawnPosition, Quaternion.identity);
            Boid boid = boidObject.GetComponent<Boid>();
            boid.ID = i;
            boid.moveSpeed = boidMoveSpeed;
            boid.perceiveDistance = perceiveDistance;
            boid.perceiveVelocity = perceiveVelocity;
            boid.collisionDistance = collisionDistance;
            boidsList.Add(boid);
        }

        foreach(Boid boid in boidsList) 
        {
            boid.boidsList = boidsList;
        }
    }

    /*private void MoveBoids()
    {
        Vector3 v1, v2, v3;

        foreach(Boid boid in boidsList) 
        {
            Debug.Log(Cohesion(boid));
            v1 = Cohesion(boid);
            v2 = Avoid(boid);
            v3 = MatchingVelocity(boid);

            boid.velocity = boid.velocity + v1 + v2 + v3;
        }
    }

    private float GetBoidDistance(Boid boid, Boid currentBoid)
    {
        return Vector3.Distance(boid.transform.position, currentBoid.transform.position);
    }

    private Vector3 Cohesion(Boid currentBoid) 
    {
        Vector3 perceivedCenter = new Vector3();

        foreach(Boid boid in boidsList) 
        {
            if(boid.ID != currentBoid.ID) 
            {
                if(GetBoidDistance(boid, currentBoid) < perceiveDistance) 
                {
                    perceivedCenter = perceivedCenter + boid.transform.position;
                }
            }
        }

        perceivedCenter = perceivedCenter / (boidsList.Count - 1);

        return (perceivedCenter - currentBoid.transform.position) / 100;
    }

    private Vector3 Avoid(Boid currentBoid)
    {
        Vector3 avoidVector = Vector3.zero;

        foreach(Boid boid in boidsList) 
        {
            if(boid.ID != currentBoid.ID) 
            {
                //Debug.Log(Vector3.Distance(boid.transform.position, currentBoid.transform.position));
                if(GetBoidDistance(boid, currentBoid) < collisionDistance) 
                {
                    avoidVector = avoidVector - (boid.transform.position - currentBoid.transform.position);
                }
            }
        }
        return avoidVector;
    }

    private Vector3 MatchingVelocity(Boid currentBoid)
    {
        Vector3 perceivedVelocity = new Vector3();

        foreach(Boid boid in boidsList) 
        {
            if(boid.ID != currentBoid.ID) 
            {
                if(GetBoidDistance(boid, currentBoid) < perceiveVelocity) 
                {
                    perceivedVelocity = perceivedVelocity + boid.velocity;
                }
            }
        }

        perceivedVelocity = perceivedVelocity / (boidsList.Count - 1);

        return (perceivedVelocity - currentBoid.velocity) / 8;
    }*/
}
