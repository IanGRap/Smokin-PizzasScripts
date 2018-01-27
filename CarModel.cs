using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModel : MonoBehaviour {

	CarController control;
	CarView view;

	public float speed;
	private Vector3 direction;
	
	void Start()
	{
		control = GetComponent<CarController>();
		//view = GetComponent<CarView>();
		direction = Vector3.zero;
	}
	
	void Update()
	{
		transform.Translate(Vector3.right * speed * Time.deltaTime);
		transform.Rotate(direction);
	}
	
	public void setDirection(string update)
	{
		if(update == "left")
			direction = Vector3.forward;
		if(update == "right")
			direction = Vector3.back;
		if(update == "straight")
			direction = Vector3.zero;
	}
	
	public bool SpaceDown()
	{
		return control.SpaceDown();
	}
}
