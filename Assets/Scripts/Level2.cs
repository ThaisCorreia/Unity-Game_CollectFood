using UnityEngine;
using System.Collections;

public class Level2 : GameManager {

	void Start () {
	
		foodQty = 20;
		seconds = 00f;
		minutes = 4f;
		
		base.Start();
		
	}
	
	void Update () {
	
		base.Update();
		
	}
}
