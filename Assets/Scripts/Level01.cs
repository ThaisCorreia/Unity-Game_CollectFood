using UnityEngine;
using System.Collections;

public class Level01 : GameManager {

	void Start () {
	
		foodQty = 5;
		seconds = 0f;
		minutes = 2f;
		
		base.Start();
		
	}
	
	void Update () {
	
		base.Update();
		
	}
}
