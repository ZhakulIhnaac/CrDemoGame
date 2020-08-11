using Assets.Scripts.Classes.Gameplay;
using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Classes.UI
{
    public class MouseCursor : MonoBehaviour, ICursor
    {
        public static MouseCursor Instance;
        public GameObject PlaceablePipe;
        public GameObject SelectedPipe;
        public GameObject TileTheCursorIsOn;
        [SerializeField] private LayerMask _playableLayerMask;
        [SerializeField] private LayerMask _groundLayerMask;

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
                            PlaceablePipe.GetComponent<InstallmentControl>().isTemplate = false;
                            PlaceablePipe = null;
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
                        var didPlayableHit = Physics.Raycast(mouseRayToSend.origin, mouseRayToSend.direction, out hit, Mathf.Infinity, _playableLayerMask);
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
