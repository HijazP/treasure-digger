using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreasure : MonoBehaviour
{
    public static RandomTreasure instance;

    public GameObject[] treasures;
    private int treRand;
    private Vector3 post;
    private int postX;
    private float postY;
    private List<GameObject> list = new List<GameObject>();
    private GameObject prefab;
    private int[] save = new int[30];

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 1; i <= 30; i++)
        {
            treRand = Random.Range(0, treasures.Length);

            if (i <= 2)
            {
                postX = CheckX(2, i);
                postY = -0.5f;
            }
            else if (i <= 6)
            {
                postX = CheckX(6, i);
                postY = -1.5f;
            }
            else if (i <= 14)
            {
                postX = CheckX(14, i);
                postY = -2.5f;
            }
            else if (i <= 30)
            {
                postX = CheckX(30, i);
                postY = -3.5f;
            }

            post = new Vector3(postX, postY, 0);

            prefab = Instantiate(treasures[treRand], post, transform.rotation);
            list.Add(prefab);
        }
    }

    public void PrefabReset()
    {
        foreach (GameObject ls in list)
        {
            ls.SetActive(true);
        }
    }

    private int CheckX(int a, int b)
    {
        int c = 0;

        if (a == 2)
        {
            if (b == 1)
            {
                c = Random.Range(-8, -1);
            }
            else
            {
                c = Random.Range(1, 8);
            }
        }
        else if (a == 6)
        {
            if (b == 3)
            {
                c = Random.Range(-8, -5);
            }
            else if (b == 4)
            {
                c = Random.Range(-4, 0);
            }
            else if (b == 5)
            {
                c = Random.Range(1, 4);
            }
            else
            {
                c = Random.Range(5, 8);
            }
        }
        else if (a == 14)
        {
            if (b == 7)
            {
                c = Random.Range(-8, -7);
            }
            else if (b == 8)
            {
                c = Random.Range(-6, -5);
            }
            else if (b == 9)
            {
                c = Random.Range(-4, -3);
            }
            else if (b == 10)
            {
                c = Random.Range(-2, -1);
            }
            else if (b == 11)
            {
                c = Random.Range(1, 2);
            }
            else if (b == 12)
            {
                c = Random.Range(3, 4);
            }
            else if (b == 13)
            {
                c = Random.Range(5, 6);
            }
            else
            {
                c = Random.Range(7,8);
            }
        }
        else if (a == 30)
        {
            c = b-15-8;
        }

        return c;
    }
}
