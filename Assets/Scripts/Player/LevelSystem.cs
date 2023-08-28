using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSystem : MonoBehaviour
{
    [SerializeField] private UpgradeManager _upgradeManager;
    [SerializeField] private Image _experienceBar;
    [SerializeField] private Text _levelText;
    private int _experience = 0;
    private int _level = 1;
    private int _experienceCap;
    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }
    [SerializeField] private List<LevelRange> _levelRanges;
    private void Start()
    {
        _experienceCap = _levelRanges[0].experienceCapIncrease;
        UpdateLevelBar();
        UpdateLevelText();
    }
    private void UpdateLevelBar()
    {
        _experienceBar.fillAmount = (float)_experience / _experienceCap;
    }
    private void UpdateLevelText()
    {
        _levelText.text = "Level " + _level.ToString();
    }
    private void LevelUpChecker()
    {
        if (_experience >= _experienceCap)
        {
            _experience -= _experienceCap;

            _level++;
            int experienceCapIncrease = 0;
            foreach (LevelRange range in _levelRanges)
            {
                if (_level >= range.startLevel && _level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            _experienceCap += experienceCapIncrease;
            UpdateLevelBar();
            UpdateLevelText();
            _upgradeManager.Suggest();


        }
    }
    public void IncreaseExperience(int amount)
    {
        _experience += amount;
        UpdateLevelBar();
        LevelUpChecker();

    }
}



