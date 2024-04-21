using System.Collections.Generic;
using UnityEngine;

public class GetDetailsView : MonoBehaviour
{
    [SerializeField] private List<int> _counts;
    [SerializeField] private List<GameObject> _components;

    public void RenderComponents(int currentCount)
    {
        for (int i = 0; i < _counts.Count; i++)
        {
            if(currentCount >= _counts[i]) _components[i].SetActive(true);
        }
        
    }
}
