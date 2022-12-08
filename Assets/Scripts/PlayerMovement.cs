using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float speed = 5f;
    private bool move = false;
    public ActiveGM gm;
    private Vector3 post;
    private Quaternion rot;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        post = transform.position;
        rot = transform.rotation;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (move == true)
        {
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
                }
                else if (movement.x < 0)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
                }
            }
            else if (Mathf.Abs(movement.x) < Mathf.Abs(movement.y))
            {
                if (movement.y > 0)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f));
                }
                else if (movement.y < 0)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                }
            }
            else if (movement.x == 1 && movement.y == 1)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 135f));
            }
            else if (movement.x == 1 && movement.y == -1)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 45f));
            }
            else if (movement.x == -1 && movement.y == 1)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -135));
            }
            else if (movement.x == -1 && movement.y == -1)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -45f));
            }
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D colli)
    {
        if (colli.gameObject.CompareTag("Batas"))
        {
            move = true;
            gm.ActiveEdge();
            TimerCD.instance.Play();
        }
    }

    public void ResetPost()
    {
        transform.position = post;
        transform.rotation = rot;
    }
}
