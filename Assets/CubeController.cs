/*
 * Author(s): Isaiah Mann
 * Description: Simple demonstration of how to use arrays in C# & Unity to move a line of cubes
 */

using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {
	// Set the number of cubes public so it can adjusted in the inspector
	public int numberOfCubes = 10;

	// The minimum and maximum positions can also be adjusted in the inspector
	public int mininmumYPosition = -5;
	public int maximumYPosition = 5;

	// The move speed can be adjusted in the inspector
	public float moveSpeed = 0.25f;

	// Declare the array of GameObjects in the class so that both the Start and Update functions can modify it
	GameObject[] cubes;

	// Use a single variable to store the current yPosition of the cubes (because it's uniform)
	float yPosition;

	// This variable remembers which direction the cubes are moving in
	float deltaY;

	// Use this for initialization
	void Start () {
		// Set yPosition to origin
		yPosition = 0;

		// Initialize the direction so that the cubes move up
		deltaY = moveSpeed;

		// Create the cube array to the size of our public variable
		cubes = new GameObject[numberOfCubes];

		// Loop through each spot in the array
		for (int i = 0; i < cubes.Length; i++) {
			// Create a new cube and assign it to the i-th position in the array
			cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);

			// Calculate the position based of the cube's index (the - cubes.Length/2 + 1 is used to center the cubes)
			int xPosition = i - cubes.Length/2 + 1;

			// Set the cubes to the designed x and y position (y is always the same, x is based on their index)
			cubes[i].transform.position = new Vector3(xPosition, yPosition, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Check if the cubes's yPosition is higher than the max
		if (yPosition > maximumYPosition) {
			// If so, set it so the cubes move down
			deltaY = -moveSpeed;
		} 
			
		// Check if the cubes yPosition is lower than the minimum
		else if (yPosition < mininmumYPosition) {
			// If so, set it so the cubes move up
			deltaY = moveSpeed;
		}

		// Change the yPosition variable by the calculated value
		yPosition += deltaY;

		// Loop through each cube in the array
		for (int i = 0; i < cubes.Length; i++) {
			// Calculate their x position just like we did in Start
			int xPosition = i - cubes.Length/2 + 1;

			// Set the cubes to the calculated x and y positions
			cubes[i].transform.position = new Vector3(xPosition, yPosition, 0);
		}
	}
}
