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
	int cubeClassStartX = 0;
	int cubeClassStartY = 8;
	public CubeClass cubeClass;
	Color[] colors = {Color.red, Color.yellow, Color.green, Color.blue, Color.magenta};

	public void ProcessClickedCube (GameObject clickedCube, int x, int y){
		// If the player clicks an inactive colored cube it should highlight
		if (checkActivity == false /*&& clickedCube == coloredCube*/) {
			checkActivity = true;
			clickedCube.GetComponent<Renderer> ().material.color = colors [0];
		}
		// If the player clicks an active colored cube, it should unhighlight
		else if (checkActivity == true /*&& clickedCube == coloredCube*/) {
		checkActivity = false;
		clickedCube.GetComponent<Renderer> ().material.color = Color.white;
		}
	}

	public void KeyInput () {
		if (Input.GetKeyDown(KeyCode.Keypad1)) {
			//put nextcube in that row
				Destroy(gameObject);
		}
		else if (Input.GetKeyDown(KeyCode.Keypad2)) {
			//put nextcube in that row
		}
		else if (Input.GetKeyDown(KeyCode.Keypad3)) {
			//put nextcube in that row
		}
		else if (Input.GetKeyDown(KeyCode.Keypad4)) {
			//put nextcube in that row
		}
		else if (Input.GetKeyDown(KeyCode.Keypad5)) {
			//put nextcube in that row
		}
	}
	/*public void MoveCubeClass() {
		cubeClass.active = true; 
		allCubes [cubeClass.x, cubeClass.y].GetComponent<Renderer>().material.color = Color.white;
		cubeClass.Move ();
		allCubes [cubeClass.x, cubeClass.y].GetComponent<Renderer>().material.color = Color.yellow;
	}

	void MoveCube() {
		int nextX = cubeClass.x;
		int nextY = cubeClass.y;
		if (cubeClass.targetX > cubeClass.x) {
			nextX++;
		}
		else if (cubeClass.targetX < cubeClass.x) {
			nextX--;
		}
		if (cubeClass.targetY > cubeClass.y) {
			nextY++;
		}
		else if (cubeClass.targetY < cubeClass.y) {
			nextY--;
		}
		// Set the old cube to black if it's the depot
		if (checkActivity) {
			allCubes[cubeClass.x, cubeClass.y].GetComponent<Renderer>().material.color = Color.red;
		}
		// otherwise, set the old cube to white
		else {
			allCubes[cubeClass.x, cubeClass.y].GetComponent<Renderer>().material.color = Color.white;
		}
		// Set the new cube to yellow if the airplane is still active
		if (cubeClass.active) {
			allCubes[nextX, nextY].GetComponent<Renderer>().material.color = Color.yellow;
		}
		// otherwise the airplane is deactive and red
		else {
			allCubes[nextX, nextY].GetComponent<Renderer>().material.color = Color.red;
		}
		// Update the airplane to be in the new location
		cubeClass.x = nextX;
		cubeClass.y = nextY;
		
	}*/


	// Use this for initialization
	void Start () {

		timeToAct = turnLength;

		GameObject nextCube = (GameObject) Instantiate(nextCubePrefab, new Vector3(-7,2,0), Quaternion.identity);
		allCubes = new GameObject[gridWidth, gridHeight];
		cubeClass = new CubeClass();
		cubeClass.targetX = cubeClassStartX;
		cubeClass.targetY = cubeClassStartY;

		//NextCubeColor
		nextCube.GetComponent<Renderer> ().material.color = colors [Random.Range (0, 5)];
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {
				allCubes[x,y] = (GameObject) Instantiate(cubePrefab, new Vector3(x*2 - 14, y*2 - 8,0), Quaternion.identity);
			}
		}

		//cubeClass.x = cubeClassStartX;
		//cubeClass.y = cubeClassStartY;

	}
	
	// Update is called once per frame
	void Update () {
	//	MoveCube();
	//	MoveCubeClass ();
		if (Time.time > timeToAct) {
			//nextCube.GetComponent<Renderer> ().material.color = colors [Random.Range (0, 5)];
			//KeyInput ();
			print ("yay");
			timeToAct += turnLength;
		}
	}
}
