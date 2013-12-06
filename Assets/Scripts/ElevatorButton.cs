using UnityEngine;
using System.Collections;

public class ElevatorButton : MonoBehaviour {

	private ElevatorManager manager;
	public AudioClip audio;
	
	void Start () {
		
		manager = GameObject.Find("Elevator").GetComponent<ElevatorManager>();
		
		manager.SetButton(false, transform.name);
		
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c){
		
		if(c.transform.name == "Player"){
			
			if(!manager.GetButton()){
				
				transform.renderer.material.color = Color.green;
				transform.audio.PlayOneShot(audio);
				manager.SetButton(true,transform.name);
				
			}
			
		}
		
	}
	
	public void DisableButton(){
		
		transform.renderer.material.color = Color.red;
		
	}
}
