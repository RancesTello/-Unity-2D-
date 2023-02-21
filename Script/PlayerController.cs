using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject BulletPrefab;
	private SpriteRenderer MySprite;

	bool canjump;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));
			gameObject.GetComponent<Animator> ().SetBool ("moving", true);
			gameObject.GetComponent<SpriteRenderer> ().flipX = true;

		}
		if(Input.GetKey(KeyCode.D)){
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime, 0));
			gameObject.GetComponent<Animator> ().SetBool ("moving", true);
			gameObject.GetComponent<SpriteRenderer> ().flipX = false;

		}
		if (!Input.GetKey ("left") && !Input.GetKey ("right")) {
			gameObject.GetComponent<Animator> ().SetBool ("moving",false);
		}
		if(Input.GetKeyDown("up") && canjump){
			canjump = false;
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 300));
		}
		if (Input.GetKey (KeyCode.F)) {
			shoot ();
		}

	}

private void OnCollisionEnter2D(Collision2D collision){
		if (collision.transform.tag == "ground") {
			canjump = true;
		}
	} 

	private void shoot(){
		Vector3 direction;
		if (MySprite.flipX == true)
			direction = Vector2.left;
		else direction = Vector2.right;

		GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
		bullet.GetComponent<BulletScript> ().SetDirection (direction);   
	}
}
	
