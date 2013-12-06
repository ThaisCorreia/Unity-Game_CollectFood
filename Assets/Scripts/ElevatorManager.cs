using UnityEngine;
using System.Collections;

public class ElevatorManager : MonoBehaviour {

	private GameObject player;
	
	private bool openDoor;
	private bool doorIsOpen;
	private bool pressedButton;
	private bool moveElevator;
	private bool exit;
	private bool doorIsClosed;
	private bool going;
	public bool playerInside;
	
	private string button;
	
	public Vector3 floor1Location;
	public Vector3 floor2Location;
	private float targetPosition = 0f;
	
	public Transform body;
	public Transform doors;
	public Transform doors2;
	public Transform button1;
	public Transform button2;
	public Transform button3;
	
	float timer;
	float timerLimit;
	
	float speed;
	
	void Start () {
		
		player = GameObject.Find("Player");
		
		body = transform.Find("Body");
		doors = transform.Find("Doors");
		doors2 = transform.Find("Doors2");
		button1 = transform.Find("Button1");
		button2 = transform.Find("Button2");
		button3 = body.Find("Button3");
		
		floor1Location = new Vector3(body.position.x, 0.2787772f, body.position.z);
		floor2Location = new Vector3(body.position.x, 2.789611f, body.position.z);
		
		timerLimit = 1f;
		timer = timerLimit;
		
		openDoor = false;
		doorIsOpen = false;
		moveElevator = false;
		exit = false;
		doorIsClosed = true;
		going = false;
		
		speed = 0.5f;
	}
	
	void Update () {

		if(openDoor){
				
			doorIsClosed = false;
			if(timer > 0){
				timer -= Time.deltaTime;
			}
			else{
				OpenDoor();
			}
			
		}
		else if(doorIsOpen){
			
			if(timer > 0){
				timer -= Time.deltaTime;
			}
			else if(exit){
				if(button == button1.name) doors.animation.CrossFade("CloseElevator");
				else if(button == button2.name) doors2.animation.CrossFade("CloseElevator");
				else{
					if(body.position.y == floor2Location.y) doors2.animation.CrossFade("CloseElevator");
					else doors.animation.CrossFade("CloseElevator");
				}
				timerLimit = 1f;
				timer = timerLimit;
				exit = false;
				doorIsClosed = true;
			}
			else if(doorIsClosed){
				doorIsOpen = false;
			}
			
		}
		
		if(moveElevator && doorIsClosed){
		
			MoveElevator();
			if(!moveElevator){
				
				if(going){
					openDoor = true;
					moveElevator = true;
					going = false;
					targetPosition = (targetPosition == floor1Location.y) ? floor2Location.y : floor1Location.y;
				}
				else{
					button = (button == button1.name) ? button2.name : button1.name;
					openDoor = true;
				}
				
			}
			
		}
	
	}
	
	void OpenDoor(){
		
		if(!doorIsOpen){
			if(button == button1.name) doors.animation.CrossFade("OpenElevator");
			else if(button == button2.name) doors2.animation.CrossFade("OpenElevator");
			else{
				if(body.position.y == floor2Location.y) doors2.animation.CrossFade("OpenElevator");
				else doors.animation.CrossFade("OpenElevator");
			}
			timer = timerLimit;
			doorIsOpen = true;
			exit = true;
			doorIsClosed = false;
		}
		else{
			openDoor = false;
			pressedButton = false;
		}
		
		timerLimit = 2f;
	    timer = timerLimit;	
		
	}
	
	void MoveElevator(){
		
		if(targetPosition == floor1Location.y && body.position.y >= floor2Location.y){
			body.position = floor2Location;
			moveElevator = false;
		}
		else if(targetPosition == floor2Location.y && body.position.y <= floor1Location.y){
			body.position = floor1Location;
			moveElevator = false;
		}
		else{
			Vector3 newPosition = new Vector3();
			Vector3 playerPosition = new Vector3();
			
			if(targetPosition == floor1Location.y){
				newPosition.y = body.position.y + Time.deltaTime * speed;
			}
			else newPosition.y = body.position.y - Time.deltaTime * speed;
			newPosition.x = body.position.x;
			newPosition.z = body.position.z;
			body.position = newPosition;
			if(playerInside){
				playerPosition.y = body.position.y + Time.deltaTime * speed + 0.3808894f + 0.2f;
				playerPosition.x = player.transform.position.x;
				playerPosition.z = player.transform.position.z;
				player.transform.position = playerPosition;
			}
		}
		
	}
	
	void OnTriggerEnter(Collider c){
		
		if(c.transform.name == "Player"){
			
			
			
		}
		
	}
	
	void OnTriggerStay(Collider c){
		
		if(c.transform.name == "Player" && doorIsOpen){
			
			exit = false;
			
		}
		
	}
	
	void OnTriggerExit(Collider c){
		
		if(c.transform.name == "Player" && doorIsOpen){
			
			exit = true;
			
		}
		
	}
	
	float VerifyLocation(){
		
		if(body.position.y.ToString("f1") == floor2Location.y.ToString("f1")) return floor2Location.y;
		if(body.position.y.ToString("f1") == floor1Location.y.ToString("f1")) return floor1Location.y;
		return 0f;
	}
	
	public void SetButton(bool pressed, string bt){
		
		timerLimit = 1f;
		timer = timerLimit;
		
		if(!pressed) pressedButton = pressed;
		else{
			
			if(!openDoor && !moveElevator && !doorIsOpen){		

				pressedButton = pressed;
				button = bt;
				
				if(button == button3.name){
					
					openDoor = true; 
					moveElevator = false;
					
				}
				else{
					if(button == button1.name) targetPosition = floor2Location.y;
					else targetPosition = floor1Location.y;
					
					if(targetPosition == VerifyLocation()){
						moveElevator = true;
						going = true;
					}
					else if(VerifyLocation() != 0f){
						openDoor = true; 
						moveElevator = true;
						if(button == button1.name) targetPosition = floor1Location.y;
						else targetPosition = floor2Location.y;
					}
				}
					
			}
			
		}
		
	}
	
	public bool GetButton(){
		return pressedButton;
	}
}
