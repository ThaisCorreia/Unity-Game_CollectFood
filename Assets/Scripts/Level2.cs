using UnityEngine;
using System.Collections;

public class Level2 : GameManager {

	void Start () {
	
		foodQty = 2;
		seconds = 0f;
		minutes = 1f;
		
		base.Start();
		
	}
	
	void Update () {
	
		base.Update();
		
	}
}
