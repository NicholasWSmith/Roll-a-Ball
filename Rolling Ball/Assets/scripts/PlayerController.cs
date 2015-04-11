using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

	public float speed;
	private int count = 0;
	public GUIText countText;
	public GUIText winText;

	void start() {
		setCountText ();
		winText.text = "";
	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		
		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Pickup") {
			count++;
			other.gameObject.SetActive (false);
			setCountText();
		}
	}

	void setCountText() {

		countText.text = "Count: " + count.ToString();
		if (count >= 8) {
			winText.text = "You win! Gratz!";
		}
	}

}
