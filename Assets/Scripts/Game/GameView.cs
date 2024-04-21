
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;

    public void RenderLose()
    {
        _losePanel.SetActive(true);
    }
    
}
