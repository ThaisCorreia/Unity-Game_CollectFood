using UnityEngine;
using System.Collections;

public class Level1 : GameManager {

	void Start () {
	
		foodQty = 10;
		seconds = 30f;
		minutes = 3f;
		
		base.Start();
		
	}
	
	void Update () {
	
		base.Update();
		
	}
}
