using UnityEngine;

namespace Assets.Scripts.Classes.Gameplay
{
    public class LevelCamera : MonoBehaviour
    {
        private void Awake()
        {
            Reposition();
        }

        private void Reposition()
        {
            //float cameraViewAngle;
            //float referenceSide;
            //if (GridSystem.Instance.NodeDiameter * GridSystem.Instance.NumOfCellsInVertical * Camera.main.aspect > GridSystem.Instance.NodeDiameter * GridSystem.Instance.NumOfCellsInHorizontal)
            //{
            //    referenceSide = GridSystem.Instance.NodeDiameter * GridSystem.Instance.NumOfCellsInVertical;
            //    cameraViewAngle = GetComponent<Camera>().fieldOfView;
            //}
            //else
            //{
            //    referenceSide = GridSystem.Instance.NodeDiameter * GridSystem.Instance.NumOfCellsInHorizontal;
            //    float vFOVInRads = GetComponent<Camera>().fieldOfView * Mathf.Deg2Rad;
            //    float hFOVInRads = 2 * Mathf.Atan(Mathf.Tan(vFOVInRads / 2) * Camera.main.aspect);
            //    float hFOV = hFOVInRads * Mathf.Rad2Deg;
            //    cameraViewAngle = hFOV;
            //}

            //var gridReferenceLongSide = referenceSide; // Height of the game area
            //var cameraHeight = (gridReferenceLongSide / 2) / Mathf.Tan((cameraViewAngle/2) * Mathf.PI / 180);
        }
    }
}