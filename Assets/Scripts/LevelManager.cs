using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private Player player;
	
	string[] levels;
	public AudioClip audioFood;
	private bool endOfGame;
	
	private int level;
	
	private float timer;
	private float timerLimit;
	
	public GameManager manager;
	
	void Start () {
		
		player = GameObject.Find("Player").GetComponent<Player>();
	
		endOfGame = false;
		
		levels = new string[]{"Level1_","Level2_","Level3_"};
		
		level = 1;
		
		timerLimit = 2.0f;
		timer = timerLimit;
		
		LoadNextLevel(false); 
		
	}
	
	void Update () {
		
		GameObject obj = GameObject.Find("Level" + this.level + "(Clone)");
		if(obj != null) manager = obj.GetComponent<GameManager>();
		
		if(endOfGame){
			if(timer > 0){
				timer -= Time.deltaTime;
			}
			else{
				
				player.SetActive(true);
				endOfGame = false;
				this.level = 1;
				timer = timerLimit;
				LoadNextLevel(false);
				
			}
		}
	
	}
	
	public void LoadNextLevel(bool nextLevel = true){
		
		if(nextLevel) ++this.level;
		
		string levelName = "Level" + this.level + "_";
		
		bool valid = false;
		
		foreach(string l in levels){
			if(l == levelName){ 
				valid = true;
				break;
			}
		}
		
		if(!valid){
			
			player.SetActive(false);
			endOfGame = true;
			levelName = levels[0];
			
		}else{
			
			DestroyObjects();
			Object newLevel = Resources.Load(levelName.Replace("_",""));
			Instantiate(newLevel, new Vector3(), new Quaternion());
			
			manager = GameObject.Find(levelName.Replace("_","") + "(Clone)").GetComponent<GameManager>();
			
			GameObject.Find("Level Title").guiText.text = "Level " + this.level;
		}
	}
	
	private void DestroyObjects(){
		
		foreach(string l in levels){
			
			string name = l.Replace("_","") + "(Clone)";
			GameObject obj = GameObject.Find(name);
			Destroy(obj);
			
		}
		
	}
	
	public void PlayAudioFood(){
		transform.audio.PlayOneShot(audioFood);
	}
	
	void OnGUI(){
		
		if(endOfGame)
		{
			int width = Screen.width;
			int height = Screen.height;
			GUI.Box(new Rect(0,0,width,height), "End of Game!");
		}
		
	}
}
