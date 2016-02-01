using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour {
	private string text;
	private bool showing = false;
	Text textObject;

	// Use this for initialization
	void Start () {
		textObject = GetComponent<Text>();
		text = textObject.text;

		Invoke("Flash", 1);
	}

	private void Flash() {
		showing = !showing;

		textObject.text = showing ? text : "";
		Invoke("Flash", 1);
	}
}
