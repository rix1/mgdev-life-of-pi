using UnityEngine;
using System.Collections;

public class g_HardCodedNotes : MonoBehaviour {

	public GameObject green;
	public GameObject red;
	public GameObject yellow;
	public GameObject wrong;
	
	public int wrongTreshhold = 0;
	
	public bool wrongNotes = false;
	
	private float[] splits = {
1.4f,2.184f,2.174f,2.169f,2.215f,1.056f,.377f,1.783f,.448f,.440f,1.248f,.408f,1.816f,.482f,.710f,1.016f,.382f,1.690f,.472f,.472f,1.400f,.385f,1.671f,.518f,.400f,.271f,1.016f,.452f,.724f,.432f,.272f,.312f,.423f,.360f,.328f,.792f,.305f,1.055f,.441f,.295f,.344f,.400f,.713f,.704f,.328f,.391f,.407f,1.008f,.304f,.351f,.384f,.313f,.760f,.199f,.516f,.413f,.264f,.422f,.337f,.239f,.399f,.315f,.334f
	};
	
	private float delta = 0;
	private float total = 0;
	private int pointer = 0;
	

	private Vector3 spawnLoc1 = new Vector3(-1.8f ,4f,0f); 
	private Vector3 spawnLoc2 = new Vector3(0f,4f,0f); 
	private Vector3 spawnLoc3 = new Vector3(1.8f,4f,0f); 

	private Quaternion rotation = Quaternion.Euler(0,0,0);
	
	// Use this for initialization
	void Start () {
	}
	
	
	void Update(){
		total += Time.deltaTime;
		if(pointer <= (splits.Length - 1) && delta >= splits[pointer]){
// 			Debug.Log("delta is " + delta+  "/" + total + " waited for " + splits[pointer] + ", no: " + pointer);
			delta = 0;
			pointer ++;
			instantiateRand();
		}else{
			delta += Time.deltaTime;
		}
	}
	
	void instantiateRand(){
		int random = Random.Range(1,4);
// 		Debug.Log("Random: " + random);

		if(wrongNotes){
			int tull = Random.Range(0,100);
			if(tull < wrongTreshhold){
				drawWrong(random);
			}else{
				drawNote(random);
			}
		}else{
			drawNote(random);
		}	
	}
	
	void drawWrong(int i){
		switch (i)
		{
			case 1:
				Instantiate(wrong, spawnLoc1, rotation);
				break;
			case 2:
				Instantiate(wrong, spawnLoc2, rotation);
				break;
			case 3:
				Instantiate(wrong, spawnLoc3, rotation);
				break;
			default:
				break;
		}
	}
	
	void drawNote(int i){
		switch (i)
		{
			case 1:
				Instantiate(green, spawnLoc1, rotation);
				break;
			case 2:
				Instantiate(yellow, spawnLoc2, rotation);
				break;
			case 3:
				Instantiate(red, spawnLoc3, rotation);
				break;
			default:
				break;
		}
	}
}