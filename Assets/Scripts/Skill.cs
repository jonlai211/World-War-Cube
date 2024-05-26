using UnityEngine;

[System.Serializable]
public class Skill
{
    public int level;
    public GameObject projectilePrefab;
    public GameObject indicatorPrefab;
    public float cooldown;
    public float speed;
    public string attackMethod;
}