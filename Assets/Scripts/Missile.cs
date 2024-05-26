using UnityEngine;

public class Missile : MonoBehaviour
{
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane") || collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Boss"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(1);
            }
            else
            {
                Debug.Log("No Health component found on " + collision.gameObject.name);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Plane"))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(5);
            }
            else
            {
                Debug.Log("No Health component found on " + collision.gameObject.name);
            }
            Destroy(gameObject);
        }
    }
}