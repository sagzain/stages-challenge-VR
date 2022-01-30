using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAgent : Enemy
{
    [Range(1,10)]
    [SerializeField] private int _movementSpeed;
    
    private NavMeshAgent _navMesh;

    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _navMesh.speed = _movementSpeed;
    }

    void Update()
    {
        if(!_isDead)
        {
            _animator.SetFloat("Speed", _movementSpeed);
            _navMesh.SetDestination(Player.Instance.transform.position);
        }
    }
}
