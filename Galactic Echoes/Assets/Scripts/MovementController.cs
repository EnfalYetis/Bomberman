using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rigidBodyy { get; private set; }
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public KeyCode InputUp=KeyCode.W;
    public KeyCode InputDown=KeyCode.S;
    public KeyCode InputLeft=KeyCode.A;
    public KeyCode InputRight=KeyCode.D;

    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    public void Awake()
    {
        rigidBodyy=GetComponent<Rigidbody2D>();
        activeSpriteRenderer=spriteRendererDown;
    }
    public void Update()
    {
        if (Input.GetKey(InputUp))
        {
            setDirection(Vector2.up,spriteRendererUp);
        }
        else if (Input.GetKey(InputDown))
        {
            setDirection(Vector2.down,spriteRendererDown);
        }
        else if (Input.GetKey(InputLeft))
        {
            setDirection(Vector2.left,spriteRendererLeft);
        }
        else if (Input.GetKey(InputRight))
        {
            setDirection(Vector2.right,spriteRendererRight);
        }
        else
        {
            setDirection(Vector2.zero,activeSpriteRenderer);
        }
    }
    private void FixedUpdate()
    {
        Vector2 position = rigidBodyy.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidBodyy.MovePosition(position + translation);
    }
    private void setDirection(Vector2 newDirection,AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererUp.enabled= spriteRenderer==spriteRendererUp;
        spriteRendererDown.enabled= spriteRenderer==spriteRendererDown;
        spriteRendererLeft.enabled= spriteRenderer==spriteRendererLeft;
        spriteRendererRight.enabled= spriteRenderer==spriteRendererRight;
        
        activeSpriteRenderer=spriteRenderer;
        activeSpriteRenderer.idle= direction==Vector2.zero;
    }
   
    
}
