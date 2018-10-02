using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour {

	public GameObject obstacle;
	public float delayTimer=3f;
	float timer;
    GameObject objectPrefab;

	// Use this for initialization
	void Start () {
		timer = delayTimer;
        obstacle.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Vector3 obstaclePos = new Vector3 (transform.position.x, Random.Range (-1.5f, 1.5f), transform.position.z);
            
			objectPrefab = Instantiate (obstacle, obstaclePos, transform.rotation);
            objectPrefab.transform.localScale = new Vector3(objectPrefab.transform.localScale.x, Random.Range( 0.08f, 0.22f ) ,0);

			timer = delayTimer;
            Destroy(objectPrefab, 5f);
		}
	}
}
