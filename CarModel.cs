using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModel : MonoBehaviour {

	public float speed;
	private Vector3 direction;
	
	void Start()
	{
		direction = Vector3.zero;
	}
	
	void Update()
	{
		transform.Translate(Vector3.right * speed * Time.deltaTime);
		transform.Rotate(direction);
	}
	
	public void setDirection(Vector3 vector)
	{
		direction = vector;
	}
}
