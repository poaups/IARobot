using System.Collections;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public GameObject Bullet;
    public float SpawnBulletTime;
    public Transform TargetBullet;
    public Transform Player;

    private void Start()
    {
        StartCoroutine(SpawnBullet());
    }
    IEnumerator SpawnBullet()
    {
        while (true) 
        {
            yield return new WaitForSeconds(SpawnBulletTime);
            Fct();
        }
    }
    void Fct()
    {
        Instantiate(Bullet, TargetBullet.position, Bullet.transform.rotation);
        Bullet.GetComponent<Balle>().StartMoving(Player);
    }
}
