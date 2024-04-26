using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CodingGame : MonoBehaviour
{
    public GameObject walkable;
    public GameObject nonWalkable;
    public GameObject player;
    public int columns = 5;
    public int rows = 5;
    public Transform goal;
    public Transform start;
    private int counter = 0;
    private string ObstacleList = "WWWWWWWWWWWWWWNWNWWN";
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0;i<rows;i++)
        {
            for(int j = 0; j<columns;j++)
            {
                if(ObstacleList[counter]=='W')
                {
                    GameObject go = Instantiate(walkable, new Vector3(i, 0, j),Quaternion.identity);
                    go.transform.parent = this.transform;
                    counter++;
                }
                else if(ObstacleList[counter] == 'N')
                {
                    GameObject go = Instantiate(nonWalkable, new Vector3(i, 0, j), Quaternion.identity);
                    go.transform.parent = this.transform;
                    counter++;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
