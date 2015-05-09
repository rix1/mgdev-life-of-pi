using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class g2_Pattern{
	
	public static List<GameObject> masterTiles = new List<GameObject>(); 	
	private List<GameObject> tiles = new List<GameObject>();
	private List<string> stringPattern = new List<string>();
	private List<Vector3> spawnLocation = new List<Vector3>();
	
	private string name;
	
	// defPos - default position 
	private Vector3 defPos = new Vector3(-1.5f, 0);
	
	public g2_Pattern(string name, List<GameObject> tiles, float y){
		masterTiles = tiles;
		this.name = name;
		this.tiles = tiles;
		setLocation(y);
		shuffle();
	}
	
	public GameObject getTile(int i){
		return tiles[i];
	}
	
	public Vector3 getSpawn(int i){
		return spawnLocation[i];
	}
	
	void setLocation(float y){
		
		for (int i = 0; i < 4; i++)
		{
			Vector3 pos = new Vector3(defPos.x + i, y, defPos.y);
			spawnLocation.Add(pos);	
		}
	}
	
	public void shuffle(){
		GameObject random;
		List<GameObject> newConfiguration = new List<GameObject>();
		stringPattern.Clear();

		// TODO: Room for improvement: Only shuffle location, not game objects.
		for (int i = 0; i < 4; i++) {
			random = masterTiles[Random.Range(0,4)];
			newConfiguration.Add(random);
			stringPattern.Add(random.transform.name);
		}
		tiles = newConfiguration;	
	}
	
	public List<string> getStringPattern(){
		return stringPattern;
	}
	
	public string toString(List<string> pattern){
		string retString = "";
		foreach (string item in pattern)
		{
			retString += item + ", ";
		}
		return retString;
	}
	
	public List<GameObject> getConfiguration(){
		return tiles;
	}
	
	public void copy(g2_Pattern other){
		this.tiles = copyList(other);
		setStringPattern(other.getConfiguration());
	}
	
	void setStringPattern(List<GameObject> other){
		stringPattern.Clear();
		
		foreach (var item in other )
		{
			stringPattern.Add(item.transform.name);	
		}
	}
	
	List<GameObject> copyList(g2_Pattern toCopy){
		List<GameObject> old = toCopy.getConfiguration();
		List<GameObject> config = new List<GameObject>(old.Count);
		
		foreach (var item in old)
		{
			config.Add(item);
		}
		return config;
	}
}