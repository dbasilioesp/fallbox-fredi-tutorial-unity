using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forceMultiplier = 4f;
    public float maximumVelocity = 3f;
    private Rigidbody rigidBody;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        var axisX = Input.GetAxis("Horizontal");
        var force = new Vector3(axisX * forceMultiplier, 0, 0);

        if (rigidBody.velocity.magnitude <= maximumVelocity) {
            rigidBody.AddForce(force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            rigidBody.isKinematic = true;
            gameController.RestartGame();
        }
    }
}
