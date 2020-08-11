using Assets.Scripts.Classes.UI;
using System.Collections;
using UnityEngine;

public class WaterSourceControl : InstallmentControl
{
    private void Awake()
    {
        rotationCoroutineWorking = false;
        isFilledWithWater = true;
        isTemplate = true;
        var childPipe = gameObject.transform.GetChild(0).transform.Find("Depo");
        childPipe.GetComponent<Renderer>().material.color = Color.blue;
    }
}
