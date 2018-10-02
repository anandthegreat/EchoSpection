using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceandCollision : MonoBehaviour {
	Ray ray;
	RaycastHit2D hit;
	float distance = 0f;
	float opacity=0.1f;
	public SpriteRenderer sr;
	public SpriteRenderer sr2;


	// Update is called once per frame
	void FixedUpdate () {
		ray.origin = new Vector2(transform.position.x + 0.8f, transform.position.y);
		ray.direction = Vector2.right;
		hit = Physics2D.Raycast(ray.origin, ray.direction);
		//Debug.Log(hit.transform.position.x);
		if (hit.collider != null)
		{
			distance = hit.transform.position.x;
			distance = distance + 8;
			if (distance == -1)
            {
				opacity = 0.1f;
			}
            else if(distance <= 0)
            {
                opacity = 1;
            }
            else
            {
				opacity = (21 - distance) / 21;
                if (opacity < 0)
                    opacity = 0;
			}
		}
        else
        {
            opacity = 0.1f;
        }
        //Debug.Log(opacity);
        sr.color = new Color(1f, 1f, 1f, opacity);
        sr2.color = new Color(1f, 1f, 1f, opacity);
    }
}