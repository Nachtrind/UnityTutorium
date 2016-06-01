using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

	Rigidbody rig;
	float move;
	public float speed;
	public float jump;

	// Use this for initialization
	void Start ()
	{
	
		rig = GetComponent<Rigidbody> ();

 
	}
	
	// Update is called once per frame
	void Update ()
	{

		move = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		rig.velocity = new Vector3 (move, rig.velocity.y, 0);

		if (Input.GetKeyDown ("space")) {
			if (Grounded () == true) {
				rig.AddForce (new Vector3 (0, jump, 0));
			}
		}
	}

	bool IsGrounded ()
	{

		Vector3 pos = transform.position;
		Vector3 end = pos + new Vector3 (0, -1.0f, 0);

		if (Physics.Raycast (pos, new Vector3 (0, -1.0f, 0), 0.3f)) {
			return true;
		} else {
			return false;
		}
	}

	bool Grounded(){
		return Physics.Raycast(transform.position, Vector3.down, 0.7f);
	}
}
