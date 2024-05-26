using UnityEngine;

public class AttachBullet : MonoBehaviour
{
    public float stickDuration = 4.0f;
    public int damagePerSecond = 1;
    public float lifetime = 5.0f;
    private float damageTimer = 0;
    private bool isSticking = false;
    private Transform stickTarget = null;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    
    void Update()
    {
        if (isSticking)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= 1.0f)
            {
                if (stickTarget != null)
                {
                    Health health = stickTarget.GetComponent<Health>();
                    if (health != null)
                    {
                        health.TakeDamage(damagePerSecond);
                    }
                }
                damageTimer = 0;
            }

            if (stickDuration <= 0)
            {
                Destroy(gameObject);
            }
            stickDuration -= Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            transform.SetParent(collision.transform);
            stickTarget = collision.transform;
            isSticking = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Plane"))
        {
            Destroy(gameObject);
        }
    }
}