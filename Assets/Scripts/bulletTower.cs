using UnityEngine;
using System.Collections;

public class bulletTower : MonoBehaviour
{

    public float Speed;
    public Transform target;
    public Tower twr;
    void Update()
    {
        if (target)
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed);
        if (!target)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyGoblin") && !target.GetComponent<MoveToWayPoints>().isDeath)
        {
            target.GetComponent<MoveToWayPoints>().hp.GetComponent<HpBar>().Dmg(twr.dmg);
            Destroy(gameObject);
        }
    }
}
