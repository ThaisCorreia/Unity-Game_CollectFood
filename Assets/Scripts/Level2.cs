using UnityEngine;
using System.Collections;

public class Level2 : GameManager {

	void Start () {
	
		foodQty = 20;
		seconds = 0f;
		minutes = 6f;
		
		base.Start();
		
	}
	
	void Update () {
	
		base.Update();
		
	}
}
