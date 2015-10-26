using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public int damage = 1;

    public bool isEnemyShot = false;
    internal float bulletspeed;

    void Start ()
    {
        Destroy(gameObject, 20);
    }
    void Update () {
        transform.Translate(Vector3.right * bulletspeed * Time.deltaTime);
	}
    void OnBecameInvisible () {
        this.gameObject.SetActive(false);
    }
}
