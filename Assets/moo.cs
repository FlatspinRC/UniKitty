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
		Right ();
		Left ();
		bool movedForward = forward ();
		bool movedBackward = backward ();
		if (movedForward || movedBackward) {
			//phys.drag = 0;
			movedLastTurn = true;
		} else if(movedLastTurn) {
			//StartCoroutine (brake());
		}
	}

	public void jump(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			phys.AddForce (Vector3.up * jumpSpeed, ForceMode.Impulse);
		}
	}

	public void Right(){
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
		}
	}

	public void Left(){
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Vector3.left * Time.deltaTime * moveSpeed);
		}
	}

	public bool forward(){
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
			return true;
		}
		return false;
	}

	public bool backward(){
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * -1);
			return true;
		}
		return false;
	}


	public IEnumerator brake() {
		phys.drag = 100;
		yield return new WaitForSeconds (0.2f);
		phys.drag = 0;
	}
}


