using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour {
	
	protected CharacterController player;
	public LevelManager levelManager;
	public GameManager manager;
	
	public float moveSpeed = 3f;
	protected float rotationSpeed = 90f;
	public float jumpSpeed;
	
	protected Vector3 move = Vector3.zero;
	protected Vector3 gravity = Vector3.zero;
	
	float cameraRotX = 0f;
	public float cameraPitchMax = 45f;
	
	protected bool jump;
	
	protected bool active;
	
	void Start () {
		
		player = GetComponent<CharacterController>();
		
		active = true;
		
		if(!player)
		{
			Debug.LogError("Unit.Start() " + name + " has no CharacterController!");
			enabled = false;
		}
		
		jumpSpeed = 4f;
	
	}
	
	void Update () {
		
		levelManager = GameObject.Find("Manager").GetComponent<LevelManager>();
		if(levelManager != null ) manager = levelManager.manager;
		
		if(active){
		
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
			
			//Jump
			
			if(Input.GetKey(KeyCode.Space) && player.isGrounded) jump = true;
			
			move *= moveSpeed;
			if(!player.isGrounded) gravity += Physics.gravity * Time.deltaTime;
			else
			{
				gravity = Vector3.zero;
				if(jump)
				{
					gravity.y = jumpSpeed;
					jump = false;
				}
			}
			move += gravity;
			
			//Moving
			player.Move(move * Time.deltaTime);
			
		}
	
	}
	
	public void SetPosition(Vector3 position){
		
		transform.position = position;
		
	}
	
	public void SetRotation(Quaternion rotation){
		
		transform.rotation = rotation;
		
	}
	
	public void SetActive(bool act){
		active = act;
	}
}
