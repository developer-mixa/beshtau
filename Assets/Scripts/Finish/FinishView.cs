using System;
using UnityEngine;
using UnityEngine.UI;

public class FinishView : MonoBehaviour
{
    [SerializeField] private GameObject _finishButton;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private Text _textScore;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = FindObjectOfType<AudioSource>();
    }

    public void RenderTap(bool canTap)
    {
        _finishButton.SetActive(canTap);
    }

    public void Win(int currentScore)
    {
        _audioSource.PlayOneShot(_audioClip);
        _finishButton.SetActive(false);
        _winPanel.SetActive(true);
        _textScore.text = $"Твой счет: {currentScore}";
    }
    
}
