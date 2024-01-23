namespace AnotherWorldProject.GridSystem
{
    public class PathNode
    {
        GridPosition gridPosition;
        int gCost, hCost, fCost;

        PathNode prevNode;

        public PathNode(GridPosition gridPosition)
        {
            this.gridPosition = gridPosition;
        }
        public override string ToString()
        {
            return gridPosition.ToString();
        }
        public int GetgCost()
        {
            return gCost;
        }
        public int GethCost()
        {
            return hCost;
        }
        public int GetfCost()
        {
            return fCost;
        }
    }
}

