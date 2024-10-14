using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public float speed = 5f; 
    public float returnDelay = 0.2f; 
    public enum MovementAxis { X, Y, Z } 
    public MovementAxis movementAxis = MovementAxis.X; 
    private Transform currentBall; 
    private Vector3 initialPosition; 
    private float timer = 0f; 
    private bool isReturning = false; 

   
    private void Start()
    {
        initialPosition = transform.position;
    }

   
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Ball") && currentBall == null)
        {
            currentBall = other.transform; 
            isReturning = false; 
            timer = 0f; 
        }
    }

   
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball") && currentBall == other.transform)
        {
           
            timer = returnDelay;
            currentBall = null;
        }
    }

    private void Update()
    {
        
        if (currentBall != null)
        {
            Vector3 newPosition = transform.position;

            
            switch (movementAxis)
            {
                case MovementAxis.X:
                    newPosition.x = Mathf.MoveTowards(transform.position.x, currentBall.position.x, speed * Time.deltaTime);
                    break;
                case MovementAxis.Y:
                    newPosition.y = Mathf.MoveTowards(transform.position.y, currentBall.position.y, speed * Time.deltaTime);
                    break;
                case MovementAxis.Z:
                    newPosition.z = Mathf.MoveTowards(transform.position.z, currentBall.position.z, speed * Time.deltaTime);
                    break;
            }

            transform.position = newPosition;
        }
        
        else if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                isReturning = true; 
            }
        }

        
        if (isReturning)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);

           
            if (Vector3.Distance(transform.position, initialPosition) < 0.01f)
            {
                transform.position = initialPosition; 
                isReturning = false; 
            }
        }
    }
}
