using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

	public float x;
	public float y;
	public float z;
	
	public Vector3 getTargetLoc()
	{
		return new Vector3(x,y,z);
	}
}
