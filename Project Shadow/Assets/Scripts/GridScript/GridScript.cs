using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    [SerializeField] Vector3 gridOrigin;
    [SerializeField] GameObject[] prefabs = new GameObject[] { };

    public Grid grid;
    public int levelIndex = 1;
    int[,] levelDesign;
    public Vector3 playerPosition;
    public Vector3 playerGridPosition;
    //public bool canFoward = false;
    //public bool canBack = false;
    //public bool canLeft = false;
    //public bool canRight = false;
    public GameObject spawnObjectPrefab;

    private void Start()
    {

        switch (levelIndex)
        {
            case 1:
                levelDesign = new int[,] { //top left is origin
                    {2,2,2,2,0,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,0,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,0,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,0,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,0,2,2,2,2,2,2,2,2,2,2},
                    {2,0,0,0,0,2,2,2,2,2,2,2,2,2,2},
                    {2,0,2,0,0,2,2,2,2,2,2,2,2,2,2},
                    {2,0,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,0,0,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,0,0,0,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,0,2,2,2,2,2,2,2,2,2,2},
                    {2,0,2,0,0,2,2,2,2,2,2,2,2,2,2},
                    {2,0,0,0,2,2,2,2,2,2,2,2,2,2,2},
                    {2,0,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,1,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}

                };
                break;

            case 2:
                levelDesign = new int[,] {
                    {2,2,2,0,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,0,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,0,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,0,0,0,2,2,2,2,2,2,2,2,2,2},
                    {2,0,0,0,0,0,2,2,2,2,2,2,2,2,2},
                    {2,0,2,0,2,0,2,2,2,2,2,2,2,2,2},
                    {2,0,0,0,0,0,2,2,2,2,2,2,2,2,2},
                    {2,0,0,0,0,0,2,2,2,2,2,2,2,2,2},
                    {2,0,0,0,0,0,2,2,2,2,2,2,2,2,2},
                    {2,2,2,0,2,2,2,2,2,2,2,2,2,2,2},
                    {2,0,0,0,0,2,2,2,2,2,2,2,2,2,2},  
                    {2,0,2,2,0,0,2,2,2,2,2,2,2,2,2},
                    {2,0,0,2,2,0,2,2,2,2,2,2,2,2,2},
                    {2,0,0,2,2,0,0,0,2,2,2,2,2,2,2},
                    {2,0,2,2,2,0,2,0,2,2,2,2,2,2,2},
                    {2,0,0,0,0,0,2,0,2,2,2,2,2,2,2},
                    {2,0,2,2,2,2,2,0,2,2,2,2,2,2,2},
                    {2,2,2,0,0,0,0,0,2,2,2,2,2,2,2},
                    {2,2,2,1,2,2,0,2,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}


                };
                break;
            case 3:
                levelDesign = new int[,] {
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,0,0,0,0,0,0,0,2,2,2,2,2,2},
                    {2,0,0,0,0,0,0,0,0,2,2,2,2,2,2},
                    {2,0,0,0,0,0,0,0,0,2,2,2,2,2,2},
                    {2,2,2,0,0,0,0,0,0,2,2,2,2,2,2},
                    {2,2,2,0,0,0,0,0,0,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,0,0,0,0,0,0,0,0,2,2,2,2,2},
                    {2,0,0,0,0,0,0,0,0,0,2,2,2,2,2},
                    {2,0,0,0,0,0,0,0,0,0,2,2,2,2,2},
                    {2,0,0,0,0,0,0,0,0,0,2,2,2,2,2},
                    {2,2,0,0,0,0,0,0,0,0,2,2,2,2,2},
                    {2,2,0,0,0,0,0,0,0,0,2,2,2,2,2},
                    {2,2,0,0,0,0,0,0,0,2,2,2,2,2,2},
                    {2,2,0,0,0,0,0,0,0,2,2,2,2,2,2},
                    {2,2,0,0,0,0,0,0,0,2,2,2,2,2,2},
                    {2,2,2,1,0,0,0,0,0,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}


                };
                break;
            case 4:
                levelDesign = new int[,] {
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,0,2,0,2,2,2,0,2,0,2,2,2},
                    {2,2,2,0,2,0,0,0,0,0,2,0,2,2,2},
                    {2,2,0,0,0,0,2,0,2,0,0,0,0,2,2},
                    {2,2,2,0,2,0,2,0,2,0,2,0,2,2,2},
                    {2,2,2,0,0,0,0,0,0,0,0,0,2,2,2},
                    {2,2,2,0,0,0,2,0,2,0,0,0,2,2,2},
                    {2,2,2,0,2,0,2,0,2,0,2,0,2,2,2},
                    {2,2,2,0,0,0,0,0,0,0,0,0,2,2,2},
                    {2,2,2,0,0,0,2,0,2,0,0,0,2,2,2},
                    {2,2,2,0,2,0,2,0,2,0,2,0,2,2,2},
                    {2,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                    {2,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                    {2,2,2,2,2,2,2,0,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,0,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,1,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                    {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},


                };
                break;
        }


        grid = new Grid(levelDesign.GetLength(1), levelDesign.GetLength(0), gridOrigin);

        for (int i = 0; i < levelDesign.GetLength(1); i++)
        {
            for (int j = 0; j < levelDesign.GetLength(0); j++)
            {
                grid.gridArray[i, j].type = levelDesign[j, i];
                if (grid.gridArray[i,j].type == 1)
                {
                    playerPosition = grid.gridArray[i, j].position;
                    playerGridPosition = new Vector3(i, j, 0);
                   
                }
                SpawnOnGrid(grid.gridArray[i, j].position, levelDesign[j, i]);
            }
        }
    }


    public void MoveGrid(Vector3 pos, Vector3 dir) {  
        
        int currentType = grid.gridArray[(int)pos.x, (int)pos.y].type;
        //Debug.Log(pos);
        grid.gridArray[(int)pos.x, (int)pos.y].type = 0;
        pos += dir;
        grid.gridArray[(int)pos.x, (int)pos.y].type = currentType;

        if (currentType == 1)
        {
            playerGridPosition += dir;
            //Debug.Log(playerGridPosition);
            playerPosition = grid.gridArray[(int)pos.x, (int)pos.y].position;
        }
        else if (currentType == 3)
        {
            //enemy shit here
        }
    }


    public void SpawnOnGrid(Vector3 position, int type)//spawn player and wall here based on location
    {
        if (type == 0)
        {
            Instantiate(prefabs[type], position-new Vector3(0,0.5f,0), Quaternion.Euler(90, 0, 0));
        }
        else {
            Instantiate(prefabs[type], position, Quaternion.identity);
        }
        
        //player and wall spawn 

    }
}

public class Grid
{
    private int width;
    private int height;
    public GridPoint[,] gridArray;

    public Grid(int width, int height, Vector3 origin)
    {
        this.width = width;
        this.height = height;

        gridArray = new GridPoint[width, height];
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {

                gridArray[x, y] = new GridPoint(new Vector3(origin.x + x, origin.y, origin.z - y), 0);

            }
        }
    }
    public class GridPoint
    {
        public Vector3 position;
        public int type;
        public GridPoint(Vector3 position, int type)//type 0 is empty, type 1 is player, type 2 is wall, type 3 is enemy
        {
            this.position = position;
            this.type = type;
        }
    }

}
