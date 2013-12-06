using UnityEngine;
using System.Collections;

public class ElevatorBody : MonoBehaviour {

	private ElevatorManager manager;
	
	void Start () {
	
		manager = GameObject.Find("Elevator").GetComponent<ElevatorManager>();
		
	}
	
	void Update () {
	
	}
	
	void OnTriggerStay(Collider c){
		if(c.transform.name == "Player"){
			manager.playerInside = true;
			
		}
	}
	
	void OnTriggerExit(Collider c){
		
		if(c.transform.name == "Player"){
			manager.playerInside = false;
			
		}
	}
}
