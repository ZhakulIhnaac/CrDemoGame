using Assets.Scripts.Classes.Gameplay;
using UnityEngine;

namespace Assets.Scripts.Classes.UI
{
    [ExecuteInEditMode]
    public class CameraAligner : MonoBehaviour
    {
        float cameraViewAngle;
        float yDistance;
        float xDistance;
        float zDistance;
        float xzPlaneDistance;
        float diagonalDistance;
        float groundAreaHalfDiagonalDistance;

        private void Update()
        {
            if (GridSystem.Instance != null)
            {
                var gridInstance = GridSystem.Instance;

                groundAreaHalfDiagonalDistance = Mathf.Sqrt(Mathf.Pow(gridInstance.NumOfCellsInHorizontal * gridInstance.NodeDiameter, 2) + Mathf.Pow(gridInstance.NumOfCellsInVertical * gridInstance.NodeDiameter, 2)) / 2;

                cameraViewAngle = GetComponent<Camera>().fieldOfView;
                float verticalFOVInRads = GetComponent<Camera>().fieldOfView * Mathf.Deg2Rad;
                float horizontalFOVInRads = 2 * Mathf.Atan(Mathf.Tan(verticalFOVInRads / 2) * Camera.main.aspect);
                float horizontalFOV = horizontalFOVInRads * Mathf.Rad2Deg;

                diagonalDistance = groundAreaHalfDiagonalDistance / Mathf.Tan(horizontalFOV * Mathf.Deg2Rad);
                yDistance = diagonalDistance * Mathf.Sin(30 * Mathf.Deg2Rad);
                xzPlaneDistance = diagonalDistance * Mathf.Cos(30 * Mathf.Deg2Rad);
                xDistance = xzPlaneDistance * Mathf.Cos(30 * Mathf.Deg2Rad);
                zDistance = xzPlaneDistance * Mathf.Sin(30 * Mathf.Deg2Rad);

                transform.position = new Vector3((gridInstance.NodeDiameter * gridInstance.NumOfCellsInHorizontal / 2) + xDistance, yDistance, (gridInstance.NodeDiameter * gridInstance.NumOfCellsInVertical / 2) - zDistance);
            }
        }
    }
}
