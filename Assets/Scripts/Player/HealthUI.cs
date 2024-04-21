
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject _lifesPanel;
    [SerializeField] private Sprite _lostHealthSprite;
    [SerializeField] private Sprite _healthSprite;
    [SerializeField] private AudioClip _increaseClip;
    [SerializeField] private GameObject _heart;
    
    private List<Image> _lifes;
    
    public void RenderHealths(int lifeCount)
    {
        //Can be added dynamically
        _lifes = _lifesPanel.GetComponentsInChildren<Image>().ToList();
        
        for (int i = 0; i < _lifes.Count; i++)
        {
            _lifes[i].sprite = i > lifeCount ? _lostHealthSprite : _healthSprite;
        }  
    }

    public void AddHeart()
    {
        Instantiate(_heart, _lifesPanel.transform);
    }
    
}
