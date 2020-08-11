using System.Collections.Generic;
using UnityEngine;

public class InstallmentControl : MonoBehaviour
{
    public List<GameObject> waterSupplierList = new List<GameObject>();
    public List<GameObject> collidingPipesList = new List<GameObject>();
    public bool isFilledWithWater;
    public Renderer pipeRenderer;

    private void Awake()
    {
        pipeRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        collidingPipesList.Add(collider.gameObject);

        if (collider.GetComponent<InstallmentControl>().isFilledWithWater)
        {
            waterSupplierList.Add(collider.gameObject);

            if (!isFilledWithWater)
            {
                FillWithWater();
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        collidingPipesList.Remove(collider.gameObject);

        if (waterSupplierList.Contains(collider.gameObject))
        {
            waterSupplierList.Remove(collider.gameObject);

            if (waterSupplierList.Count == 0)
            {
                EmptyWater();
            }
        }
    }

    private void FillWithWater()
    {
        isFilledWithWater = true;
        pipeRenderer.material.color = Color.blue;

        foreach (var collidingPipe in collidingPipesList)
        {
            var collidingPipeScript = collidingPipe.GetComponent<InstallmentControl>();
            
            if (!collidingPipeScript.waterSupplierList.Contains(gameObject) && !waterSupplierList.Contains(collidingPipe))
            {
                collidingPipeScript.waterSupplierList.Add(gameObject);
            }

            if (!collidingPipeScript.isFilledWithWater)
            {
                collidingPipeScript.FillWithWater();
            }
        }
    }

    protected virtual void EmptyWater()
    {
        isFilledWithWater = false;
        pipeRenderer.material.color = Color.white;

        foreach (var collidingPipe in collidingPipesList)
        {
            var collidingPipeScript = collidingPipe.GetComponent<InstallmentControl>();

            if (collidingPipeScript.waterSupplierList.Contains(gameObject))
            {
                collidingPipeScript.waterSupplierList.Remove(gameObject);

                if (collidingPipeScript.waterSupplierList.Count == 0)
                {
                    collidingPipeScript.EmptyWater();
                }
            }
        }
    }
}
