using System;
using UnityEngine;

public class PipeControl : InstallmentControl
{
    public static event Action IJustRotated;
    public 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<InstallmentControl>() != null)
        {
            if (other.gameObject.GetComponent<InstallmentControl>().isFilledWithWater)
            {
                FillWithWater();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EmptyWater();
    }

    private void FillWithWater()
    {
        isFilledWithWater = true;
        GetComponent<Renderer>().material.color = Color.blue;
    }

    private void EmptyWater()
    {
        isFilledWithWater = false;
        GetComponent<Renderer>().material.color = Color.white;
    }
}
