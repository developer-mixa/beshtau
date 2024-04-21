using System;
using UnityEngine;

public class AssembleDetailEffect : MonoBehaviour
{
    [SerializeField] private GameObject _effectTextStay;
    [SerializeField] private GameObject _effectTextShow;
    [SerializeField] private GameObject _effectRepairing;
    [SerializeField] private Sprite repairSprite;
    [SerializeField] private AudioClip _detailClip;
    
    private AudioSource _audioSource;
    

    private void Awake()
    {
        _audioSource = FindObjectOfType<AudioSource>();
    }

    public void ShowEffect()
    {
        _effectTextStay.SetActive(false);
        _effectTextShow.SetActive(true);
        _effectRepairing.SetActive(true);
        _audioSource.PlayOneShot(_detailClip);
    }

    public void Repair()
    {
        _effectRepairing.SetActive(false);
        _effectTextShow.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = repairSprite;
    }
    
    
}
