using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGM : MonoBehaviour
{
    public static ActiveGM instance;

    public GameObject[] go;

    void Awake()
    {
        instance = this;
    }

    public void ActiveEdge()
    {
        go[0].SetActive(true);
    }

    public void Active()
    {
        go[0].SetActive(false);
    }
}
