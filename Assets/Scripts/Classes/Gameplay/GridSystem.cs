using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Assets.Scripts.Classes.Gameplay
{
    public class GridSystem : MonoBehaviour
    {
        public static event Action<Vector3> GridReady;
        public static GridSystem Instance; // Singleton.
        public GameObject GridReferenceGround; // Ground where the grid will take as reference.
        public GameObject GridGround; // Tile the grid will place.
        public int NumOfCellsInHorizontal; // Number of grid squares to be placed on X axis.
        public int NumOfCellsInVertical; // Number of grid squares to be placed on Z axis.
        public float NodeRadius => 0.5f; // Mostly, the _nodeDiameter will be used, but radius will be useful while building the grid
        private Node[,] _grid; // The grid we will store the nodes inside
        public float NodeDiameter => 2 * NodeRadius;
        public Vector3 bottomLeftPoint => new Vector3(0, 0, 0);

        private void Awake()
        {
            CreateSelfInstance();
        }

        /*
         Initial method for GridSystem object. CreateGrid creates a rectangular grid
         by taking the GridGround property as a base. Number of nodes on the grid is
         given by GridWorldSize, both for horizontal and vertical axises.
         */
        public void CreateGrid()
        {
            CreateSelfInstance();
            ClearGridReference();

            _grid = new Node[NumOfCellsInHorizontal, NumOfCellsInVertical]; // Initializing the node array.

            for (var i = 0; i < NumOfCellsInHorizontal; i++) // Grid column count
            {
                for (var j = 0; j < NumOfCellsInVertical; j++) // Grid row count
                {
                    var worldPoint = bottomLeftPoint + new Vector3(NodeRadius, 0, NodeRadius) + new Vector3(i * NodeDiameter, 0, j * NodeDiameter);
                    var newGroundTile = Instantiate(GridGround, worldPoint, Quaternion.identity); // Instantiate the ground sprite at the same position as the node.
                    newGroundTile.transform.SetParent(GridReferenceGround.transform);
                    _grid[i, j] = new Node(false, worldPoint, i, j);
                }
            }
            GridReady?.Invoke(new Vector3(bottomLeftPoint.x + NumOfCellsInHorizontal * NodeDiameter / 2, 0, GridReferenceGround.transform.position.z));
        }

        /*
         NodeFromWorldPosition takes a coordinate in terms of world position, then by taking the left-bottom corner
         of the grid reference ground's world position, it finds out which node's area PWorldPosition falls in. 
         */
        public Node NodeFromWorldPosition(Vector3 pWorldPosition)
        {
            var directionVector = pWorldPosition - bottomLeftPoint; // Point out the location of the given world position relative to the bottom left point.
            var xCoordinate = Mathf.FloorToInt(directionVector.x / NodeDiameter);
            var yCoordinate = Mathf.FloorToInt(directionVector.z / NodeDiameter);
            if (xCoordinate >= 0 && xCoordinate < NumOfCellsInHorizontal)
            {
                if (yCoordinate >= 0 && yCoordinate < NumOfCellsInVertical)
                {
                    return _grid[xCoordinate, yCoordinate];
                }
            }

            return null;
        }

        public void ClearGridReference()
        {
            while (GridReferenceGround.transform.childCount != 0)
            {
                DestroyImmediate(GridReferenceGround.transform.GetChild(0).gameObject);
            }
        }

        public void CreateSelfInstance()
        {
            if (Instance == null) // Singleton
            {
                Instance = this;
            }
        }
    }
}
