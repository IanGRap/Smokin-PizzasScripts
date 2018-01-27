using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	CarModel carModel;
	CarView carView;

	bool spaceDown = false;
	float spaceEnter;
	float spaceExit;
	List<int> command = new List<int>();
	int[] leftCommand = new int[4];
	int[] rightCommand = new int[4];
	int[] straightCommand = new int[4];
	public float longLength; //I had this at like 0.2

	// Use this for initialization
	void Start () {
		setupCommands ();
	}
	
	// Update is called once per frame
	void Update () {
		if (spaceDown) {
			if (Input.GetKeyUp (KeyCode.Space)) {
				spaceDown = false;
				spaceExit = Time.time;
				determineInput ();
				if (command.Count == 4) {
					determineCommand ();
				}
					
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Space)) {
				spaceDown = true;
				spaceEnter = Time.time;
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
			command.Clear ();
			//return "left";
			CarModel.direction("left"); //assuming this is just taking a string input
		}
		if(checkForIdenticalCommands(command,leftCommand)){
			command.Clear ();
			CarModel.direction("right");
		}
		if(checkForIdenticalCommands(command,leftCommand)){
			command.Clear ();
			CarModel.direction("straight");
		}
		command.Clear ();
	}

	//For CarView's smoke emitting
	public bool SpaceDown(){
		return spaceDown;
	}

	//Used for determining the inputs for the commands
	void setupCommands(){
		setupCommand (leftCommand);
		printArray("left", leftCommand);
		setupCommand (rightCommand);
		printArray ("right", rightCommand);
		setupCommand (straightCommand);
		printArray ("straight", straightCommand);
		checkLoop ();
	}

	//Determines input for an individual command
	void setupCommand(int[] command){
		for(int i=0; i < command.Length; i++){
			float num = Random.Range (0, 2);
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
	void checkLoop(){
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
	}

	//Prints out an array
	void printArray(string name, int[] array){
		string output = name+"[ ";
		for (int i = 0; i < 4; i++) {
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
		for (int i = 0; i < 4; i++) {
			output += array [i];
			if (i < array.Count - 1)
				output += ", ";
		}
		output += "]";
		print (output);
	}
}
