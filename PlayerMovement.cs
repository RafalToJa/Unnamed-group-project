using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float speed = 5f;
    float movement;
    public float jumpForce = 15f;
    [Space]
    public Transform groundCheck;
    public LayerMask groundMask;
    bool grounded;
    [Space]
    public float dashPower = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        if(movement < 0) { transform.rotation = Quaternion.Euler(0, 180, 0); }
        if(movement > 0) { transform.rotation = Quaternion.Euler(0, 0, 0); }
        animator.SetFloat("Movement", Mathf.Abs(movement));
        GroundChecking();
        animator.SetBool("Grounded", grounded);
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(transform.eulerAngles.y == 180) { rb.AddForce(Vector2.left * dashPower + Vector2.up * 4); }
            if(transform.eulerAngles.y == 0) { rb.AddForce(Vector2.right * dashPower + Vector2.up * 4); }
            animator.SetTrigger("Dash");
        }
    }
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + movement * speed * Time.fixedDeltaTime, transform.position.y);
    }

    void GroundChecking()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(groundCheck.position, .1f, groundMask);
        if(colls.Length > 0) { grounded = true; }
        else { grounded = false; }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, .1f);
    }
}