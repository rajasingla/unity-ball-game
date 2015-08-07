using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public float speed;
	// Use this for initialization
	private Rigidbody rb;
	public Text countText;
	public Text win;
	private int count;
	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCount();
		win.text = "";

	}
	
	// Update is called once per frame


	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}  
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick up"))
		{
			other.gameObject.SetActive(false);
			count++;
			SetCount();
		}

	}
	void SetCount()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 16)
			win.text = "YOYO!";
	}
}
