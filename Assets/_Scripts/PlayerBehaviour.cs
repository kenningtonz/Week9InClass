using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public bool isGrounded;
    private Rigidbody2D m_rigidBody2D;
    private SpriteRenderer m_spriteRenderer;
    private Animator m_animator;
    public float verticleforce;
    public float horizontalforce;


    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     if ((Keyboard.current.aKey.wasPressedThisFrame) || (Keyboard.current.leftAltKey.wasPressedThisFrame))
        {

            //m_rigidBody2D.AddForce(Vector2.left * horizontalforce * Time.deltaTime);
        }

    }



    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("jumped");
        m_animator.Play("Jump");

        m_rigidBody2D.AddForce(Vector2.up * verticleforce * Time.deltaTime);

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("moved");
       // m_animator.Play("Run");

         var direction =   context.ReadValue<Vector2>();
        m_rigidBody2D.AddForce(direction * horizontalforce);

        switch (context.control.name)
        {
            case "a":
            case "leftArrow":
                m_spriteRenderer.flipX = true;
             
                break;

            case "d":
            case "rightArrow":
                m_spriteRenderer.flipX = false;
              //  m_rigidBody2D.AddForce(Vector2.right * horizontalforce * Time.deltaTime);
                break;

        }

    }



    public void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }
}
