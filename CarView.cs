using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarView : MonoBehaviour {

	public AudioSource smokeSound;

	private ParticleSystem smokeEmitter;
	private CarModel carModel;
	private bool smoking;

	void Awake(){
		smokeEmitter = GetComponent <ParticleEmitter> ();
		carModel = GetComponent <CarModel> ();
		smoking = false;
	}

	void Update (){
		if (carModel.SpaceDown () && ! smoking) {
			smoking = true;
			smokeEmitter.Play ();
			smokeSound.Play ();
		} else if (smoking) {
			smoking = false;
			smokeEmitter.Pause ();
			smokeSound.Stop ();
		}
	}
}
