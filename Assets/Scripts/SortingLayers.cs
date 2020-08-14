using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayers : MonoBehaviour
{
    #region Variables

    [SerializeField] private int soringOrderBase = 5000;
    [SerializeField] private int offset = 0;
    [SerializeField] private bool runOnlyOnce = false;

    private Renderer myRenderer;
    private Transform _transformPosition;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }
    private void Start()
    {
        _transformPosition = transform;
    }
    private void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(soringOrderBase - _transformPosition.position.y - offset);
        if (runOnlyOnce)
        {
            Destroy(this);
        }
    }

    #endregion
}
