using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour {

	public float force = 10000f;

	void OnCollisionEnter(Collision collision){
		
		if (collision.gameObject.tag == "Car") {

			Debug.Log ("Collision");
			
			CarController carController = collision.gameObject.GetComponent<CarController> ();
			carController.setupCommands ();

			collision.gameObject.GetComponent <CarView> ().CrashSound ();

			collision.gameObject.GetComponent <CarModel> ().OffGround ();

			Vector3 direction = collision.gameObject.transform.position - this.gameObject.transform.position;
			direction = Vector3.Normalize (direction);
			direction = new Vector3 (direction.x, 0.6f, direction.z);

			collision.gameObject.GetComponent <Rigidbody> ().AddForce (direction * force);
		}
			
	}
}
