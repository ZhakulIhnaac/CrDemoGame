using UnityEngine;

public class WaterSourceControl : InstallmentControl
{
    private void Awake()
    {
        pipeRenderer = GetComponent<Renderer>();
        isFilledWithWater = true;
        pipeRenderer.material.color = Color.blue;
    }

    protected override void EmptyWater()
    {

    }
}
