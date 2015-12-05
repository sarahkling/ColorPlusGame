using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	int gridWidth = 8;
	int gridHeight = 5;
	float turnLength = 3.0f;
	float timeToAct = 0.0f;
	public GameObject cubePrefab;
	public GameObject nextCubePrefab;
	private GameObject[,] allCubes;
	public bool coloredCube = false;
	public bool checkActivity = false;
	public Color nextCubeCurrentColor;
	public int randomCubeInRow;
	public int rowOne = 0;
	public int rowTwo = 1;
	public int rowThree = 2;
	public int rowFour = 3;
	public int rowFive = 4;
	//public static bool Highlight;
	Color[] colors = {Color.red, Color.yellow, Color.green, Color.blue, Color.magenta};

	
	public void ProcessClickedCube (GameObject clickedCube, int x, int y){
		// If the player clicks an inactive colored cube it should highlight
		if (checkActivity == false /*&& clickedCube == coloredCube*/) {
			checkActivity = true;
			clickedCube.GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
		}
		// If the player clicks an active colored cube, it should unhighlight
		else if (checkActivity == true /*&& clickedCube == coloredCube*/) {
		checkActivity = false;
		clickedCube.GetComponent<Renderer> ().material.color = Color.white;
		}
	}

	public void KeyInput () {
		if (Input.GetKeyDown("1")) {
			allCubes[randomCubeInRow,rowOne].GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
		}
		if (Input.GetKeyDown("2")) {
			allCubes[randomCubeInRow,rowTwo].GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
		}
		if (Input.GetKeyDown("3")) {
			allCubes[randomCubeInRow,rowThree].GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
		}
		if (Input.GetKeyDown("4")) {
			allCubes[randomCubeInRow,rowFour].GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
		}
		if (Input.GetKeyDown("5")) {
			allCubes[randomCubeInRow,rowFive].GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
		}
	}
	

	// Use this for initialization
	void Start () {
		timeToAct = turnLength;
		nextCubeCurrentColor = colors [Random.Range (0, 5)];
		//nextcube first time instantiate
		GameObject nextCube = (GameObject) Instantiate(nextCubePrefab, new Vector3(-7,2,0), Quaternion.identity);
		//nextCube turning the nextCubeCurrentColor
		nextCube.GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
		allCubes = new GameObject[gridWidth /*8*/, gridHeight /*5*/];

		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {
				allCubes[x,y] = (GameObject) Instantiate(cubePrefab, new Vector3(x*2 - 14, y*2 - 8,0), Quaternion.identity);
			}
		}



	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > timeToAct) {
			randomCubeInRow = Random.Range (0,8);
			KeyInput ();
			//set nextCubeCurrentColor to a new random color
			nextCubeCurrentColor = colors [Random.Range (0,5)];
			//instantiate the new nextCube  again
			GameObject nextCube = (GameObject) Instantiate(nextCubePrefab, new Vector3(-7,2,0), Quaternion.identity);
			//make it the nextCubeCurrentColor
			nextCube.GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
			timeToAct += turnLength;
		}
	}
}
