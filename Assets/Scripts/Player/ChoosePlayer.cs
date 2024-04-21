using System;
using UnityEngine;

//Simplest realization, i do not have a lot of time
public class ChoosePlayer : MonoBehaviour
{

    [SerializeField] private int _size;

    private int _currentPosition = 0;


    public event Action<int> OnSetPosition;
    

    public void Left()
    {
        if (_currentPosition - 1 < 0)
        {
            _currentPosition = _size - 1;
        }
        else
        {
            _currentPosition--;
        }
        OnSetPosition?.Invoke(_currentPosition);
    }

    public void Right()
    {
        if (_currentPosition + 1 >= _size)
        {
            _currentPosition = 0;
        }
        else
        {
            _currentPosition++;
        }
        OnSetPosition?.Invoke(_currentPosition);
    }


}
