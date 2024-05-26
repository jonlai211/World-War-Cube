using UnityEngine;

public class HeroController : MonoBehaviour
{
    public SkillsManager skillsManager;
    public Transform bossTransform;
    public GameObject bulletSpawnPoint;
    public float moveSpeed = 5f;
    public GameObject ringPrefab;
    private GameObject currentRing;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool isAttacking = false;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (bossTransform != null)
        {
            Vector3 directionToBoss = bossTransform.position - transform.position;
            directionToBoss.y = 0;
            transform.rotation = Quaternion.LookRotation(directionToBoss);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            skillsManager.SwitchSkill(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            skillsManager.SwitchSkill(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            skillsManager.SwitchSkill(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            skillsManager.SwitchSkill(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            skillsManager.SwitchSkill(5);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            isAttacking = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            ReleaseSkill();
            isAttacking = true;
        }
        if (Input.GetMouseButton(0) && isAttacking)
        {
            ReleaseSkill();
        }

        if (Input.GetMouseButtonUp(1))
        {
            SetTargetPosition();
        }

        if (isMoving)
        {
            MoveToTarget();
        }
    }

    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (currentRing != null)
            {
                Destroy(currentRing);
            }
            
            targetPosition = hit.point;
            targetPosition.y = transform.position.y;
            isMoving = true;
            
            currentRing = Instantiate(ringPrefab, targetPosition, Quaternion.identity);
        }
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
            Destroy(currentRing);
        }
    }

    void ReleaseSkill()
    {
        if (skillsManager == null || bossTransform == null)
        {
            Debug.Log("SkillsManager or Boss Transform is not assigned!");
            return;
        }

        Vector3 direction = (bossTransform.position - bulletSpawnPoint.transform.position).normalized;
        skillsManager.ExecuteSkill(bulletSpawnPoint.transform.position, direction);
    }
}
