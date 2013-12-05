using UnityEngine;
using System.Collections;

public class Level3 : GameManager {

	void Start () {
	
		foodQty = 3;
		seconds = 0f;
		minutes = 1f;
		
		base.Start();
		
	}
	
	void Update () {
	
		base.Update();
		
	}
}
