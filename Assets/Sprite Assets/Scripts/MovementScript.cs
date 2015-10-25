using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

    public Vector2 speed =new Vector2(50, 0);


	void Update () {

    float inputX = Input.GetAxis("Horizontal");

    Vector3 movement = new Vector3(Speed.x * inputX, 0, 0);

    movement *= Time.deltaTime;

    transform.Translate (movement);
	
	}
}
