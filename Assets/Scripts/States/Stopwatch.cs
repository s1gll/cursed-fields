using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private float _timeLimit;
    private float _stopwatchTime;
    [SerializeField] private Text _stopWatchDisplay;

    private void UpdateStopwatchDisplay()
    {
        int minutes = Mathf.FloorToInt(_stopwatchTime / 60);
        int seconds = Mathf.FloorToInt(_stopwatchTime % 60);

        _stopWatchDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void UpdateStopwatch()
    {
        _stopwatchTime += Time.deltaTime;
        UpdateStopwatchDisplay();

    }
    public bool IsTimeUp()
    {
        return _stopwatchTime >= _timeLimit;
    }
}
