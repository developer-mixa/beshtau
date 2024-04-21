
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TempItemUI : MonoBehaviour
{
    [SerializeField] private List<TempItem> _tempItems;
    [SerializeField] private Text _scoreText;
    [SerializeField] private AudioClip _scoreClip;
    [SerializeField] private AudioClip _bonusClip;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = FindObjectOfType<AudioSource>();
    }

    public void SetStateTempItem(TempItemType tempItemType, bool isActive)
    {
        FindTempItem(tempItemType)?.SetActive(isActive);
    }

    private GameObject FindTempItem(TempItemType tempItemType)
    {
        var tempObj = _tempItems.Find(o => o.TempItemType == tempItemType);
        return tempObj == null ? null : tempObj.gameObject;
    }
    
    public void RenderDurationTempItem(TempItemType tempItemType, int seconds)
    {
        //If i don't fix this, So I didn't make it in time
        if(seconds == 30) _audioSource.PlayOneShot(_bonusClip);
        
        FindTempItem(tempItemType).GetComponentInChildren<Text>().text = seconds.ToString();
    }

    public void RenderCountScores(int scores)
    {
        _scoreText.text = scores.ToString();
        _audioSource.PlayOneShot(_scoreClip);
        
    }
    
}
