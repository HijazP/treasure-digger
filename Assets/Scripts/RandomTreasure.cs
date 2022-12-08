using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreasure : MonoBehaviour
{
    public static RandomTreasure instance;

    public GameObject[] treasures;
    private int treRand;
    private Vector3 post;
    private float postX;
    private float postY;
    private List<GameObject> list = new List<GameObject>();
    private GameObject prefab;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 1; i <= 30; i++)
        {
            treRand = Random.Range(0, treasures.Length);

            postX = Random.Range(-8f, 8f);

            if (i <= 2)
            {
                postY = -0.5f;
            }
            else if (i <= 6)
            {
                postY = -1.5f;
            }
            else if (i <= 14)
            {
                postY = -2.5f;
            }
            else if (i <= 30)
            {
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
}
