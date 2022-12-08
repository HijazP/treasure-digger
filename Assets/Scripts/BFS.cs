using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool moveHori = false;
    private bool moveVerti = false;
    private float speed = 5f;
    private float edge;    
    public ActiveGM gm;
    private Vector2 vect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (moveVerti)
        {
            if (rb.position.y <= UpdateEdge())
            {
                vect = new Vector2(0, -1);
                rb.MovePosition(rb.position + vect.normalized * speed * Time.fixedDeltaTime);
            }
            else
            {
                moveVerti = false;
            }
        }
    }

    public void PlayBFS()
    {
        StartCoroutine(StartBFS());
    }

    IEnumerator StartBFS()
    {
        yield return new WaitForSecondsRealtime(3f);
        moveVerti = true;
    }

    float UpdateEdge()
    {
        edge = -0.5f;
        return edge;
    }

    void OnTriggerEnter2D(Collider2D colli)
    {
        if (colli.gameObject.CompareTag("Batas"))
        {
            gm.ActiveEdge();
            TimerCD.instance.Play();
        }
    }
}
