using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS : MonoBehaviour
{
    public static BFS instance;

    private Rigidbody2D rb;
    private bool moveHori = false;
    private bool moveVerti = false;
    private float speed = 5f;
    private float edge = -0.5f;
    private bool toLeft = false;
    private bool toRight = true;
    public ActiveGM gm;
    private Vector2 vect;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (moveVerti)
        {
            if (rb.position.y > edge)
            {
                vect = new Vector2(0, -1);
            }
            else
            {
                vect = new Vector2(0, 0);
                moveVerti = false;
                moveHori = true;
                
                if (edge == -0.5f)
                {
                    toLeft = true;
                }
            }
        }
        else if (moveHori)
        {
            if (toLeft)
            {
                vect = new Vector2(-1, 0);
            }
            else if(toRight)
            {
                vect = new Vector2(1, 0);
            }
        }

        if (Mathf.Abs(vect.x) > Mathf.Abs(vect.y))
        {
            if (vect.x > 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
            }
            else if (vect.x < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
            }
        }
        else if (Mathf.Abs(vect.x) < Mathf.Abs(vect.y))
        {
            if (vect.y > 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f));
            }
            else if (vect.y < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }
        }
        else if (vect.x == 1 && vect.y == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 135f));
        }
        else if (vect.x == 1 && vect.y == -1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 45f));
        }
        else if (vect.x == -1 && vect.y == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -135));
        }
        else if (vect.x == -1 && vect.y == -1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -45f));
        }
    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + vect.normalized * speed * Time.fixedDeltaTime);
    }

    public void PlayBFS()
    {
        StartCoroutine(StartBFS());
        moveVerti = true;
    }

    IEnumerator StartBFS()
    {
        yield return new WaitForSecondsRealtime(3f);
    }

    public void UpdateEdge(float upEdge)
    {
        edge = upEdge;
        Debug.Log(edge);
    }

    public void ChangeDirection()
    {
        moveVerti = true;
        moveHori = false;
    }

     public void Stop()
    {
        moveVerti = false;
        moveHori = false;
    }

    void OnTriggerEnter2D(Collider2D colli)
    {
        if (colli.gameObject.CompareTag("Batas"))
        {
            gm.ActiveEdge();
            TimerCD.instance.Play();
        }

        if (colli.gameObject.CompareTag("BatasKiri"))
        {
            toLeft = false;
            toRight = true;
        }
        else if (colli.gameObject.CompareTag("BatasKanan"))
        {
            toRight = false;
            toLeft = true;
        }
    }
}