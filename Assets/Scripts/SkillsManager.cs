using UnityEngine;
using System.Collections.Generic;

public class SkillsManager : MonoBehaviour
{
    public List<Skill> skills = new List<Skill>();
    public Transform bossTransform;
    private Skill currentSkill;
    private float lastAttackTime;
    public int aoeSkillCount = 0;

    void Start()
    {
        if (skills.Count > 0)
            currentSkill = skills[0];
    }

    public void ExecuteSkill(Vector3 spawnPosition, Vector3 direction)
    {
        switch (currentSkill.attackMethod)
        {
            case "Basic":
                Attack(spawnPosition, direction);
                break;
            case "Parabolic":
                ParabolicAttack(spawnPosition, direction);
                break;
            case "AOE":
                AreaOfEffectAttack(bossTransform);
                break;
            case "Attach":
                AttachAttack(spawnPosition, direction);
                break;
            case "Element":
                ElementalReactionsAttack(spawnPosition, direction);
                break;
            default:
                Attack(spawnPosition, direction);
                break;
        }
    }

    public void BossRelease(Vector3 spawnPosition, Vector3 direction)
    {
        int randomSkillIndex = Random.Range(0, 1);
        switch (randomSkillIndex)
        {
            case 0:
                Attack(spawnPosition, direction);
                break;
            case 1:
                ParabolicAttack(spawnPosition, direction);
                break;
        }
    }

    public void Attack(Vector3 spawnPosition, Vector3 direction)
    {
        Skill basicSkill = skills[0];
        // Debug.Log("Attempting to attack. Cooldown: " + (Time.time - lastAttackTime) + ", Required: " + currentSkill.cooldown);
        if (Time.time - lastAttackTime >= basicSkill.cooldown && basicSkill.projectilePrefab != null)
        {
            Vector3 horizontalDirection = new Vector3(direction.x, 0, direction.z).normalized;
            // Debug.Log("Attacking from " + spawnPosition + " towards " + direction);
            GameObject projectile = Instantiate(basicSkill.projectilePrefab, spawnPosition, Quaternion.LookRotation(horizontalDirection));
            projectile.GetComponent<Rigidbody>().velocity = horizontalDirection * basicSkill.speed;
            
            lastAttackTime = Time.time;
        }
    }

    public void ParabolicAttack(Vector3 spawnPosition, Vector3 direction)
    {
        Skill parabolicSkill = skills[1];

        if (Time.time - lastAttackTime >= parabolicSkill.cooldown && parabolicSkill.projectilePrefab != null)
        {
            GameObject projectile = Instantiate(parabolicSkill.projectilePrefab, spawnPosition, Quaternion.LookRotation(direction));
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            direction = direction.normalized;

            float angle = 45.0f;
            float radianAngle = angle * Mathf.Deg2Rad;
            
            float distance = 1.3f * parabolicSkill.speed;
            float gravity = Physics.gravity.magnitude;
            float initialVelocity = Mathf.Sqrt((gravity * distance * distance) / (2 * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle) * (distance * Mathf.Tan(radianAngle))));

            Vector3 horizontalVelocity = direction * (initialVelocity * Mathf.Cos(radianAngle));
            float verticalVelocity = initialVelocity * Mathf.Sin(radianAngle);

            rb.velocity = new Vector3(horizontalVelocity.x, verticalVelocity, horizontalVelocity.z);
            rb.useGravity = true;

            lastAttackTime = Time.time;
        }
    }

    public void AreaOfEffectAttack(Transform bossTransform)
    {
        if (aoeSkillCount <= 0)
        {
            // Debug.Log("No AOE (" + aoeSkillCount + ") skills available.");
            return;
        }

        Skill aoeSkill = skills[2];
        if (Time.time - lastAttackTime >= aoeSkill.cooldown && aoeSkill.projectilePrefab != null && aoeSkill.indicatorPrefab != null)
        {
            GameObject ring = Instantiate(aoeSkill.indicatorPrefab, new Vector3(bossTransform.position.x, 5.0f, bossTransform.position.z), Quaternion.identity);
            ring.transform.localScale = new Vector3(6.0f, 2.0f, 6.0f);
            float duration = 1.5f;
            int meteorCount = 10;
            float meteorHeight = 20.0f;

            Destroy(ring, duration);

            for (int i = 0; i < meteorCount; i++)
            {
                Vector3 meteorPosition = bossTransform.position + new Vector3(Random.Range(-3.0f, 3.0f), meteorHeight, Random.Range(-3.0f, 3.0f));
                GameObject meteor = Instantiate(aoeSkill.projectilePrefab, meteorPosition, Quaternion.identity);
                meteor.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 0) * aoeSkill.speed;

                Destroy(meteor, duration);
            }

            lastAttackTime = Time.time;
            aoeSkillCount--;

            aoeSkillCount = Mathf.Max(aoeSkillCount, 0);
        }
    }

    public void AttachAttack(Vector3 spawnPosition, Vector3 direction)
    {
        Skill attachSkill = skills[3];
        if (Time.time - lastAttackTime >= attachSkill.cooldown && attachSkill.projectilePrefab != null)
        {
            Vector3 horizontalDirection = new Vector3(direction.x, 0, direction.z).normalized;
            GameObject projectile = Instantiate(attachSkill.projectilePrefab, spawnPosition, Quaternion.LookRotation(horizontalDirection));
            projectile.GetComponent<Rigidbody>().velocity = horizontalDirection * attachSkill.speed;
            lastAttackTime = Time.time;
        }
    }

    public void ElementalReactionsAttack(Vector3 spawnPosition, Vector3 direction)
    {
        Skill elementSkill = skills[4];
        if (Time.time - lastAttackTime >= elementSkill.cooldown && elementSkill.projectilePrefab != null)
        {
            Vector3 horizontalDirection = new Vector3(direction.x, 0, direction.z).normalized;
            GameObject projectile = Instantiate(elementSkill.projectilePrefab, spawnPosition, Quaternion.LookRotation(horizontalDirection));
            projectile.GetComponent<Rigidbody>().velocity = horizontalDirection * elementSkill.speed;
            lastAttackTime = Time.time;
        }
    }

    public void SwitchSkill(int level)
    {
        Skill skill = skills.Find(s => s.level == level);
        if (skill != null)
        {
            currentSkill = skill;
            Debug.Log("Switched to skill level " + level);
        }
        else
        {
            Debug.LogError("Skill level " + level + " not found!");
        }
    }
    
    public string GetCurrentSkillMethod()
    {
        return currentSkill.attackMethod;
    }
    
    public void AddAOESkill()
    {
        aoeSkillCount++;
    }
}