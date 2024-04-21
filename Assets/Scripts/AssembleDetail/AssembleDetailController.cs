using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class AssembleDetailController : MonoBehaviour
{
    [SerializeField] private AssembleDetailView _assembleDetailView;

    private AssembleDetailEffect _assembleDetailEffect;
    private GetDetailsModel _getDetailsModel;
    private bool _canTap;
    private bool _repaired;

    private void Awake()
    {
        _assembleDetailEffect = GetComponent<AssembleDetailEffect>();
        _getDetailsModel = FindObjectOfType<GetDetailsModel>();
    }

    private void OnEnable()
    {
        _assembleDetailView.OnStartRepaired += Tap;
        _assembleDetailView.OnEndRepaired += IncrementGotComponents;
    }

    private void OnDisable()
    {
        _assembleDetailView.OnStartRepaired -= Tap;
        _assembleDetailView.OnEndRepaired -= IncrementGotComponents;
    }

    private void Tap(string objectName)
    {
        if(gameObject.name != objectName) return;
        
        _repaired = true;
        _assembleDetailView.RenderTap(false, null);
    }

    private void IncrementGotComponents(string objectName)
    {
        if(gameObject.name != objectName) return;
        
        _getDetailsModel.TakeDetail();
    }
    
    
    private void FixedUpdate()
    {
        if(_repaired) return;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);

        bool playerNotNull = hit.collider.gameObject.GetComponent<Player>() != null;
        if (_canTap != playerNotNull)
        {
            _canTap = playerNotNull;
            _assembleDetailView.RenderTap(_canTap, _canTap ? _assembleDetailEffect : null);
        }
    }
    
}
