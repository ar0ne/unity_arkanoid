using UnityEngine;
using System.Collections;

public class DestroyByCollide : MonoBehaviour {

	private BallController ballController;

	void Start(){
		GameObject ballControllerObject = GameObject.FindWithTag ("Ball");
		if (ballControllerObject != null) {
			ballController = ballControllerObject.GetComponent<BallController>();
		} 

		if(ballController == null) {
			Debug.Log ("Can't find Ball Object!");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Ball") {
			Destroy(gameObject);		
			if(ballController.speed_z < 0 || ballController.speed_z > 0){
				if(ballController.speed_x != 0){
					ballController.speed_z *= -1;
				}else{
					ballController.speed_z = Random.Range (-0.6f, 0.6f);
				}
			}else{
				ballController.speed_z = Random.Range (-0.6f, 0.6f);
			}
		}

	}

}
