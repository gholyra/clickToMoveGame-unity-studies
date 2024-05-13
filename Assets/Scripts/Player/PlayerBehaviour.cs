using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float turnSpeed;
    [SerializeField] private LayerMask attackLayer;
    [SerializeField] private ParticleSystem clickParticle;
    [SerializeField] private FireBall spell;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = this.moveSpeed;
        agent.acceleration = this.acceleration;
        agent.angularSpeed = this.turnSpeed;
    }

    private void Start()
    {
        GameManager.Instance.InputManager.OnPlayerMove += HandleClick;
    }

    private void HandleClick()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                HandleAttack(hit);
            }
            else
            {
                HandleMovement(hit);
            }
        }
    }

    private void HandleAttack(RaycastHit hit)
    {
        GetComponent<Animator>().SetTrigger("attack");
        transform.LookAt(hit.point);
        Instantiate(spell, transform.position, transform.rotation);
    }

    private void HandleMovement(RaycastHit hit)
    {
        agent.SetDestination(hit.point);
        if (clickParticle != null)
        {
            ParticleSystem particle = Instantiate(clickParticle, hit.point, clickParticle.transform.rotation);
            Destroy(particle.gameObject, 0.5f);
        }
        GameManager.Instance.AudioManager.PlaySFX(SFX.click);
    }

    public NavMeshAgent GetPlayerAgent()
    {
        return agent;
    }
}
