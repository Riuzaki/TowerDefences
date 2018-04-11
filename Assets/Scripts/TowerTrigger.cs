using UnityEngine;
using System.Collections;

public class TowerTrigger : MonoBehaviour
{

    public Tower twr;
    public bool lockE;
    public GameObject curTarget;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyGoblin") && !lockE)
        {
            if (!other.gameObject.GetComponent<MoveToWayPoints>().isDeath)
            {
                twr.target = other.gameObject.transform;
                curTarget = other.gameObject;
                lockE = true;
            }

        }
    }
    void Update()
    {
        if (!curTarget)
        {
            lockE = false;
        }
        else
        {
            if (curTarget.GetComponent<MoveToWayPoints>().isDeath)
            {
                twr.target = null;
                curTarget = null;
                lockE = false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyGoblin") && other.gameObject == curTarget)
        {
            lockE = false;
        }
    }

}
