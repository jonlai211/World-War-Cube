using UnityEngine;

public class ElementBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            BurningEffect effect = collision.gameObject.GetComponent<BurningEffect>();
            if (effect != null)
            {
                effect.Activate();
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Plane"))
        {
            Destroy(gameObject);
        }
    }
}