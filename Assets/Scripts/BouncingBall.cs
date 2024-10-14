using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public float speed = 5f;
    public float bounceMultiplier = 1.1f;
    public Transform targetPoint;
    private Rigidbody rb;
    private bool hasStartedMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.useGravity = true;
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
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z).normalized * speed;
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
        bounceDirection.y = 0;
        bounceDirection += collision.contacts[0].normal * 0.1f;
        rb.velocity = bounceDirection.normalized * speed * bounceMultiplier;
    }
}
