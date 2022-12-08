using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGM : MonoBehaviour
{
    public GameObject[] go;

    public void ActiveEdge()
    {
        go[0].SetActive(true);
    }
}
