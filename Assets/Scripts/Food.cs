using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
	
	public Vector3 rotation;
	
	void Start () {
		
		rotation = new Vector3(0f,90f,0f);
			
	}
	
	void Update () {
	
		transform.Rotate(rotation * Time.deltaTime);
		
	}
}
