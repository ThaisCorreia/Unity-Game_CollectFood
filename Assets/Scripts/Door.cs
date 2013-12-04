using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public AudioClip audioOpen;
	public AudioClip audioClose;
	private bool open = false;
	private bool exit = true;
	private float timerLimit;
	private float timer;
	
	void Start () {
		
		timerLimit = 2f;
		timer = timerLimit;
	
	}
	
	void Update () {
		
		if(timer > 0){
			timer -= Time.deltaTime;
		}
		else if(open && exit) CloseDoor();
			
	}
	
	void OnTriggerEnter(Collider c){
		
		if(c.transform.name == "Player" && !open){
			
			transform.animation.CrossFade("Open");
		
			transform.audio.PlayOneShot(audioOpen);
			
			open = true;
			
			timer = timerLimit;
			
		}
		
	}
	
	void OnTriggerStay(Collider c){
		if(c.transform.name == "Player" && open){
			exit = false;
		}
	}
	
	void OnTriggerExit(Collider c){
		
		if(c.transform.name == "Player" && open && timer <= 0){
			CloseDoor();
		}
		exit = true;
		
	}
	
	void CloseDoor(){
		
		transform.animation.CrossFade("Close");
	
		transform.audio.PlayOneShot(audioClose);
		
		open = false;
		
		timer = timerLimit;
		
	}
	
}
