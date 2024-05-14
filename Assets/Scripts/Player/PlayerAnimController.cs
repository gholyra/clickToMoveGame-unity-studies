using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float playerSpeed = GameManager.Instance.GetPlayerNavMeshAgent().velocity.magnitude;
        animator.SetFloat("speed", playerSpeed);
    }
}
