using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModel : MonoBehaviour {

	CarController control;
	CarView view;

	public float speed;

	private Vector3 direction;
	private bool delivering;
	private bool onGround;
	private Rigidbody rb;
	
	void Start()
	{
		control = GetComponent<CarController>();
		//view = GetComponent<CarView>();
		direction = Vector3.zero;
		rb = GetComponent <Rigidbody> ();
	}
	
	void Update()
	{
		delivering = false;
		if (onGround) {
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			transform.Rotate(direction);
			//rb.velocity = direction * speed;
		}

	}
	
	public void setDirection(string update)
	{
		if(update == "left")
			direction = Vector3.down;
		if(update == "right")
			direction = Vector3.up;
		if(update == "straight")
			direction = Vector3.zero;
		Debug.Log(direction);
	}
	
	public bool SpaceDown()
	{
		return control.SpaceDown();
	}
	
	void OnTriggerEnter(Collider trigger)
	{
		if(trigger.tag == "delivery")
			delivering = true;
		if(trigger.tag == "boundary")
			transform.position += trigger.GetComponent<Boundary>().getTargetLoc();
	}
	
	public bool isDelivering()
	{
		return delivering;
	}
	
	public void goFaster()
	{
		speed++;
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "ground")
			onGround = true;
	}

	void OnCollisionLeave(Collision collision){
		if (collision.gameObject.tag == "ground")
			onGround = false;
	}

	public void OffGround(){
		onGround = false;
	}
}
