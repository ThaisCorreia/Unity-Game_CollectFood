using UnityEngine;
using System.Collections;

public class Level3 : GameManager {

	void Start () {
	
		foodQty = 30;
		seconds = 0f;
		minutes = 8f;
		
		base.Start();
		
	}
	
	void Update () {
	
		base.Update();
		
	}
}
