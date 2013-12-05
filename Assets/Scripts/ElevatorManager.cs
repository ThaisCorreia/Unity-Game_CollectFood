using UnityEngine;
using System.Collections;

public class ElevatorManager : MonoBehaviour {

	public 
	
	void Start () {
	
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c){
		
		if(c.transform.name == "Player"){
			
			transform.renderer.material.color = Color.green;
			
		}
		
	}
}
