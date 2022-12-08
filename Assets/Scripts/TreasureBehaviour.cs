using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBehaviour : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D colli)
    {
        if (colli.gameObject.CompareTag("Robot"))
        {
            ScoreManager.instance.AddScore();
            gameObject.SetActive(false);
        }
    }
}
