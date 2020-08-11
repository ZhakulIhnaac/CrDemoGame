using Assets.Scripts.Classes.UI;
using System.Collections;
using UnityEngine;

public class InstallmentControl : MonoBehaviour
{
    public float rotationSpeed;
    protected bool rotationCoroutineWorking;
    public bool isTemplate;
    public bool isFilledWithWater;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && MouseCursor.Instance.PlaceablePipe == null)
        {
            if (!rotationCoroutineWorking && !isTemplate)
            {
                StartCoroutine(RotatePipe());
            }
        }
    }

    private IEnumerator RotatePipe()
    {
        rotationCoroutineWorking = true;
        var targetRotation = transform.rotation * Quaternion.AngleAxis(90, Vector3.up);
        while (Quaternion.Angle(targetRotation, transform.rotation) > 2)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
        transform.rotation = targetRotation;
        rotationCoroutineWorking = false;
    }
}
