using UnityEngine;
using System.Collections;

[System.Serializable]
public class Borders {
	public float xMin, zMin, xMax, zMax;
}


public class BallController : MonoBehaviour {

	public float speed_x;
	public float speed_z;
	public float speed;
	public Borders border;

    private float nextTime = 0.0f;
	public  float timeRate;
	
	void FixedUpdate(){

        Vector3 movement = new Vector3 (speed_x, 0.0f, speed_z);

		rigidbody.velocity = movement * speed;


		rigidbody.position = new Vector3 (
			Mathf.Clamp(rigidbody.position.x, border.xMin, border.xMax),
			0.0f,
			Mathf.Clamp(rigidbody.position.z, border.zMin, border.zMax)
		);

		if (Time.time > nextTime) {
			nextTime = Time.time + timeRate;

			if (rigidbody.position.x >= border.xMax ||
				rigidbody.position.x <= border.xMin) {
				speed_x *= -1;
			}
			if (rigidbody.position.z >= border.zMax ||
				rigidbody.position.z <= border.zMin) {
				speed_z *= -1;
			}

		}

   	}

	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.tag == "Player") {
			float playerSpeed = collision.gameObject.rigidbody.velocity.x;
			//Debug.Log (playerSpeed);

			if(playerSpeed == 0) {
				speed_z *= -1;
			} else if(playerSpeed > 0.0f) {
				speed_x = Random.Range(0.2f, 0.6f);
				speed_z *= -1;
			} else {
				speed_z *= -1;
				speed_x = - Random.Range(0.2f, 0.6f);
			}
	
		}
	}


}
