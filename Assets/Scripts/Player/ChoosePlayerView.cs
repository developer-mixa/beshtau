
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayerView : MonoBehaviour
{
    [SerializeField] private List<Sprite> _persons;
    
    [SerializeField] private List<string> _descriptions;
    
    [SerializeField] private List<string> _names;

    [SerializeField] private Text _personNameText;
    [SerializeField] private Text _personNameDescription;
    [SerializeField] private Image _personSpriteRenderer;

    public void RenderPerson(int position)
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == position)
            {
                _personNameText.text = _names[i];
                _personNameDescription.text = _descriptions[i];
                _personSpriteRenderer.sprite = _persons[i];
                break;
            }
        }
    }
    
}
