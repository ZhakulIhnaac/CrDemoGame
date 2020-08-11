using Assets.Scripts.Classes.UI;
using System.Collections;
using UnityEngine;

public class PipeControl : InstallmentControl
{
    private void Awake()
    {
        rotationCoroutineWorking = false;
        isFilledWithWater = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<InstallmentControl>() != null)
        {
            if (other.gameObject.GetComponent<InstallmentControl>().isFilledWithWater)
            {
                isFilledWithWater = true;
                FillWithWater();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isFilledWithWater = false;
        EmptyWater();
    }

    private void FillWithWater()
    {
        var childPipe = gameObject.transform.GetChild(0).transform.Find("Pipe");
        childPipe.GetComponent<Renderer>().material.color = Color.blue;
    }

    private void EmptyWater()
    {
        var childPipe = gameObject.transform.GetChild(0).transform.Find("Pipe");
        childPipe.GetComponent<Renderer>().material.color = Color.white;
    }
}
