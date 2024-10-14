using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int playerIndex;
    public float rayDistance = 5f;

    void Update()
    {

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Ball"))
            {
                scoreManager.DecreaseLife(playerIndex);
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
    }
}

