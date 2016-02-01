using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {
	public GameObject gameOverUI;
	public GameObject pauseMenuUI;
	public GameObject mainUI;
	public Slider healthBar;
	public Image healthBarFill;

	Gauntletcontrollerscript player;

	// Use this for initialization
	void Start () {
		// this seems hacky as all get out, but I guess it's how Unity does it...
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Gauntletcontrollerscript>();

		healthBar.maxValue = player.maxhp ();
		UpdateHealthBar ();

		gameOverUI.SetActive (false);
		pauseMenuUI.SetActive (false);

		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			PauseControl ();
		} else if (player == null) {
			if (Time.timeScale == 0) {
				gameOverUI.SetActive (true);
				mainUI.SetActive (false);

				if (Input.anyKeyDown)
					Reload ();
			}
		} else {
			UpdateHealthBar ();
		}
	}

	private void UpdateHealthBar () {
		float oldValue = healthBar.value;
		int newValue = player.hp ();

		healthBar.value = newValue;

		if (oldValue != newValue) {
			healthBarFill.color = Color.Lerp (Color.red, Color.green, healthBar.value / healthBar.maxValue);
		}
	}

	public void Reload() {
		Application.LoadLevel (Application.loadedLevel);
	}

	private void PauseControl () {
		bool pauseTime = Time.timeScale == 1;

		Time.timeScale = pauseTime ? 0 : 1;
		pauseMenuUI.SetActive (pauseTime);
		mainUI.SetActive (!pauseTime);
	}
}
