using System;
using UnityEngine;

public class WaterDestinationControl : InstallmentControl
{
    public static event Action Victory;
    private void Awake()
    {
        isFilledWithWater = false;
        GetComponent<Renderer>().material.color = Color.white;
    }

    private void GameOver()
    {
        isFilledWithWater = true;
        GetComponent<Renderer>().material.color = Color.blue;
        Victory?.Invoke();
    }
}
