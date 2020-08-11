using UnityEngine;

namespace Assets.Scripts.Classes.Gameplay
{
    public class LevelEditorCamera : MonoBehaviour
    {
        private void Awake()
        {
            GridSystem.GridReady += Reposition;
        }

        private void Start()
        {
           
        }

        private void Reposition(Vector3 pPositionTo)
        {
            GetComponent<Camera>().orthographicSize = Mathf.Max(GridSystem.Instance.NodeDiameter * GridSystem.Instance.NumOfCellsInVertical * Camera.main.aspect, GridSystem.Instance.NodeDiameter * GridSystem.Instance.NumOfCellsInHorizontal) + 1f;
            transform.position = pPositionTo + new Vector3(0, 1, 0);
            //if (GridSystem.Instance.NodeDiameter * GridSystem.Instance.NumOfCellsInVertical * Camera.main.aspect > GridSystem.Instance.NodeDiameter * GridSystem.Instance.NumOfCellsInHorizontal)
            //{

            //}
            //else
            //{

            //}
        }
    }
}