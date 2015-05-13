using System;
using System.Collections.Generic;

public class LevelScore {
	
	public static int scoreElements = 0;
	
	public string name;
	public float score;
	
	public GameScore g1;
	public GameScore g2;
	public GameScore g3;
	
	
	public LevelScore(){
		scoreElements++;
		
		g1 = new GameScore();
		g2 = new GameScore();
		g3 = new GameScore();
	}
	
	public float getScore(){
		float total = 0;
		
		total += g1.score;
		total += g2.score;
		total += g3.score;
		
		return total;
	}
	
}