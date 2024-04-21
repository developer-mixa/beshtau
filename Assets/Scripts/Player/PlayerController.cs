using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player _player;
    private HealthUI _healthUI;
    private TempItemUI _tempItemUI;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _healthUI = FindObjectOfType<HealthUI>();
        _tempItemUI = FindObjectOfType<TempItemUI>();
    }

    private void OnEnable()
    {
        _player.OnLifeChanged += UpdateHealths;
        _player.OnDefenseChanged += UpdateDefenseState;
        _player.OnScoreChanged += UpdateScoreState;
        _player.OnDoubledScoreTime += UpdateDoubleMoneyTimeState;
        _player.OnAddHeart += AddHeart;
    }

    private void OnDisable()
    {
        _player.OnLifeChanged -= UpdateHealths;
        _player.OnDefenseChanged -= UpdateDefenseState;
        _player.OnScoreChanged -= UpdateScoreState;
        _player.OnDoubledScoreTime -= UpdateDoubleMoneyTimeState;
        _player.OnAddHeart -= AddHeart;
    }

    private void UpdateDoubleMoneyTimeState(int currentSecond)
    {
        UpdateTempItemState(currentSecond, TempItemType.DoubleScore);
    }

    private void UpdateScoreState(int score)
    {
        _tempItemUI.RenderCountScores(score);
    }

    private void UpdateHealths(int lifeCount)
    {
        _healthUI.RenderHealths(lifeCount);
    }

    private void AddHeart() => _healthUI.AddHeart();
    

    private void UpdateTempItemState(int currentSeconds, TempItemType tempItemType)
    {
        if (currentSeconds == 0)
        {
            _tempItemUI.SetStateTempItem(tempItemType, false);
            return;
        }
        _tempItemUI.SetStateTempItem(tempItemType, true);
        _tempItemUI.RenderDurationTempItem(tempItemType, currentSeconds);
    }

    private void UpdateDefenseState(int currentSecond)
    {
        UpdateTempItemState(currentSecond, TempItemType.Defense);
    }
    
}
