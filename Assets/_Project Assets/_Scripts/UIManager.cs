using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text T_playerCount;

    [Header (" Canvas ")]
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject gameplayCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject nextLevelCanvas;

    #region Action Listeners
    private void OnEnable()
    {
        GameManager.GameStateChange += OnGameStateChange;
    }

    private void OnDisable()
    {
        GameManager.GameStateChange -= OnGameStateChange;
    }
    #endregion

    private void Start()
    {
        ChangeCanvas(mainMenuCanvas);
    }

    public void _OnGameStart()
    {
        ChangeCanvas(gameplayCanvas);
    }

    public void SetPlayerCount (int _playerCount)
    {
        T_playerCount.text = _playerCount.ToString();
    }

    public void OnGameStateChange(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.GameOver)
        {
            ChangeCanvas(gameOverCanvas);
        }
        else if (gameState == GameManager.GameState.LevelCompleted)
        {
            nextLevelCanvas.SetActive(true);
            ChangeCanvas(nextLevelCanvas);
        }
    }

    public void _RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeCanvas(GameObject desireCanvas)
    {
        CloseAllCanvas();
        desireCanvas.SetActive(true);
    }

    public void CloseAllCanvas()
    {
        mainMenuCanvas.SetActive(false);
        gameplayCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        nextLevelCanvas.SetActive(false);
    }
}