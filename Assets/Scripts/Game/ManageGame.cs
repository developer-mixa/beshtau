using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _rulesScreen;
    [SerializeField] private GameObject _chooseScreen;
    [SerializeField] private GameObject _chooseMap;
    
    public void StartGame()
    {
        ActivateOnly(_rulesScreen);
    }

    public void ContinueGame()
    {
        ActivateOnly(_chooseScreen);
    }

    public void ChooseMap()
    {
        ActivateOnly(_chooseMap);
    }

    public void StartPlay(int level)
    {
        SceneManager.LoadScene(level);
    }

    private void ActivateOnly(GameObject go)
    {
        GameObject[] objects = new[]
        {
            _startScreen,
            _rulesScreen,
            _chooseScreen,
            _chooseMap
        };

        foreach (var obj in objects)
        {
            if(go.name == obj.name) obj.SetActive(true);
            else
            {
                obj.SetActive(false);
            }
        }
        
    }
    
}
