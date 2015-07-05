using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;
	bool colliding = false;

	void FixedUpdate () {

		float moveHorizontal = 0;
		float moveVertical = 0;

		if (Input.GetKey (KeyCode.UpArrow))
						moveVertical = 1;
				else if (Input.GetKey (KeyCode.DownArrow))
						moveVertical = -1;

		if (Input.GetKey (KeyCode.LeftArrow))
			moveHorizontal = -1;
		else if (Input.GetKey (KeyCode.RightArrow))
			moveHorizontal = 1;

		if (moveHorizontal != 0 && moveVertical != 0) {
			moveHorizontal /= 1.5f;
			moveVertical /= 1.5f;
		}

		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

		GetComponent<Rigidbody2D>().velocity = movement * speed;
		GetComponent<Rigidbody2D>().drag = 0;
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		Debug.Log ("Colidiu");
	}
}
