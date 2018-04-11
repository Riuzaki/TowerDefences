using UnityEngine;
using System.Collections;

public class MoveToWayPoints : MonoBehaviour
{

    public float Speed;
    public Transform[] waypoints;
    int curWaypointIndex = 0;
    public GameObject hp;
    private Animation animateEnemy = null;
    public bool isDeath = false;
    private void Start()
    {
        animateEnemy = gameObject.GetComponent<Animation>();
    }
    void Update()
    {
        if (!isDeath)
        {
            if (curWaypointIndex < waypoints.Length)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[curWaypointIndex].position, Time.deltaTime * Speed);
                transform.LookAt(waypoints[curWaypointIndex].position);
                if (Vector3.Distance(transform.position, waypoints[curWaypointIndex].position) < 0.5f)
                {
                    curWaypointIndex++;
                }
            }
            if (hp.GetComponent<HpBar>().CurHp <= 0)
            {
                animateEnemy.CrossFade("death");
                Destroy(hp);
                StartCoroutine(deathEnemy());
            }
        }
    }
    IEnumerator deathEnemy()
    {
        isDeath = true;
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
}
