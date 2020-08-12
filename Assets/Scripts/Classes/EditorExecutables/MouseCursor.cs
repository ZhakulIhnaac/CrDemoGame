using Assets.Scripts.Classes.Gameplay;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Classes.UI
{
    public class MouseCursor : MonoBehaviour
    {
        public static MouseCursor Instance;
        public GameObject PlaceablePipe;
        public GameObject SelectedPipe;
        public GameObject TileTheCursorIsOn;
        [SerializeField] private LayerMask _playableLayerMask;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private LayerMask _virtualLayerMask;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Update()
        {
            if (PlaceablePipe != null)
            {
                RaycastHit hit;
                var mouseRayToSend = Camera.main.ScreenPointToRay(Input.mousePosition);
                var didGroundHit = Physics.Raycast(mouseRayToSend.origin, mouseRayToSend.direction, out hit, Mathf.Infinity, _groundLayerMask);
                if (hit.collider != null)
                {
                    TileTheCursorIsOn = hit.collider.gameObject;
                    PlaceablePipe.transform.position = TileTheCursorIsOn.transform.position;
                }
            }

            if (Input.anyKey)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    if (PlaceablePipe != null)
                    {
                        if (GridSystem.Instance.NodeFromWorldPosition(TileTheCursorIsOn.transform.position).isObstructed)
                        {
                            Debug.Log("Cannot Place");
                        }
                        else
                        {
                            var newPipe = Instantiate(PlaceablePipe, PlaceablePipe.transform.position, Quaternion.identity);

                            foreach (Collider collider in newPipe.transform.GetChild(0).GetChild(0).gameObject.GetComponents<Collider>())
                            {
                                collider.enabled = true;
                            }

                            newPipe.transform.SetParent(LevelEditorController.Instance.PlayableObjectsGroup.transform);
                            newPipe.GetComponent<VirtualsControl>().isTemplate = false;

                            if (!Input.GetKey(KeyCode.LeftShift))
                            {
                                PlaceablePipe.GetComponent<VirtualsControl>().isTemplate = false;
                                Destroy(PlaceablePipe);
                            }

                            GridSystem.Instance.NodeFromWorldPosition(TileTheCursorIsOn.transform.position).isObstructed = true;
                        }
                    }
                }

                else if (Input.GetMouseButtonDown(1))
                {
                    if (PlaceablePipe != null)
                    {
                        Destroy(PlaceablePipe);
                    }
                    else
                    {
                        RaycastHit hit;
                        var mouseRayToSend = Camera.main.ScreenPointToRay(Input.mousePosition);
                        var didPlayableHit = Physics.Raycast(mouseRayToSend.origin, mouseRayToSend.direction, out hit, Mathf.Infinity, _virtualLayerMask);
                        Debug.Log(hit.collider);
                        if (hit.collider != null)
                        {
                            Destroy(hit.collider.gameObject);
                            GridSystem.Instance.NodeFromWorldPosition(hit.collider.gameObject.transform.position).isObstructed = false;
                        }
                    }
                }
            }

        }

    }
}
