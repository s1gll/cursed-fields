using UnityEngine;

public enum GameState
{
    Gameplay,
    Pause,
    GameOver,
    LevelUp,
    Victory
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private UpgradeManager _upgradeManager;
    [SerializeField] private Stopwatch _stopwatch;
    [SerializeField] private AudioSource _playerDiedSound;
    [SerializeField] private AudioSource _mainMusic;

    [SerializeField] private GameState _currentState = GameState.Gameplay;

    private void Update()
    {
        switch (_currentState)
        {
            case GameState.Gameplay:
                UpdateGameplay();
                break;
            case GameState.Pause:
                UpdatePause();
                break;
            case GameState.GameOver:
                UpdateGameOver();
                break;
            case GameState.LevelUp:
                UpdateLevelUp();
                break;
            case GameState.Victory:
                UpdateVictory();
                break;
        }
    }

    private void UpdateGameplay()
    {
        Time.timeScale = 1f;
        IsDead();
        CheckForPause();
        _stopwatch.UpdateStopwatch();
        if (_stopwatch.IsTimeUp())
        {
            ChangeState(GameState.GameOver);
        }
    }

    private void UpdatePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseScreen.TogglePause();
            ChangeState(GameState.Gameplay);
        }
        if (!_pauseScreen.IsPaused)
        {
            ChangeState(GameState.Gameplay);
        }
    }

    private void UpdateGameOver()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

    }

    private void UpdateLevelUp()
    {
        Time.timeScale = 0f;
    }
    private void UpdateVictory()
    {
        _victoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    private void IsDead()
    {
        if (_playerStats.IsDead)
        {
            _playerDiedSound.Play();
            _mainMusic.Stop();
            foreach (var enemy in _enemies)
            {
                enemy.enabled = false;
            }
            ChangeState(GameState.GameOver);
        }
    }

    private void CheckForPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseScreen.TogglePause();
            if (_currentState == GameState.Gameplay)
            {
                ChangeState(GameState.Pause);
            }
            else if (_currentState == GameState.Pause)
            {
                ChangeState(GameState.Gameplay);
            }
        }
    }

    public void ChangeState(GameState newState)
    {
        _currentState = newState;

    }


    public void ShowLevelUpScreen()
    {
        ChangeState(GameState.LevelUp);

    }

    public void HideLevelUpScreen()
    {
        ChangeState(GameState.Gameplay);

    }
}
