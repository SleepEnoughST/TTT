using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 rubyMove = new Vector2();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rubyMove = transform.position;
        
        animator.SetFloat("走路X", horizontal);
        animator.SetFloat("走路Y", vertical);

        rubyMove.x += moveSpeed * horizontal * Time.deltaTime;
        rubyMove.y += moveSpeed * vertical * Time.deltaTime;
        rb.MovePosition(rubyMove);

        if (horizontal == 0 && vertical == 0)
        {
            animator.SetTrigger("待機");
        }
        
    }
}
