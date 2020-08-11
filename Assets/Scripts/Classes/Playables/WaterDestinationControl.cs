using UnityEngine;

public class WaterDestinationControl : InstallmentControl
{
    private void Awake()
    {
        isFilledWithWater = false;
        GetComponent<Renderer>().material.color = Color.white;
    }
}
