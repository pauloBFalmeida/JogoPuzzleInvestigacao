using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PlayerMovement playerMovement;

    void Start()
    {
        // Se ja existe, acabe
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private bool cameraSeguindoCursor = true;
    public void CameraSeguirCursor()
    {
        playerMovement.ToggleLockCursor(true);
        cameraSeguindoCursor = true;
    }
    public void CameraPararCursor()
    {
        playerMovement.ToggleLockCursor(false);
        cameraSeguindoCursor = false;
    }

    
    public bool IsCameraSeguindoCursor()
    {
        return cameraSeguindoCursor;
    }
}
