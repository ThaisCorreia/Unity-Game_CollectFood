using UnityEngine;
using System.Collections;

public class Level02 : GameManager {

	void Start () {
	
		foodQty = 10;
		seconds = 50f;
		minutes = 1f;
		
		base.Start();
		
	}
	
	void Update () {
	
		base.Update();
		
	}
}
