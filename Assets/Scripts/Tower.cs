using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    public Transform shootElement;
    public Transform LookAtObj;
    public int dmg = 10;
    public GameObject bullet;
    public Transform target;
    public float shootDelay;
    bool isShoot;
    void Update()
    {
        if (target)
        {
            Vector3 focus = Vector3.Scale(target.transform.position, new Vector3(1, 0, 1));
            focus.y = LookAtObj.transform.position.y;
            LookAtObj.transform.LookAt(focus);
            if (!isShoot)
            {
                StartCoroutine(shoot());
            }
        }
    }

    IEnumerator shoot()
    {
        isShoot = true;
        yield return new WaitForSeconds(shootDelay);
        GameObject b = GameObject.Instantiate(bullet, shootElement.position, Quaternion.identity) as GameObject;
        b.GetComponent<bulletTower>().target = target;
        b.GetComponent<bulletTower>().twr = this;
        isShoot = false;
    }
}
