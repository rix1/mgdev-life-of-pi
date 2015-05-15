using System;
using System.Collections.Generic;

public class GameScore {
	
	public static int scoreElements = 0;
	
	public string name;
	public float score;
	
	
	public GameScore(){
		scoreElements++;
	}
	
	
	public bool setScore(float score){
		if(this.score > score){
			return false;
		}else{
			this.score = score;
			return true;
		}
	}
}