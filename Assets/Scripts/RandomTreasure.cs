using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreasure : MonoBehaviour
{
    public GameObject[] treasures;
    private int treRand;
    private Transform post;
    private float postX;
    private float postY;

    void Start()
    {
        treRand = Random.Range(0, treasures.Length);

        for (int i = 0; i < 2; i++)
        {
            if (i < 2)
            {
                postX = Random.Range(-8, 8);
                postY = (float)-0.5;
                post.position = new Vector3(postX, postY, 0);
                Instantiate(treasures[treRand], post.position, transform.rotation);
            }
        }
    }
}
