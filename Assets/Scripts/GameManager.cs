using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public InputManager InputManager { get; private set; }

    public AudioManager AudioManager;

    private void Awake()
    {
        Instance = this;
        InputManager = new InputManager();
    }
}
