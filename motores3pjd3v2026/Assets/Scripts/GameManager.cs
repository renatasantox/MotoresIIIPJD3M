using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;

    public PlayerInput playerInput;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeState(GameState.Iniciando);
        LoadScene("Splash");
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        Debug.Log("Estado atual: " + currentState);
    }

    public void LoadScene(string sceneName)
    {
        switch (currentState)
        {
            case GameState.Iniciando:
                if (sceneName == "Splash")
                {
                    SceneManager.LoadScene(sceneName);
                }
                break;

            case GameState.MenuPrincipal:
                if (sceneName == "GetStarted_Scene")
                {
                    SceneManager.LoadScene(sceneName);
                    ChangeState(GameState.Gameplay);
                }
                break;

            case GameState.Gameplay:
                Debug.Log("Você já está em Gameplay.");
                break;
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
        ChangeState(GameState.MenuPrincipal);
    }

    public void AssignPlayerInput(PlayerInput input)
    {
        playerInput = input;
        Debug.Log("Player Input atribuído com sucesso.");
    }
}