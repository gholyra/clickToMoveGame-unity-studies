using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    public AudioManager AudioManager;

    [SerializeField] private PlayerBehaviour playerBehaviour;
    
    private void Awake()
    {
        Instance = this;
        InputManager = new InputManager();
    }

    public NavMeshAgent GetPlayerNavMeshAgent()
    {
        return playerBehaviour.GetPlayerAgent();
    }
}
