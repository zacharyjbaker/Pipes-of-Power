using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private PathManager path;
    [SerializeField] private Hitter hitter;
    [SerializeField] public float moveSpeed = 0.5f;
    public float beatTempo;

    private Transform currentWaypoint;
    [SerializeField] private float nextPointDistance = 0.1f;

    public void AssignPath(PathManager p)
    {
        this.path = p;
    }

    public void AssignHitter(Hitter p)
    {
        this.hitter = p;
    }

    void Start()
    {
        beatTempo = beatTempo / 60f;
        currentWaypoint = path.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;
        currentWaypoint = path.GetNextWaypoint(currentWaypoint);
        //moveSpeed = moveSpeed / 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
        //transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < nextPointDistance)
        {
            currentWaypoint = path.GetNextWaypoint(currentWaypoint);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        if (other.CompareTag("Hitter"))
        {
            hitter.destroyedCount();
            Destroy(gameObject);
        }

        if (other.CompareTag("End"))
        {
            other.gameObject.GetComponent<End>().LoseHeart();
            Destroy(gameObject);
        }

    }
}
