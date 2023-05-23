using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catScript : MonoBehaviour
{

    private Animator animator;
    public float distance = 5f; // The distance to move
    public float speed; // The speed at which the object moves
    private bool isMoving = false;
    float moving;
    private Vector3 originalPosition;

    public GameObject snakeObj;
    private snakeScript snake;
    // Start is called before the first frame update
    void Start()
    {
        snake = snakeObj.GetComponent<snakeScript>();
        animator = GetComponent<Animator>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            moving = speed * Time.deltaTime;
            transform.Translate(new Vector3(moving, 0f, 0f));

            if (transform.position.x <= 94.4)
            {
                isMoving = true;
                animator.SetBool("walking", true);

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
        animator.SetBool("walking", true);
    }

    public void Attack()
    {
        
        animator.SetBool("growling", true);
        snake.gotHit(true);
    }

    IEnumerator AnimationLast()
    {
        Attack();
        yield return new WaitForSeconds(5.6f);
        animator.SetBool("growling", false);
        animator.SetBool("walking", false);
        snake.gotHit(false);
        transform.position = originalPosition;

    }



}
