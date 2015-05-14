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
		
	}
	
	public LevelScore(string name){
		scoreElements++;
		this.name = name;
		g1 = new GameScore();
		g2 = new GameScore();
		g3 = new GameScore();
	}
	
	public void setScore(int singer, float score){
		getSinger(singer).score = score;
	}
	
	public void updateScore(int singer, float score){
		getSinger(singer).score += score;
	}
	
	public void resetScore(int singer){
		getSinger(singer).score = 0;
	}
	
	public float getLevelScore(){
		float total = 0;
		
		total += g1.score;
		total += g2.score;
		total += g3.score;
		
		return total;
	}
	
	public float getScore(int singer){
		return getSinger(singer).score;
	}
	
	public GameScore getSinger(int singer){
		switch (singer)
		{
			case 1:
			return g1;
			break;
			case 2:
			return g2;
			break;
			case 3:
			return g3;
			break;
			default:
			return null;
			break;
		}
	}
}