using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
