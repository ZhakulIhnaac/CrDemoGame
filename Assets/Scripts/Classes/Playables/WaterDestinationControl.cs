using System;
using UnityEngine;

public class WaterDestinationControl : InstallmentControl
{
    public static event Action Victory;

    private void Awake()
    {
        pipeRenderer = GetComponent<Renderer>();
        isFilledWithWater = false;
        pipeRenderer.material.color = Color.white;
    }

    protected override void FillWithWater()
    {
        isFilledWithWater = true;
        pipeRenderer.material.color = Color.blue;
        Victory?.Invoke();
    }

}
