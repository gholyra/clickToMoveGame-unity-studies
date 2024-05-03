using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float turnSpeed;

    [SerializeField] private ParticleSystem clickParticle;

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
                HandleAttack();
            }
            else
            {
                HandleMovement(hit);
            }
        }
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

    private void HandleAttack()
    {
        
    }

    public NavMeshAgent GetPlayerAgent()
    {
        return agent;
    }
}
