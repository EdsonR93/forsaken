using UnityEngine;



public class CombatAnimationController : MonoBehaviour
{
    [SerializeField] private int attackAnimationIndex = 0;
    [SerializeField] private int deathAnimationIndex = 0;

    private SPUM_Prefabs spum;
    void Awake()
    {
        spum = GetComponent<SPUM_Prefabs>();
        if (spum == null)
        {
            Debug.LogError(gameObject.name + " is missing SPUM_Prefabs component.");
            enabled = false;
            return;
        }
        spum.OverrideControllerInit();
    }
    void OnEnable()
    {
        CombatEvents.OnAttack += HandleAttack;
        CombatEvents.OnHit += HandleHit;
        CombatEvents.OnDeath += HandleDeath;
    }

    void OnDisable()
    {
        CombatEvents.OnAttack -= HandleAttack;
        CombatEvents.OnHit -= HandleHit;
        CombatEvents.OnDeath -= HandleDeath;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void HandleAttack(Transform attacker, Transform target)
    {
        if (attacker != transform) return;
        if (spum == null) return;

        spum.PlayAnimation(PlayerState.ATTACK, attackAnimationIndex);
    }

    void HandleHit(Transform attacker, Transform target, float damage)
    {
        // Implement hit reaction animation logic here
        // Example: target.GetComponent<Animator>().SetTrigger("Hit");
    }

    void HandleDeath(Transform character)
    {
        if (character != transform) return;
        if (spum == null) return;
        spum.PlayAnimation(PlayerState.DEATH, deathAnimationIndex);
    }
}

