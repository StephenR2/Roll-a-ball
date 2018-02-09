/* Stephen Randall
 * 02/08/18
 * This script is responsible for all things pertaining to your player, what to do when it hits a pickup, updating text, etc.
 */

using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed; // Creates component speed
	public Text countText; // Creates text component that will count the # of pickups
	public Text winText; // Creates text component that will display you win after objective has been reached.0
	public Text bossText; // Creates text component that will count the # of boss pickups
	// Modifiers:
	private Rigidbody rb;
	private int count;
	private int bosscount;

	void Start ()
	{
		rb = GetComponent<Rigidbody> (); // Assigns RigidBody to rb
		count = 0; // Assigns 0 to the count variable
		bosscount = 0; // Assigns 0 to the bosscount variable
		SetCountText (); // Calls function that will set the actual text of countText
		SetBossCountText (); // Calls function that will set the actual text of bossText
		winText.text = ""; // Sets what the win text will be
	}
	void FixedUpdate ()
	{
		// All this handles is forces applied on player when using the arrow keys.
		float moveHorizontal = Input.GetAxis ("Horizontal"); 
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other) 
	{
		// If statement stating what should happen when the ball collides with the Pickups
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		} 
		// If statement stating what should happen when the ball collides with Bosses.
		else if (other.gameObject.CompareTag ("Boss")) 
		{
			other.gameObject.SetActive (false);
			bosscount = bosscount + 2;
			SetBossCountText ();

		}

	}
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString (); // Sets the text of the countText component

	}
	void SetBossCountText ()
	{
		bossText.text = "Boss Score: " + bosscount.ToString (); // Sets the text of the bosstext component
		if (bosscount >= 8) // If statement to determine when a player has won, if they have all bosses update winText to "You Win" andthat will display.
		{
			winText.text = "You win!";
		}

	}



}
