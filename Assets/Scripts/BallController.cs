using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float forceMult;

    Rigidbody ballRB;

    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            float y = Random.value * forceMult;
            float x = (0.5f - Random.value) * 2 * forceMult;
            float z = (0.5f - Random.value) * 2 * forceMult;

            ballRB.AddForce(new Vector3(x, y, z), ForceMode.Impulse);
        }
    }
}
