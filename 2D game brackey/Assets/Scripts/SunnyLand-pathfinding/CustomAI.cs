using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CustomAI : MonoBehaviour
{
    public Transform eagle;
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int curretWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath() {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

   void OnPathComplete(Path p) {
        if(!p.error){
            path = p;
            curretWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if (curretWaypoint >= path.vectorPath.Count) {
            reachedEndOfPath = true;
            return;
        } else {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[curretWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[curretWaypoint]);
        if (distance < nextWaypointDistance) {
            curretWaypoint++;
        }

        // if (force.x >= 0.01f)
        if (rb.velocity.x >= 0.01f && force.x > 0f)
            eagle.localScale = new Vector3(-4f, 4f, 4f);
        //else if (force.x <= 0.01f)
        else if (rb.velocity.x <= -0.01 && force.x < 0f)
            eagle.localScale = new Vector3(4f, 4f, 4f);
    }
}
