using Assets.Scripts.Classes.UI;
using System.Collections;
using UnityEngine;

public class WaterDestinationControl : InstallmentControl
{
    private void Awake()
    {
        rotationCoroutineWorking = false;
        isFilledWithWater = false;
        isTemplate = true;
        var childPipe = gameObject.transform.GetChild(0).transform.Find("Pipe");
        childPipe.GetComponent<Renderer>().material.color = Color.white;
    }
}
