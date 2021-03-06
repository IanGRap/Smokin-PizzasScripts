﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	CarModel carModel;
	//CarView carView;

	bool spaceDown = false;
	float spaceEnter;
	float spaceExit;
	List<int> command = new List<int>();
	int[] leftCommand = new int[3]; // 
	int[] rightCommand = new int[3];
	int[] straightCommand = new int[3];
	public float longLength; //I had this at like 0.2
	public float timeOut;

	// Use this for initialization
	void Start () {
		setupCommands ();
		carModel = GetComponent <CarModel> ();
	}
	
	// Update is called once per frame
	void Update () {
	printList ("stuff", command);
		if (spaceDown) {
			if (Input.GetKeyUp (KeyCode.Space)) {
				spaceDown = false;
				spaceExit = Time.time;
				determineInput ();
				if (command.Count == 3) {
					determineCommand ();
				}
					
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Space)) {
				spaceDown = true;
				spaceEnter = Time.time;
			} else {
				if(Time.time - spaceExit >= timeOut) {
					command.Clear();
				}
			}
		}
	}

	//Figures out if is a dot or dash
	string determineInput(){
		if (spaceExit - spaceEnter < longLength) {
			command.Add (0);
			return "short";
		} else {
			command.Add (1);
			return "long";
		}
	}

	//Takes 4 inputs and figures out if it is a command
	void determineCommand(){
		if(checkForIdenticalCommands(command,leftCommand)){
			//command.Clear ();
			//return "left";
			carModel.setDirection("left"); //assuming this is just taking a string input
		}
		if(checkForIdenticalCommands(command,rightCommand)){
			//command.Clear ();
			carModel.setDirection("right");
		}
		if(checkForIdenticalCommands(command,straightCommand)){
			//command.Clear ();
			carModel.setDirection("straight");
		}
		command.Clear ();
	}

	//For CarView's smoke emitting
	public bool SpaceDown(){
		return spaceDown;
	}

	//Used for determining the inputs for the commands
	public void setupCommands(){
		setupCommand (leftCommand);
		setupCommand (rightCommand);
		setupCommand (straightCommand);
		checkLoop ();
		printArray("left", leftCommand);
		printArray ("right", rightCommand);
		printArray ("straight", straightCommand);
	}

	//Determines input for an individual command
	void setupCommand(int[] command){
		for(int i=0; i < command.Length; i++){
			float num = Random.Range(0, 2);
			if (num >= .5) {
				command [i] = 1;
			} else {
				command [i] = 0;
			}
		}
	}

	//Checks if two arrays are identical
	bool checkForIdenticalCommands(int[] A, int[] B){
		for (int i = 0; i < A.Length; i++) {
			if (A [i] != B [i]) {
				return false;
			}
		}
		return true;
	}

	//Checks if an array or a list is identical
	bool checkForIdenticalCommands(List<int> A, int[] B){
		for (int i = 0; i < A.Count; i++) {
			if (A [i] != B [i]) {
				return false;
			}
		}
		return true;
	}

	//Recursive function for making sure the commands are not identical
	/*void checkLoop(){
		if (checkForIdenticalCommands (leftCommand, rightCommand)) {
			setupCommand (leftCommand);
			checkLoop ();
		}
		if (checkForIdenticalCommands (rightCommand, straightCommand)) {
			setupCommand (rightCommand);
			checkLoop ();
		}
		if (checkForIdenticalCommands (leftCommand, straightCommand)) {
			setupCommand (straightCommand);
			checkLoop ();
		}
		if (checkForIdenticalCommands (leftCommand, rightCommand))
		{
			setupCommand(leftCommand);
			checkLoop();
		}
		if (checkForIdenticalCommands (leftCommand, rightCommand))
		{
			setupCommand(rightCommand);
			checkLoop();
			
		}
	}*/
	
	void checkLoop(){
		if (checkForIdenticalCommands (leftCommand, rightCommand)) {
			setupCommand (rightCommand);
			checkLoop ();
		}
		if (checkForIdenticalCommands (rightCommand, straightCommand)) {
			setupCommand (straightCommand);
			checkLoop ();
		}
		if (checkForIdenticalCommands (leftCommand, straightCommand)) {
			setupCommand (straightCommand);
			checkLoop ();
		}
	}


	//Prints out an array
	void printArray(string name, int[] array){
		string output = name+"[ ";
		for (int i = 0; i < 3; i++) {
			output += array [i];
			if (i < array.Length - 1)
				output += ", ";
		}
		output += "]";
		print (output);
	}

	//Prints out a list
	void printList(string name, List<int> array){
		string output = name+"[ ";
		for (int i = 0; i < array.Count; i++) {
			output += array [i];
			if (i < array.Count - 1)
				output += ", ";
		}
		output += "]";
		print (output);
	}
}
