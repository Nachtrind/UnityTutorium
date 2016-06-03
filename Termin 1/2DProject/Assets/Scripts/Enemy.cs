using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	Rigidbody rig;

	public float enemymovement;

	// Use this for initialization
	void Start () {
	
		rig = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Grounded() == true) {
			rig.velocity = new Vector3 (enemymovement * Time.deltaTime, rig.velocity.y, 0);
		} else {
			enemymovement = enemymovement * -1;
			rig.velocity = new Vector3 (enemymovement * Time.deltaTime, rig.velocity.y, 0);
		}
	}
	void OnTriggerEnter (Collider c ){

		if (c.gameObject.CompareTag ("Player")) {
			Destroy (c.gameObject);
	
		}
	}
	bool Grounded(){
		return Physics.Raycast (transform.position, Vector3.down, 0.7f);
	}
}
