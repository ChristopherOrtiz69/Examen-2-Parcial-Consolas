using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public float speed = 5f;
    public Transform targetPoint;
    private Rigidbody rb;
    private bool hasStartedMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (targetPoint != null)
        {
            Vector3 direction = (targetPoint.position - transform.position).normalized;
            rb.velocity = direction * speed;
            hasStartedMoving = true;
        }
    }

    void Update()
    {
        if (hasStartedMoving)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) 
        {
            Physics.IgnoreCollision(collision.collider, rb.GetComponent<Collider>()); 
            return;
        }

        Vector3 bounceDirection = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
        rb.velocity = bounceDirection * speed;
    }
}
