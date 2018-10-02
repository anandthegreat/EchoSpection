using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
	public float playerSpeed;
	public Vector2 pos;
	public Rigidbody2D player;

	// Use this for initialization
	void Start () {
		pos = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (player.position.y > 0) {
			pos.y += playerSpeed * Time.deltaTime/30;
		}
		else if(player.position.y==0){

		}
		else{
			pos.y -= playerSpeed * Time.deltaTime/30;
		}


		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Rotate(Vector3.back*Time.deltaTime*25f);
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Rotate(Vector3.forward*Time.deltaTime*25f);
		}
		pos.y += Input.GetAxis ("Vertical") * playerSpeed * Time.deltaTime;
		if(pos.y>-4 && pos.y<4){
			transform.position = pos;
		}
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "New tag" || c.gameObject.tag=="obstag") {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			//Destroy (gameObject);

		}
	}
}
