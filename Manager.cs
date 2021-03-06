﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public static Manager instance = null;

	public CarModel car;
	public DeliveryManager delivery;
	private int score;
	
	void Awake () {
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(gameObject);
		}
		score = 0;
	}
	
	void Update () {
		if(car.isDelivering())
		{
			addScore();
			delivery.gotDelivered();
		}
	}
	
	public void addScore()
	{
		score++;
		car.goFaster();
	}
}
