using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioSource songOne, songTwo;

	private AudioSource[] songs = new AudioSource[2];

	void Awake() {
		songs [0] = songOne;
		songs [1] = songTwo;
	}

	void Start () {
		songs [Random.Range (0, 2)].Play ();
	}
}
