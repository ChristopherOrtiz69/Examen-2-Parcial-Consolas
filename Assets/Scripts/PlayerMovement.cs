using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
       
        float moveHorizontal = Input.GetAxis("Horizontal");

        
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * moveSpeed;

       
        rb.velocity = new Vector3(movement.x, rb.velocity.y, rb.velocity.z);
    }
}
