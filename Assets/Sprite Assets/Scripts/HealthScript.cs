using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public int hp = 2; // default value

    public bool isEnemy = true;

	public void Awake() {
		
	}

	public void TakeDamage () {
		hp--;
		if(hp < 1) Destroy(gameObject);
	}
}
