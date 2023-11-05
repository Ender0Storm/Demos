using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform cannonPos;
    public Transform barrelTipPos;
    public Transform targetPos;

    public float targetMoveSpeed;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        targetPos.Translate(new Vector3(horizontalInput, 0, verticalInput) * targetMoveSpeed * Time.deltaTime);

        UpdateCannon();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireCannon();
        }
    }

    private void UpdateCannon()
    {
        float angle = Vector2.SignedAngle(new Vector2(targetPos.position.x - cannonPos.position.x, targetPos.position.z - cannonPos.position.z), Vector2.up);
        cannonPos.rotation = Quaternion.Euler(0, angle, 0);
    }

    private void FireCannon()
    {
        GameObject ball = Instantiate(ballPrefab, barrelTipPos.position, Quaternion.identity);
        Rigidbody ballRB = ball.GetComponent<Rigidbody>();

        float g = Physics.gravity.magnitude;
        float sqrDistance = new Vector2(targetPos.position.x - barrelTipPos.position.x, targetPos.position.z - barrelTipPos.position.z).sqrMagnitude;
        float distance = Mathf.Sqrt(sqrDistance);
        Vector3 initialVelocity = (barrelTipPos.position - cannonPos.position).normalized * Mathf.Sqrt(g * sqrDistance / (barrelTipPos.position.y + distance));

        ballRB.velocity = initialVelocity;
    }
}
