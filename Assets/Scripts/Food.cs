using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
	
	public Vector3 rotation;
	protected GameManager manager;
	
	void Start () {
		
		rotation = new Vector3(0f,90f,0f);
			
	}
	
	void Update () {
	
		transform.Rotate(rotation * Time.deltaTime);
		
	}
	
	void OnTriggerEnter(Collider c){
		
		if(c != null){
		
			manager = c.gameObject.GetComponent<Player>().manager;
			
			Debug.Log("Manager: " + manager);
			
			if(gameObject != null && manager != null){
				
				string name = c.transform.name;
				if(name.Contains("Player")){
					manager.CollectFood(gameObject);
				}
			}
			
		}
	}
}
