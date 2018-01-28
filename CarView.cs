﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarView : MonoBehaviour {

	public AudioSource smokeSound;
	public AudioSource crashSource;
	public AudioSource deliverySource;
	public AudioSource skreetSource;
	public List <AudioClip> crashSounds = new List <AudioClip> ();
	public List <AudioClip> deliverySounds = new List <AudioClip> ();

	private ParticleSystem smokeEmitter;
	private CarModel carModel;
	private bool smoking;

	void Awake(){
		smokeEmitter = GetComponent <ParticleSystem> ();
		carModel = GetComponent <CarModel> ();
		smoking = false;
	}

	void Update (){
		if (carModel.SpaceDown () && ! smoking) {
			smoking = true;
			//smokeEmitter.Play ();
			//smokeSound.Play ();
		} else if (smoking) {
			smoking = false;
			//smokeEmitter.Pause ();
			//smokeSound.Stop ();
		}
	}

	public void CrashSound(){
		crashSource.clip = crashSounds[ Random.Range( 0, crashSounds.Count-1 )];
		crashSource.Play ();
	}

	public void DeliverySound(){
		deliverySource.clip = deliverySounds[ Random.Range( 0, deliverySounds.Count-1 )];
		deliverySource.Play ();
	}

	public void Skreet(){
		skreetSource.Play ();
	}
}
