using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMonster : Monster
{
    public Vector2 speed = Vector2.zero;

    private SpriteRenderer spriteRenderer;

    public float hitRange = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        //orientation de l'image

        Vector2 start;
        Vector2 direction;

        if (speed.x < 0) {
            spriteRenderer.flipX = true;
            start = (Vector2)transform.position + Vector2.left * 0.51f;
            direction = Vector2.left;
        }
        else { 
            spriteRenderer.flipX = false;
            start = (Vector2)transform.position + Vector2.right * 0.51f;
            direction = Vector2.right;
        }

        Debug.DrawRay(start, direction * hitRange, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(start, direction, hitRange);

        if(hit.collider != null) {
            speed.x *= -1;
        }
 
        //deplacement
        Vector2 deplacement = speed * Time.deltaTime;
        transform.position += (Vector3)deplacement;
       
    }
}
