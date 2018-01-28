using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour {

	public List<GameObject> nodes;
	private int activeNode;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < nodes.Count; i++)
		{
			nodes[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void gotDelivered()
	{
		nodes[activeNode].SetActive(false);
		activeNode = Random.Range(0, nodes.Count);
		nodes[activeNode].SetActive(true);
	}
}
