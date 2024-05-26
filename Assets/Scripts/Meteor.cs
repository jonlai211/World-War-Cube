using UnityEngine;

public class Meteor : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Meteor collided with {collision.gameObject.name} which has tag {collision.gameObject.tag}");

        if (collision.gameObject.CompareTag("Plane") || collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("Meteor hit a valid target.");
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                Debug.Log("Applying damage to " + collision.gameObject.name);
                health.TakeDamage(2);
            }
            else
            {
                Debug.Log("No Health component found on " + collision.gameObject.name);
            }
            Destroy(gameObject);
        }
    }
}