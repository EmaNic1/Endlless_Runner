using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : MonoBehaviour
{
    private Rigidbody2D Rb;
    private Animator anim;

    public float speed = 5f;
    public float acceleration = 1.2f;
    public float jumpForce = 10f;

    private enum State { run, jump, dash};
    private State state = State.run;//default anim

    private Collider2D coll;
    [SerializeField] private LayerMask Ground;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //speed is increasing by time
        speed += acceleration * Time.deltaTime;

        //Player moving forward without any key pressed
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //Press space for jump
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(Ground))
        {
            Rb.velocity = new Vector2(Rb.velocity.x, jumpForce);
            state = State.jump;
        }

        if (Input.GetKey(KeyCode.S) && coll.IsTouchingLayers(Ground))
        {
            state = State.dash;
        }

        VelocityState();
        anim.SetInteger("State", (int)state);
    }

    private void VelocityState()
    {
        if (state == State.jump)
        {
            if (Rb.velocity.y < 0.1f && coll.IsTouchingLayers(Ground))
            {
                state = State.run;
            }
        }

        if (state == State.dash && !Input.GetKey(KeyCode.S))
        {
            state = State.run;
        }
    }
}
