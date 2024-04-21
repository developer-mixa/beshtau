
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AssembleDetailView : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private GameObject _tapper;
    private AssembleDetailEffect _assembleDetailEffect;

    public event Action<string> OnStartRepaired;
    public event Action<string> OnEndRepaired;
    
    public void RenderTap(bool canTap, AssembleDetailEffect assembleDetailEffect)
    {
        _tapper.SetActive(canTap);
        _assembleDetailEffect = assembleDetailEffect;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_assembleDetailEffect == null)
        {
            Debug.Log("_assembleDetailEffect == null");
            return;
        }
        _assembleDetailEffect.ShowEffect();
        StartCoroutine(Repair(_assembleDetailEffect));
        OnStartRepaired?.Invoke(_assembleDetailEffect.gameObject.name);
    }
    
    private IEnumerator Repair(AssembleDetailEffect assembleDetailEffect)
    {
        yield return new WaitForSeconds(3);
        assembleDetailEffect.Repair();
        OnEndRepaired?.Invoke(assembleDetailEffect.gameObject.name);
    }
    
}
