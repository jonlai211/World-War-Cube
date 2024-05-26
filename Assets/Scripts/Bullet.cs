using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet hit: " + other.gameObject.name);
        if (other.CompareTag("Obstacle") || other.CompareTag("Boss"))
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(1);
            }
            else
            {
                Debug.Log("No Health component found on " + other.gameObject.name);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Hero"))
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(5);
            }
            else
            {
                Debug.Log("No Health component found on " + other.gameObject.name);
            }
            Destroy(gameObject);
        }
    }
}