using System;
using System.Collections.Generic;
using UnityEngine;

public class GetDetailsController : MonoBehaviour
{
    private GetDetailsModel _getDetailsModel;
    private GetDetailsView _getDetailsView;

    private void Awake()
    {
        _getDetailsModel = GetComponent<GetDetailsModel>();
        _getDetailsView = GetComponent<GetDetailsView>();
    }

    private void OnEnable()
    {
        _getDetailsModel.OnTakeComponent += TakeComponent;
    }

    private void OnDisable()
    {
        _getDetailsModel.OnTakeComponent -= TakeComponent;
    }

    private void TakeComponent(int currentCount) =>
        _getDetailsView.RenderComponents(currentCount);
    
}
