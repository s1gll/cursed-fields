using UnityEngine;



public class PauseScreen : MonoBehaviour
{
    private bool _isPaused = false;
    [SerializeField]private GameObject _pauseScreenImage;
    public bool IsPaused => _isPaused;

    public void TogglePause()
    {
     _isPaused = !_isPaused;
    _pauseScreenImage.SetActive(_isPaused);
        Time.timeScale = _isPaused ? 0f : 1f;

    }
}
