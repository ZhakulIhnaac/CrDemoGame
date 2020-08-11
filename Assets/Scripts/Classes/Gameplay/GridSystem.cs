using System;
using System.Collections.Generic;
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
        private float NodeRadius => multiplier * 0.5f; // Mostly, the _nodeDiameter will be used, but radius will be useful while building the grid
        private Node[,] _grid; // The grid we will store the nodes inside
        public float multiplier => GridReferenceGround.transform.localScale.z * 10 / NumOfCellsInVertical;
        public float NodeDiameter => 2 * NodeRadius;

        private void Awake()
        {
            if (Instance == null) // Singleton
            {
                Instance = this;
            }
        }

        private void Start()
        {
            CreateGrid();
        }

        /*
         Initial method for GridSystem object. CreateGrid creates a rectangular grid
         by taking the GridGround property as a base. Number of nodes on the grid is
         given by GridWorldSize, both for horizontal and vertical axises.
         */
        public void CreateGrid()
        {
            
            _grid = new Node[NumOfCellsInHorizontal, NumOfCellsInVertical]; // Initializing the node array.
            var bottomLeftPoint = GridReferenceGround.transform.position + new Vector3(-GridReferenceGround.transform.localScale.x * 5, 0, -GridReferenceGround.transform.localScale.z * 5); // transform.position will give the middle point and we will subtract the halves of the height and width to find bottom left point
            //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cube.transform.position = bottomLeftPoint + new Vector3(NodeRadius, 0, NodeRadius);
            for (var i = 0; i < NumOfCellsInHorizontal; i++) // Grid column count
            {
                for (var j = 0; j < NumOfCellsInVertical; j++) // Grid row count
                {
                    var worldPoint = bottomLeftPoint + new Vector3(NodeRadius, 0, NodeRadius) + new Vector3(i * NodeDiameter, 0, j * NodeDiameter);
                    var newGroundTile = Instantiate(GridGround, worldPoint, Quaternion.identity); // Instantiate the ground sprite at the same position as the node.
                    newGroundTile.transform.localScale = new Vector3(NodeDiameter, NodeDiameter, NodeDiameter);
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
            var bottomLeftPoint = GridReferenceGround.transform.position + new Vector3(-GridReferenceGround.transform.localScale.x * 5, 0, -GridReferenceGround.transform.localScale.z * 5); // transform.position will give the middle point and we will subtract the halves of the height and width to find bottom left point
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

        /*
         GetNeighbourNodes takes a node, pCurrentNode, and it checks 8 adjacent possible-node
         positions including the ones in the corners for existence of nodes. If there is a node
         in the checked position, it gets added into the neighbour nodes list. Lastly, this list
         is returned to the method caller.
         */
        //public List<Node> GetNeighbourNodes(Node pCurrentNode)
        //{
        //    var neighbouringNodes = new List<Node>();
        //    var checkEightSides = new List<Vector2>
        //    {
        //        Vector2.up,
        //        Vector2.up + Vector2.right,
        //        Vector2.right,
        //        Vector2.down + Vector2.right,
        //        Vector2.down,
        //        Vector2.down + Vector2.left,
        //        Vector2.left,
        //        Vector2.up + Vector2.left,
        //    };

        //    foreach (var side in checkEightSides)
        //    {
        //        var neighbourInquiry = CheckNeighbourNode(pCurrentNode, side);
        //        if (neighbourInquiry != null)
        //        {
        //            neighbouringNodes.Add(neighbourInquiry);
        //        }
        //    }

        //    return neighbouringNodes;
        //}

        /*
         CheckNeighbourNode checks if pPosition falls into a node's area and returns the node if it exists.
         */
        //Node CheckNeighbourNode(Node pCurrentNode, Vector2 pPosition)
        //{
        //    var checkPosX = pCurrentNode.XPosInGrid + (int)pPosition.x;
        //    var checkPosY = pCurrentNode.YPosInGrid + (int)pPosition.y;

        //    if (checkPosX >= 0 && checkPosX < _gridSizeX)
        //    {
        //        if (checkPosY >= 0 && checkPosY < _gridSizeY)
        //        {
        //            return _grid[checkPosX, checkPosY];
        //        }
        //    }

        //    return null;
        //}

        /*
         ObstructNode changes the status of the given node in terms of being obstructed or not.
         */
        //void ObstructNode(Node node)
        //{
        //    node.IsObstructed = true;
        //}
    }
}
