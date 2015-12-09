using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	int gridWidth = 8;
	int gridHeight = 5;
	float endGame = 60;
	float turnLength = 2.0f;
	float timeToAct = 0.0f;
	public GameObject cubePrefab;
	public GameObject nextCubePrefab;
	private GameObject[,] allCubes;
	public bool placedCube = false;
	public bool checkActivity = false;
	public Color nextCubeCurrentColor;
	public int randomCubeInRow;
	public int randomCubeInColumn;
	public Text scoreUI;
	public Text endGameUI;
	GameObject nextCube;
	GameObject activeCube;
	GameObject oldActiveCube;
	int rowOne = 0;
	int rowTwo = 1;
	int rowThree = 2;
	int rowFour = 3;
	int rowFive = 4;
	int samePlusPoints = 10;
	int diffPlusPoints = 5;
	int score;
	Color[] colors = {Color.red, Color.yellow, Color.green, Color.blue, Color.magenta};

	//If a player fails to press one of those numbers before the turn ends, 
	//then a random available cube (i.e. white) turns black. 
	//In that case, a new cube appears in the Next Cube area as usual.

	//If a player clicks a white cube that is adjacent to the active cube (including diagonals), 
	//the active cube moves to that location instantly (and remains active). 
	//The location that the active cube just vacated should become a white cube.
	
	public void ProcessClickedCube (GameObject clickedCube, int x, int y){
		// If the player clicks an inactive colored cube it should highlight
		if (checkActivity == false && clickedCube.GetComponent<Renderer> ().material.color != Color.white &&
			clickedCube.GetComponent<Renderer> ().material.color != Color.black) {
			checkActivity = true;
			clickedCube.GetComponent<Light> ().intensity = 8;
			activeCube = clickedCube;
			oldActiveCube = clickedCube;
		} 
		//if a player clicks a new cube it should highlight and become the moving cube and the other should unhighlight
		else if (checkActivity == true && clickedCube.GetComponent<Renderer> ().material.color != Color.white &&
			clickedCube.GetComponent<Renderer> ().material.color != Color.black && clickedCube != activeCube) {
			clickedCube.GetComponent<Light> ().intensity = 8;
			oldActiveCube.GetComponent<Light> ().intensity = 0;
			activeCube = clickedCube;

		}
		// If the player clicks an active colored cube, it should unhighlight
		else if (checkActivity == true && clickedCube.GetComponent<Light> ().intensity == 8) {
			checkActivity = false;
			clickedCube.GetComponent<Light> ().intensity = 0;
		} 
		//if a player clicks a white cube next to the activecube, it should change to that color
		else if (checkActivity == true && clickedCube.GetComponent<Renderer> ().material.color == Color.white && 
		         Mathf.Abs(clickedCube.GetComponent<CubeBehavior> ().x - activeCube.GetComponent<CubeBehavior> ().x) <= 1 &&
		         Mathf.Abs(clickedCube.GetComponent<CubeBehavior> ().y - activeCube.GetComponent<CubeBehavior> ().y) <= 1) {
			//turn new cube color of old cube
			clickedCube.GetComponent<Renderer> ().material.color = (activeCube.GetComponent<Renderer> ().material.color);
			clickedCube.GetComponent<Light> ().intensity = 8;
			//turn old cube white
			activeCube.GetComponent<Renderer> ().material.color = Color.white;
			activeCube.GetComponent<Light> ().intensity = 0;
			activeCube = clickedCube;
			oldActiveCube = clickedCube;
		}
	}



	public void KeyInput () {
		if (Input.GetKeyDown ("1")) {
			if (allCubes [0, rowOne].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [1, rowOne].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [2, rowOne].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [3, rowOne].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [4, rowOne].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [5, rowOne].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [6, rowOne].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [7, rowOne].GetComponent<Renderer> ().material.color != Color.white) {
				//ENDGAME!
				endGameUI.text = "GAME OVER";
			} 
			else {
				if (allCubes [randomCubeInRow, rowOne].GetComponent<Renderer> ().material.color != Color.white) {
					while (allCubes[randomCubeInRow,rowOne].GetComponent<Renderer> ().material.color != Color.white) {
						randomCubeInRow = Random.Range (0, 8);
					}
				}
				allCubes [randomCubeInRow, rowOne].GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
				placedCube = true;
				nextCube.GetComponent<Renderer> ().material.color = Color.grey;
			}
		}
		if (Input.GetKeyDown ("2")) {
			if (allCubes [0, rowTwo].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [1, rowTwo].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [2, rowTwo].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [3, rowTwo].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [4, rowTwo].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [5, rowTwo].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [6, rowTwo].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [7, rowTwo].GetComponent<Renderer> ().material.color != Color.white) {
				//ENDGAME!
				endGameUI.text = "GAME OVER";
			} 
			else {
				if (allCubes [randomCubeInRow, rowTwo].GetComponent<Renderer> ().material.color != Color.white) {
					while (allCubes[randomCubeInRow,rowTwo].GetComponent<Renderer> ().material.color != Color.white) {
						randomCubeInRow = Random.Range (0, 8);
					}
				}
				allCubes [randomCubeInRow, rowTwo].GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
				placedCube = true;
				nextCube.GetComponent<Renderer> ().material.color = Color.grey;
			}
		}
		if (Input.GetKeyDown ("3")) {
			if (allCubes [0, rowThree].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [1, rowThree].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [2, rowThree].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [3, rowThree].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [4, rowThree].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [5, rowThree].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [6, rowThree].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [7, rowThree].GetComponent<Renderer> ().material.color != Color.white) {
				//ENDGAME!
				endGameUI.text = "GAME OVER";
			} 
			else {
				if (allCubes [randomCubeInRow, rowThree].GetComponent<Renderer> ().material.color != Color.white) {
					while (allCubes[randomCubeInRow,rowThree].GetComponent<Renderer> ().material.color != Color.white) {
						randomCubeInRow = Random.Range (0, 8);
					}
				}
				allCubes [randomCubeInRow, rowThree].GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
				placedCube = true;
				nextCube.GetComponent<Renderer> ().material.color = Color.grey;
			}
		}
		if (Input.GetKeyDown ("4")) {
			if (allCubes [0, rowFour].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [1, rowFour].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [2, rowFour].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [3, rowFour].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [4, rowFour].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [5, rowFour].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [6, rowFour].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [7, rowFour].GetComponent<Renderer> ().material.color != Color.white) {
				//ENDGAME!
				endGameUI.text = "GAME OVER";
			} 
			else {
				if (allCubes [randomCubeInRow, rowFour].GetComponent<Renderer> ().material.color != Color.white) {
					while (allCubes[randomCubeInRow,rowFour].GetComponent<Renderer> ().material.color != Color.white) {
						randomCubeInRow = Random.Range (0, 8);
					}
				}
				allCubes [randomCubeInRow, rowFour].GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
				placedCube = true;
				nextCube.GetComponent<Renderer> ().material.color = Color.grey;
			}
		}
		if (Input.GetKeyDown ("5")) {
			if (allCubes [0, rowFive].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [1, rowFive].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [2, rowFive].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [3, rowFive].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [4, rowFive].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [5, rowFive].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [6, rowFive].GetComponent<Renderer> ().material.color != Color.white &&
				allCubes [7, rowFive].GetComponent<Renderer> ().material.color != Color.white) {
				//ENDGAME!
				endGameUI.text = "GAME OVER";
			} 
			else {
				if (allCubes [randomCubeInRow, rowFive].GetComponent<Renderer> ().material.color != Color.white) {
					while (allCubes[randomCubeInRow, rowFive].GetComponent<Renderer> ().material.color != Color.white) {
						randomCubeInRow = Random.Range (0, 8);
					}
				}
				allCubes [randomCubeInRow, rowFive].GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
				placedCube = true;
				nextCube.GetComponent<Renderer> ().material.color = Color.grey;
			}
		}

		if (!Input.anyKey) {

			 
	}
}

	void MakeRandomCubeBlack () {
		if (WhiteCubeExists () == false) {
			//ENDGAME!
			endGameUI.text = "GAME OVER";
		} else {
			if (allCubes [randomCubeInRow, randomCubeInColumn].GetComponent<Renderer> ().material.color != Color.white) {
				while (allCubes[randomCubeInRow, randomCubeInColumn].GetComponent<Renderer> ().material.color != Color.white) {
					randomCubeInRow = Random.Range (0, 8);
					randomCubeInColumn = Random.Range (0, 5);
				}
			} else {
				allCubes [randomCubeInRow, randomCubeInColumn].GetComponent<Renderer> ().material.color = Color.black;
				placedCube = true;
				nextCube.GetComponent<Renderer> ().material.color = Color.grey;
			}
		}
	}

	bool WhiteCubeExists () {
		bool whiteCubeFound = false;
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++){
				if (allCubes[x,y].GetComponent<Renderer> ().material.color == Color.white){
					whiteCubeFound = true;
				}
			}
		}
		return whiteCubeFound;

	}

	bool CheckForSamePlus(int x, int y) {
		//this stores the color of the center cube, and tells what to look for
		Color targetColor = allCubes[x,y].GetComponent<Renderer> ().material.color;

		//error check
		if (targetColor == Color.white || targetColor == Color.black) {
			return false;
		}

		if (targetColor == allCubes [x, y + 1].GetComponent<Renderer> ().material.color && 
		    targetColor == allCubes [x, y - 1].GetComponent<Renderer> ().material.color && 
		    targetColor == allCubes [x + 1, y].GetComponent<Renderer> ().material.color && 
		    targetColor == allCubes [x - 1, y].GetComponent<Renderer> ().material.color) {
			return true;
		}
		return false;
	}

	int ColorAddition(Color myColor) {
		if (myColor == Color.red) {
			return 1;
		}
		if (myColor == Color.yellow) {
			return 10;
		}
		if (myColor == Color.green) {
			return 100;
		}
		if (myColor == Color.blue) {
			return 1000;
		}
		if (myColor == Color.magenta) {
			return 10000;
		}
		return 0;
	}

	bool CheckForDifferentPlus(int x, int y) {
		//these x and y are the center cube
		int myColorTotal = 0;

		myColorTotal += ColorAddition (allCubes [x,y].GetComponent<Renderer> ().material.color);
		myColorTotal += ColorAddition (allCubes [x,y+1].GetComponent<Renderer> ().material.color);
		myColorTotal += ColorAddition (allCubes [x,y-1].GetComponent<Renderer> ().material.color);
		myColorTotal += ColorAddition (allCubes [x+1,y].GetComponent<Renderer> ().material.color);
		myColorTotal += ColorAddition (allCubes [x-1,y].GetComponent<Renderer> ().material.color);

		if (myColorTotal == 11111) {
			return true;
		}
		return false;
	}

	void MakePlusBlack(int x, int y) {
		allCubes [x, y].GetComponent<Renderer> ().material.color = Color.black;
		allCubes [x, y + 1].GetComponent<Renderer> ().material.color = Color.black;
		allCubes [x, y - 1].GetComponent<Renderer> ().material.color = Color.black;
		allCubes [x + 1, y].GetComponent<Renderer> ().material.color = Color.black;
		allCubes [x - 1, y].GetComponent<Renderer> ().material.color = Color.black;
	}

	void ScoreCheck() {
		for (int x =1; x < gridWidth - 1; x++) {
			for (int y =1; y< gridHeight - 1; y++){
				//check for 5 cubes of the SAME color based on the center cube probably 
				if (CheckForSamePlus (x,y)) {
					score += samePlusPoints;
					//turn cubes black
					MakePlusBlack(x,y);
				}
				//Check for 5 cubes of DIFFERENT colors
				if (CheckForDifferentPlus (x,y)) {
					score += diffPlusPoints;
					//turn cubes black
					MakePlusBlack(x,y);
				}
			}
		}

	}


	// Use this for initialization
	void Start () {
		endGameUI.text = "";
		endGameUI.fontSize = 125;
		score = 0;
		timeToAct = turnLength;
		nextCubeCurrentColor = colors [Random.Range (0, 5)];
	

		//nextcube first time instantiate
		nextCube = (GameObject) Instantiate(nextCubePrefab, new Vector3(-7,2), Quaternion.identity);

		//nextCube turning the nextCubeCurrentColor
		nextCube.GetComponent<Renderer> ().material.color = nextCubeCurrentColor;

		allCubes = new GameObject[gridWidth/*8*/, gridHeight/*5*/];

		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++) {
				allCubes[x,y] = (GameObject) Instantiate(cubePrefab, new Vector3(x*2 - 14, y*2 - 8), Quaternion.identity);
				allCubes[x,y].GetComponent<CubeBehavior> ().x = x;
				allCubes[x,y].GetComponent<CubeBehavior> ().y = y;
			}
		}



	}
	
	// Update is called once per frame
	void Update () {

		ScoreCheck ();
		scoreUI.text = "Score: " + score;
		scoreUI.fontSize = 50;

		if (placedCube == false) {
			KeyInput ();
		}
		if (Time.time > timeToAct) {
			if (placedCube == false){
				MakeRandomCubeBlack ();
			}
			placedCube = false;

			//make randomCubeInRow and Column a new int
			randomCubeInRow = Random.Range (0,8);
			randomCubeInColumn = Random.Range (0,5);

			//set nextCubeCurrentColor to a new random color
			nextCubeCurrentColor = colors [Random.Range (0,5)];

			//make it the nextCubeCurrentColor
			nextCube.GetComponent<Renderer> ().material.color = nextCubeCurrentColor;
			timeToAct += turnLength;
		}
		if (Time.time > endGame) {
			endGameUI.text = "GAME OVER";
		}                    
	}
}
