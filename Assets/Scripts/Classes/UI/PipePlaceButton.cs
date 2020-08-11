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
            newPipe.transform.SetParent(LevelEditorController.Instance.PlayableObjectsGroup.transform);
            newPipe.transform.localScale = Vector3.one * GridSystem.Instance.multiplier;
            MouseCursor.Instance.PlaceablePipe = newPipe;
        }
    }
}
