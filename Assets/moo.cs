using UnityEngine;
using System.Collections;

public class moo : MonoBehaviour {

	public Rigidbody phys;
	public int jumpSpeed = 30;
	public int moveSpeed = 90;
	public int spinSpeed = 900;

	bool movedLastTurn = false;
	public Camera camera;
	public Vector3 lastMovementVector = Vector3.zero;
	// Use this for initialization
	void Start () {
		phys = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		jump ();

		lookRight ();
		lookLeft ();

	
		bool movedForward = forward ();
		bool movedBackward = backward ();
		if (movedForward || movedBackward) {
			//phys.drag = 0;
			movedLastTurn = true;
		} else if(movedLastTurn) {
			StartCoroutine (brake());
		}
	}

	public void jump(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			phys.AddForce (Vector3.up * jumpSpeed, ForceMode.Impulse);
		}
	}

	public void lookRight(){
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (Vector3.up * Time.deltaTime * spinSpeed);
		}
	}

	public void lookLeft(){
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (Vector3.down * Time.deltaTime * spinSpeed);
		}
	}

	public bool forward(){
		if (Input.GetKey (KeyCode.UpArrow)) {
			Vector3 lookDirection = camera.transform.forward;
			Vector3 moveVector = lookDirection * moveSpeed;
			setNewVelocity (moveVector);
			return true;
		}
		return false;
	}

	public bool backward(){
		if (Input.GetKey (KeyCode.DownArrow)) {
			Vector3 lookDirection = camera.transform.forward;
			Vector3 moveVector = lookDirection * moveSpeed * -1;
			setNewVelocity (moveVector);
		}
		return false;
	}

	public void setNewVelocity(Vector3 newVelocity) {
		float jumpin = phys.velocity.z;
		phys.AddForce (newVelocity  * phys.mass, ForceMode.Force);
	}

	public IEnumerator brake() {
		phys.drag = 100;
		yield return new WaitForSeconds (0.2f);
		phys.drag = 0;
	}
}


