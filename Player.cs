using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float force;
    public GameObject restartButton;
    int spritecolor = 0;
    public Sprite gBird, rBird;


    void Start()
    {
        Time.timeScale = 0;
        rigidBody = GetComponent<Rigidbody2D>();
        
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            rigidBody.velocity = Vector2.up * force;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Red" & spritecolor == 0)
        {
            int rand = UnityEngine.Random.Range(0, 10);
            if ((rand % 2) == 0)
            {
                spritecolor = 0;
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = rBird;
            }
            else
            {
                spritecolor = 1;
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = gBird;
            }
        }
        else if (other.tag == "Green" & spritecolor == 1)
        {
            int rand = UnityEngine.Random.Range(0, 10);
            if ((rand % 2) == 0)
            {
                spritecolor = 1;
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = gBird;
            }
            else
            {
                spritecolor = 0;
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = rBird;
            }
        }
        else
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            restartButton.SetActive(true);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
            Destroy(gameObject);
            Time.timeScale = 0;
            restartButton.SetActive(true);
    }


}