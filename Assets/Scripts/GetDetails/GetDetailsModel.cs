
using System;
using UnityEngine;
using Random = System.Random;

public class GetDetailsModel : MonoBehaviour
{
    [SerializeField] private int _allComponentsCount;
    private int _takingComponentsCount;

    public int AllComponentsCount => _allComponentsCount;
    public int CurrentComponentsCount => _takingComponentsCount;

    public event Action<int> OnTakeComponent; 

    public void TakeDetail()
    {
        var random = new Random();
        _takingComponentsCount += random.Next(minValue:1, maxValue:3);
        OnTakeComponent?.Invoke(_takingComponentsCount);
    }

}
