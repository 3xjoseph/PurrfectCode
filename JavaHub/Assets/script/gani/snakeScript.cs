    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeScript : MonoBehaviour
{
    private Animator animator;
    public float distance = 5f; // The distance to move
    public float speed; // The speed at which the object moves
    private bool isMoving = false;
    float moving;
    private Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            moving = speed * Time.deltaTime;
            transform.Translate(new Vector3(-moving, 0f, 0f));

            if (transform.position.x >= 51.5)
            {
                isMoving = true;
                animator.SetBool("walk", true);
              
            }
            else
            {
                isMoving = false;
                StartCoroutine(AnimationLast());

            }
                
        }
    }

    public void Move()
    {
        isMoving = true;
        distance = 5f; // Set the desired distance to move
        animator.SetBool("walk", true);
    }

    public void Attack()
    {
        
        animator.SetBool("attack", true);
    }

    public void gotHit(bool hit)
    {
        animator.SetBool("gotHit", hit);
    }

    IEnumerator AnimationLast()
    {
        Attack();
        yield return new WaitForSeconds(5.6f);
        animator.SetBool("attack", false);
        transform.position = originalPosition;
        
    }

    public void Death()
    {
        animator.SetBool("died", true);
    }

  
}
