using UnityEngine;
using System.Collections;

public class g_HardCodedNotes : MonoBehaviour {

	public GameObject green;
	public GameObject red;
	public GameObject yellow;
	public GameObject wrong;
	
	public int wrongTreshhold = 0;
	
	public bool wrongNotes = false;
	
	public AudioClip song1;
	public AudioClip song2;
	public AudioClip song3;
	
	private float[] splits; 
	
	private float[] songSplit1 = {
1.4f,2.184f,2.174f,2.169f,2.215f,1.056f,.377f,1.783f,.448f,.440f,1.248f,.408f,1.816f,.482f,.710f,1.016f,.382f,1.690f,.472f,.472f,1.400f,.385f,1.671f,.518f,.400f,.271f,1.016f,.452f,.724f,.432f,.272f,.312f,.423f,.360f,.328f,.792f,.305f,1.055f,.441f,.295f,.344f,.400f,.713f,.704f,.328f,.391f,.407f,1.008f,.304f,.351f,.384f,.313f,.760f,.199f,.516f,.413f,.264f,.422f,.337f,.239f,.399f,.315f,.334f
	};
	private float[] songSplit2 = {
1.4f,2.184f,2.174f,2.169f,2.215f,1.056f,.377f,1.783f,.448f,.440f,1.248f,.408f,1.816f,.482f,.710f,1.016f,.382f,1.690f,.472f,.472f,1.400f,.385f,1.671f,.518f,.400f,.271f,1.016f,.452f,.724f,.432f,.272f,.312f,.423f,.360f,.328f,.792f,.305f,1.055f,.441f,.295f,.344f,.400f,.713f,.704f,.328f,.391f,.407f,1.008f,.304f,.351f,.384f,.313f,.760f,.199f,.516f,.413f,.264f,.422f,.337f,.239f,.399f,.315f,.334f
	};
	private float[] songSplit3 = {
.163f,.364f,.490f,.132f,.380f,.184f,.321f,.175f,.312f,.467f,.205f,.336f,.177f,.303f,.168f,.280f,.472f,.145f,.319f,.171f,.294f,.167f,.272f,.463f,.212f,.140f,.128f,.176f,.408f,.200f,.288f,.480f,.176f,.288f,.520f,.128f,.277f,.451f,.176f,.369f,.183f,.313f,.176f,.288f,.479f,.128f,.337f,.495f,.152f,.296f,.452f,.123f,.271f,.185f,.400f,.159f,.337f,.455f,.156f,.340f,.159f,.400f,.233f,.254f,.415f,.144f,.346f,.134f,.423f,.185f,.256f,.399f,.512f,.152f,.312f,.184f,.295f,.474f,.141f,.216f,.145f,.128f,.367f,.178f,.312f,.486f,.136f,.338f,.166f,.328f,.172f,.292f,.440f,.137f,.351f,.199f,.352f,.168f,.320f,.448f,.168f,.352f,.168f,.64f,.256f,.162f,.320f,.182f,.288f,.120f,.312f,.162f,.358f,.130f,.383f,.455f,.160f,.292f,.197f,.311f,.188f,.284f,.447f,.152f,.416f,.160f,.300f,.164f,.296f,.449f,.200f,.318f,.456f,.152f,.324f,.452f,.160f,.176f,.152f,.264f,.336f,.352f,.448f,.136f,.364f,.197f,.340f,.155f,.352f,.440f,.176f,.336f,.169f,.351f,.183f,.346f,.406f,.145f,.343f,.152f,.312f,.184f,.352f,.504f,.184f,.296f,.11f,.117f,.311f,.184f,.268f,.157f,.328f,.211f,.325f,.184f,.328f,.143f,.324f,.4f,.433f,.163f,.308f,.184f,.288f,.176f,.319f,.385f,.160f,.321f,.184f,.306f,.149f,.300f,.501f,.186f,.293f,.199f,.287f,.160f,.280f,.136f,.432f,.162f,.270f,.144f,.358f,.177f,.287f,.416f,.160f,.351f,.152f,.318f,.154f,.320f,.415f,.168f,.288f,.192f,.304f,.139f,.309f,.152f,.296f,.184f,.303f,.168f,.328f,.176f,.304f,.393f,.143f,.353f,.207f,.303f,.165f,.331f,.400f,.200f,.336f,.176f,.272f,.160f,.304f,.432f,.128f,.408f,.168f,.360f,.184f,.344f,.200f,.280f,.152f,.288f,.168f,.322f,.205f,.281f,.453f,.139f,.336f,.168f,.296f,.208f,.304f,.432f,.152f,.296f,.168f,.368f,.171f,.277f,.472f,.168f,.280f,.136f,.416f,.168f,.272f,.376f,.176f,.320f,.448f,.177f,.351f,.440f,.168f,.304f,.496f,.151f,.348f,.452f,.136f,.336f,.424f,.160f
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
		setLevel();
	}
	
	void setLevel(){
		int lvl = _gameState.currentLevel;
			
		switch (lvl)
		{
			case 1:
			splits = songSplit1;
			setAudio(song1); 
			break;
			case 2:
			splits = songSplit2;
			setAudio(song2); 
			break;
			case 3:
			splits = songSplit3;
			setAudio(song3); 
			break;
			default: break;
		}   
	}
	
	void setAudio(AudioClip aud){
		AudioSource audioSource = gameObject.GetComponent<AudioSource>();
	    audioSource.clip = aud; 
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
				drawWrong(random	);
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