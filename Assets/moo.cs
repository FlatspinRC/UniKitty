using UnityEngine;
using System.Collections;

public class moo : MonoBehaviour {

	public Rigidbody phys;
	public int jumpSpeed = 30;
	public int moveSpeed = 90;
	public int spinSpeed = 900;
	// Use this for initialization
	void Start () {
		phys = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		jump ();
		lookRight ();
		lookLeft ();
		forward ();
		backward ();
	}

	public void jump(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			phys.velocity = new Vector3 (phys.velocity.x, jumpSpeed, phys.velocity.z);
		}
	}

	public void lookRight(){
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (Vector3.up * Time.deltaTime * moveSpeed);
		}
	}

	public void lookLeft(){
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (Vector3.down * Time.deltaTime * moveSpeed);
		}
	}

	public void forward(){
		if (Input.GetKey (KeyCode.UpArrow)) {
			phys.velocity = new Vector3(phys.velocity.x, phys.velocity.y, moveSpeed);
		}
	}

	public void backward(){
		if (Input.GetKey (KeyCode.DownArrow)) {
			phys.velocity = new Vector3(phys.velocity.x, phys.velocity.y ,moveSpeed * -1);
		}
	}

}