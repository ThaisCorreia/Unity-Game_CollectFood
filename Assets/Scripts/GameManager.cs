using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Player player;
	
	string[] foodObjects;
	
	public static int foodQty;
	
	public static float seconds;
	public static float minutes;
	bool gameOver;
	
	public float counter;
	
	public float xLimit1;
	public float xLimit2;
	public float yLimit1;
	public float yLimit2;
	public float zLimit1;
	public float zLimit2;
	
	public float radiusFood;
	
	public Vector3 initialPosition;
	
	public void Start () {
		
		initialPosition = new Vector3(7.5f,0.73f,-8.9f);
		
		player.SetPosition(initialPosition);
		
		gameOver = false;
		
		xLimit1 = -10.8f;
		xLimit2 = 8f;
		yLimit1 = 0.3f;
		yLimit2 = 1.8f;
		zLimit1 = -9.5f;
		zLimit2 = 9.5f;
		
		radiusFood = 0.5f;
		counter = 0f;
		
		foodObjects = new string[]{"FoodApple","FoodBanana","FoodCandyCane"};
		
		CreateFoodObjects(foodQty);
		
	}
	
	public void Update () {
		
		if(counter == foodQty) gameOver = true;
		if(!gameOver){ 
			
			if(Mathf.Round(seconds) <= 9) GameObject.Find("Timer").guiText.text = minutes + ":0" + seconds.ToString("0");
			else GameObject.Find("Timer").guiText.text = minutes + ":" + seconds.ToString("0");
			if(seconds <= 0){
				if(minutes <= 0){
					gameOver = true;
				}
				else{
					minutes --;
					seconds = 59;
				}
			}
			else{
				seconds -= Time.deltaTime;
			}

		}
		else{
			
			
			
		}
		
		GameObject.Find("Counter").guiText.text = counter + "/" + foodQty;
	
	}
	
	public void CreateFoodObjects(int Qty){
		
		for(int i = 0; i < Qty; i++){
			
			int type = Random.Range(0, foodObjects.Length);
			Vector3 position = calculatePosition();
		    
			Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
			
			Instantiate(Resources.Load(foodObjects[type]), position, rotation);
			
		}
		
	}
	
	public Vector3 calculatePosition(){
		
		Vector3 position = new Vector3(Random.Range(xLimit1,xLimit2),Random.Range(yLimit1,yLimit2),Random.Range(zLimit1,zLimit2));
		var existingObj = Physics.OverlapSphere(position, radiusFood);
		if(existingObj.Length > 0){
			return calculatePosition();
		}
		return position;
		
	}
	
	public void CollectFood(GameObject c){
		
		Destroy(c);
		counter+=1;
		
	}
}
