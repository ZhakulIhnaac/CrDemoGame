using UnityEngine;

public class WaterSourceControl : InstallmentControl
{
    private void Awake()
    {
        isFilledWithWater = true;
        GetComponent<Renderer>().material.color = Color.blue;
    }

    protected override void EmptyWater()
    {

    }
}
