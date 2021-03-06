﻿using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{
    public int damage = 1;
	public float bulletspeed = 3;
	public bool isEnemyShot = false;

	private Vector3 dir;

	void Start ()
	{
		if(dir == null) SetDirection("right");
        Destroy (gameObject, 5);
	}

	public void SetDirection(string face)
	{
		dir = (face == "right") ? Vector3.right : Vector3.left;
		transform.localScale = new Vector3((face == "right" ? 2 : -2), 2, 1);
	}

	void Update () {
		transform.Translate(dir * bulletspeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if((collider.gameObject.tag != "Player") != isEnemyShot) {
			collider.gameObject.SendMessage("TakeDamage", null, SendMessageOptions.DontRequireReceiver);

//			this.gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}
}
