using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeCircleSprite : MonoBehaviour
{
    /*
     * max_coverage=30
     * delay=0.03
     * width=height=0.1
     * 
     */
    public Sprite Circle;
    Vector2 player2pos;
    public int max_coverage = 30;
    float timer = 0.4f;
    int flag = 0;
    public float delay = 0.03f;
    public float width = 0.1f;
    public float height = 0.1f;
    public Vector3 position;
    public float op = .4f;

    void Awake()
    {
        // set the scaling

    }

    private Vector3 v2tov3conv(Vector2 inv)
    {
        Vector3 t = new Vector3(inv.x, inv.y, 0);
        return t;
    }
    private void Start()
    {
        this.gameObject.GetComponent<SpriteMask>().sprite = Circle;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Circle;
        player2pos=this.gameObject.GetComponentInParent<PlayerMovement>().pos;
        position = v2tov3conv( player2pos);
       // position.x = position.x - 10;
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            flag = 1;
            width = 0.1f;
            height = 0.1f;
            transform.localScale = new Vector3(width, height, 1f);
            
            //transform.rotation = new Quaternion(0,0,0,0);
            position = v2tov3conv(this.gameObject.GetComponentInParent<PlayerMovement>().pos);
            position.x = position.x + 1f;
            transform.position = position;
            op = .4f; 
        }
        timer -= Time.deltaTime;
        if (timer <= 0 && flag==1)
        {

            print("in the timer");


            timer = delay;
            if (width < max_coverage/3)
            {
               // if(width<2.8)
                width = width + 0.2F;
               // if(height<2.8)
                height = height + 0.2f;
                Vector3 scale = new Vector3(width, height, 1f);
                transform.localScale = scale;
                position.x = position.x + 0.7f;
                // set the position
                transform.position = position;
                op = op - 0.011f;
                this.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, op);

            }
            //else if(width>=max_coverage/5 && width <= max_coverage)
            //{
            //    position.x = position.x + 0.3f;
            //    // set the position
            //    transform.position = position;
            //}
            else
            {
                width = 0.1f;
                height = 0.1f;
                flag = 0;
                transform.localScale = new Vector3(width, height, 1f);
                position = v2tov3conv(this.gameObject.GetComponentInParent<PlayerMovement>().pos);
                position.x = position.x + 0.2f; 
                transform.position = position;
            }
        }
    }
}
