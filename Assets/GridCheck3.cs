
using UnityEngine;

public class GridCheck3 : MonoBehaviour
{
     int rows = 3; 
     int columns = 3; 
     float cellSize = 1f; 

    public GameObject GridsPrefab; 
    public GameObject redGrids; 

    GameObject[,] grid2dArray;

    void Start()
    {
        Grid();
        DeleteAndSpawn(); 
    }

    void Grid()   //created 3*3 grid 
    {
        grid2dArray = new GameObject[rows, columns]; 

        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                Vector2 cellPosition = new Vector2(x * cellSize, y * cellSize);

                GameObject gridCell = Instantiate(GridsPrefab, cellPosition, Quaternion.identity);
                gridCell.transform.SetParent(transform);
                gridCell.name = "Grid";

                grid2dArray[x, y] = gridCell;
            }
        }
    }

    void DeleteAndSpawn()   //delete 2 cell from the grid to 
    {
       
        int randomRow = Random.Range(0, rows);
        int randomColumn = Random.Range(0, columns);

      
        Vector2Int[] directions = new Vector2Int[] //2d Plane thst why Vector2Int & giving dir to delete the cell
        {
            new Vector2Int(1, 0), // Right
            new Vector2Int(0, 1), // Down
            new Vector2Int(-1, 0), // Left
            new Vector2Int(0, -1) // Up
        };

       
        directions = ChangeDirections(directions); //
        DestroyCell(randomRow, randomColumn); //


        Vector2Int firstDeletedCell = new Vector2Int(randomRow, randomColumn);
        Vector2Int secondDeletedCell = new Vector2Int(-1, -1);

  
        foreach (var direction in directions)
        {
            int adjacentRow = randomRow + direction.x;
            int adjacentColumn = randomColumn + direction.y;

            if (IsValidCell(adjacentRow, adjacentColumn))
            {
                DestroyCell(adjacentRow, adjacentColumn);
                secondDeletedCell = new Vector2Int(adjacentRow, adjacentColumn);
                break; 
            }
        }

       
        RedGrid(firstDeletedCell.x, firstDeletedCell.y); //spawn red
        RedGrid(secondDeletedCell.x, secondDeletedCell.y); //spawn red
    }

    void DestroyCell(int row, int column)
    {
        if (grid2dArray[row, column] != null)
        {
            Destroy(grid2dArray[row, column]);
            grid2dArray[row, column] = null;
            
        }
    }

  

    bool IsValidCell(int row, int column)
    {
        return row >= 0 && row < rows && column >= 0 && column < columns && grid2dArray[row, column] != null;
    }


    Vector2Int[] ChangeDirections(Vector2Int[] directions) 
    {
        for (int i = 0; i < directions.Length; i++)
        {
            int RandomDir = Random.Range(0, directions.Length); 
            Vector2Int Dir = directions[RandomDir];//4 dir choose only one random 
            directions[RandomDir] = directions[i];
            directions[i] = Dir;
        }
        return directions;
    }

    void RedGrid(int row, int column)
    {
        if (row >= 0 && column >= 0) 
        {
            Vector2 cellPosition = new Vector2(row * cellSize, column * cellSize);
           GameObject red =  Instantiate(redGrids, cellPosition, Quaternion.identity);
            red.gameObject.transform.SetParent(transform);
            red.gameObject.name = "red";
           
        }
    }
}
