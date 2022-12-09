using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFS : MonoBehaviour
{
    public static DFS instance;

    private Rigidbody2D rb;
    private bool moveHori = false;
    private bool moveVerti = false;
    private float speed = 5f;
    private float edge = -0.5f;
    private bool toLeft = false;
    private bool toRight = true;
    private bool down = true;
    private bool up = false;
    private int postX = 0;
    public ActiveGM gm;
    private Vector2 vect;
    public bool[] list;
    private int[] total = new int[4];
    private Vector3 post;
    private Quaternion rot;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        for (int i = 0; i < list.Length; i++)
        {
            list[i] = false;
        }

        for (int i = 0; i < 4; i++)
        {
            total[i] = 0;
        }
    }

    private void Update()
    {
        if (moveVerti)
        {
            if (down)
            {
                if (rb.position.y > edge)
                {
                    vect = new Vector2(0, -1);
                }
                else
                {
                    down = false;
                }
            }
            else if (up)
            {
                if (rb.position.y < edge)
                {
                    vect = new Vector2(0, 1);
                }
                else
                {
                    up = false;
                }
            }
            else
            {
                vect = new Vector2(postX, 0);
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
                postX = -1;
                vect = new Vector2(postX, 0);
            }
            else if(toRight)
            {
                postX = 1;
                vect = new Vector2(postX, 0);
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

    public void PlayDFS()
    {
        StartCoroutine(StartDFS());
    }

    IEnumerator StartDFS()
    {
        yield return new WaitForSecondsRealtime(3f);
        moveVerti = true;
    }

    public void UpdateEdge(float upEdge)
    {
        edge = upEdge;
    }

    public void DirectionEdge(bool toUp, bool toDown)
    {
        up = toUp;
        down = toDown;
    }

    public void ChangeDirection()
    {
        moveVerti = true;
        moveHori = false;
        vect = new Vector2(0, 0);
    }

    public void TreasureCheck(int a, int b, float c, bool d, bool e)
    {
        for (int i = a; i < b; i++)
        {
            if (list[i] != true)
            {
                break;
            }
            else
            {
                UpdateEdge(c);
                ChangeDirection();
                DirectionEdge(d, e);
            }
        }
    }

     public void Stop()
    {
        moveVerti = false;
        moveHori = false;
    }

    public void ResetPost()
    {
        transform.position = post;
        transform.rotation = rot;

        for (int i = 0; i < list.Length; i++)
        {
            list[i] = false;
        }

        for (int i = 0; i < 4; i++)
        {
            total[i] = 0;
        }
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

        if (colli.gameObject.CompareTag("Treasure"))
        {
            if (colli.gameObject.transform.position.y == -0.5)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (list[i] != true)
                    {
                        list[i] = true;
                        total[0]++;
                        UpdateEdge(-1.5f);
                        ChangeDirection();
                        DirectionEdge(false, true);
                        break;
                    }

                    if (i == 1)
                    {
                        Stop();
                    }
                }
            }
            else if (colli.gameObject.transform.position.y == -1.5)
            {
                for (int i = 2; i < 6; i++)
                {
                    if (list[i] != true)
                    {
                        list[i] = true;
                        total[1]++;

                        if (i == 2)
                        {
                            UpdateEdge(-2.5f);
                            ChangeDirection();
                            DirectionEdge(false, true);
                        }
                        else if (i == 5)
                        {
                            UpdateEdge(-0.5f);
                            ChangeDirection();
                            DirectionEdge(true, false);
                        }

                        break;
                    }
                }
            }
            else if (colli.gameObject.transform.position.y == -2.5)
            {
                for (int i = 6; i < 14; i++)
                {
                    if (list[i] != true)
                    {
                        list[i] = true;
                        total[2]++;

                        if (i == 6)
                        {
                            UpdateEdge(-3.5f);
                            ChangeDirection();
                            DirectionEdge(false, true);
                        }
                        else if (i == 13)
                        {
                            UpdateEdge(-1.5f);
                            ChangeDirection();
                            DirectionEdge(true, false);
                        }


                        break;
                    }
                }
            }
            else if (colli.gameObject.transform.position.y == -3.5)
            {
                for (int i = 14; i < 30; i++)
                {
                    if (list[i] != true)
                    {
                        list[i] = true;
                        total[3]++;

                        if (i == 29)
                        {
                            UpdateEdge(-2.5f);
                            ChangeDirection();
                            DirectionEdge(true, false);
                        }

                        break;
                    }
                }
            }
        }
    }
}