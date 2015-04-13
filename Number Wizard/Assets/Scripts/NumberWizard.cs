using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;
	
	// Use this for initialization
	void Start () {
		max = 1000;
		min = 1;
		guess = 500;
		
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.UpArrow)){
			//print ("Up arrow was pressed");
			min = guess;
			BinarySearch();
		}else if (Input.GetKeyDown (KeyCode.DownArrow)){
			//print ("Down arrow was pressed");
			max = guess;
			BinarySearch();
		}else if (Input.GetKeyDown (KeyCode.Return)){
			print ("I Won!");
			Start();
		}
	
	}
	
	void StartGame () {
		
		print ("----------------------------------------------------");
		print("Welcome to number wizard");
		print("Pick a number in your head, but dont tell me!");
		
		print("The highest number you can pick in " + max);
		print("The lowest number you can pick in " + min);
		
		print("Is the number higher or lower than" + guess+" ?");
		print("Up = higher, Down = lower, return = equal");
		max += 1;
	}
	
	void BinarySearch () {
		guess = (max + min) / 2;
		print("Is the number higher or lower than" + guess+" ?");
		print("Up = higher, Down = lower, return = equal");
	}
}

