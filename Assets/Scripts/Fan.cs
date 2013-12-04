using UnityEngine;
using System.Collections;

public class Fan : MonoBehaviour {
	
	private Vector3 rotation;
	private float speed;

	void Start () {
	
		rotation = new Vector3(0f,0f,90f);
		speed = 10f;
		
	}
	
	void Update () {
		
		transform.Find("Fan_002").Rotate(rotation * Time.deltaTime * speed);
		
	}
}
