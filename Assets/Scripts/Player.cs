using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour {
	
	protected CharacterController player;
	protected GameManager manager;
	
	public float moveSpeed = 3f;
	protected float rotationSpeed = 90f;
	public float jumpSpeed = 1f;
	
	protected Vector3 move = Vector3.zero;
	protected Vector3 gravity = Vector3.zero;
	
	float cameraRotX = 0f;
	public float cameraPitchMax = 45f;
	
	protected bool jump;
	
	void Start () {
		
		player = GetComponent<CharacterController>();
		manager = GameObject.Find("Level").GetComponent<GameManager>();
		
		if(!player)
		{
			Debug.LogError("Unit.Start() " + name + " has no CharacterController!");
			enabled = false;
		}
	
	}
	
	void Update () {
		
		//Rotation
		
		transform.Rotate(0f, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0f);
		
		cameraRotX -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
		cameraRotX = Mathf.Clamp(cameraRotX, -cameraPitchMax, cameraPitchMax);
		Camera.main.transform.forward = transform.forward;
		Camera.main.transform.Rotate(cameraRotX, 0f, 0f);
		
		//Movement
		
		move = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
		
		move.Normalize();
		
		move = transform.TransformDirection(move);
		
		player.SimpleMove(move * moveSpeed);
	
	}
	
	void OnControllerColliderHit(ControllerColliderHit c){
		string name = c.transform.name;
		if(name.Contains("Food")){
			manager.CollectFood(c.gameObject);
		}
	}
	
	public void SetPosition(Vector3 position){
		
		transform.position = position;
		
	}
}
