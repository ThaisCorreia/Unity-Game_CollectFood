using UnityEngine;
using System.Collections;

public class Level1 : GameManager {

	void Start () {
	
		foodQty = 1;
		seconds = 0f;
		minutes = 1f;
		
		base.Start();
		
	}
	
	void Update () {
	
		base.Update();
		
	}
}
