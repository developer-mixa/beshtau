
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    [SerializeField] private GameObject _equipmentPanel;
    [SerializeField] private Text _textInfo;
    [SerializeField] private Image _image;
    
    public void Present(string equipmentName, Sprite sprite)
    {
        _equipmentPanel.SetActive(true);
        _textInfo.text = equipmentName;
        _image.sprite = sprite;
    }
    
}
