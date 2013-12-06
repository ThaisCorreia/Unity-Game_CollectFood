using UnityEngine;
using System.Collections;

public class Level1 : GameManager {

	void Start () {
	
		foodQty = 10;
		seconds = 0f;
		minutes = 4f;
		
		base.Start();
		
	}
	
	void Update () {
	
		base.Update();
		
	}
}
