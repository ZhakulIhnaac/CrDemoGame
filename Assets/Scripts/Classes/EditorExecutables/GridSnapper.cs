using Assets.Scripts.Classes.Gameplay;
using UnityEngine;

namespace Assets.Scripts.Classes.UI
{
    [ExecuteInEditMode]
    public class GridSnapper : MonoBehaviour
    {
        private void Update()
        {
            if (GridSystem.Instance != null)
            {
                gameObject.transform.position = new Vector3(Mathf.Floor(gameObject.transform.position.x) + GridSystem.Instance.NodeRadius, 0, Mathf.Floor(gameObject.transform.position.z) + GridSystem.Instance.NodeRadius);
            }
        }
    }
}
