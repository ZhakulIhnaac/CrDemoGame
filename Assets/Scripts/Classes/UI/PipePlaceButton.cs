using Assets.Scripts.Classes.Gameplay;
using UnityEngine;

namespace Assets.Scripts.Classes.UI
{
    public class PipePlaceButton : MonoBehaviour
    {
        [SerializeField] private GameObject _pipe;

        /*
         AssignPipe is assigning the _pipe to the Pipe variable of
         cursor object.
         */

        public void AssignPipe()
        {
            var newPipe = Instantiate(_pipe, MouseCursor.Instance.transform);

            foreach (Collider collider in newPipe.transform.GetChild(0).GetChild(0).gameObject.GetComponents<Collider>())
            {
                collider.enabled = false;
            }

            newPipe.transform.SetParent(LevelEditorController.Instance.PlayableObjectsGroup.transform);
            newPipe.transform.localScale = Vector3.one * GridSystem.Instance.multiplier;
            MouseCursor.Instance.PlaceablePipe = newPipe;
        }
    }
}
