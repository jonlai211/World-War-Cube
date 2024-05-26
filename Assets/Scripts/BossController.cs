using UnityEngine;

public class BossController : MonoBehaviour
{
    public SkillsManager skillsManager;
    public Transform heroTransform;
    public GameObject bulletSpawnPoint;
    public float attackInterval = 0.5f;
    private float attackTimer;

    void Start()
    {
        attackTimer = attackInterval;
    }

    void Update()
    {
        if (heroTransform != null)
        {
            Vector3 directionToHero = (heroTransform.position - transform.position).normalized;
            directionToHero.y = 0;
            transform.rotation = Quaternion.LookRotation(directionToHero);
        }

        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            BossRandomAttack();
            attackTimer = attackInterval;
        }
    }

    void BossRandomAttack()
    {
        if (skillsManager == null || heroTransform == null)
        {
            Debug.Log("SkillsManager or Hero Transform is not assigned!");
            return;
        }

        Vector3 direction = (heroTransform.position - bulletSpawnPoint.transform.position).normalized;
        skillsManager.BossRelease(bulletSpawnPoint.transform.position, direction);
    }
}