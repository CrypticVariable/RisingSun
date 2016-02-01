using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public int maxhp = 2; // default value
	private int hp;

	public void Start () {
		hp = maxhp;
	}

	public void TakeDamage () {
		hp--;
		if(hp < 1) Destroy(gameObject);
	}

	public int GetHp () {
		return hp;
	}

	void ShowDamagePopup () {
		// maybe show a little number popup?
	}

	void DamageFlash () {
		// Flash on and off?
	}
}
