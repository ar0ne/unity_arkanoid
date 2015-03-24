using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	public float max_x;
	public float min_x;


	void FixedUpdate(){
		float move_h = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (move_h , 0.0f, 0.0f);

		rigidbody.velocity = movement * speed;
		rigidbody.position = new Vector3 (
			Mathf.Clamp(rigidbody.position.x, min_x, max_x),
			0.0f,
			0.0f
		);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
	}

}
