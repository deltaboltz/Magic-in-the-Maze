using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazegenerator : MonoBehaviour
{
    public int width = 30; //maze dimensions
    public int length = 30;
    public GameObject bushobject;
    public GameObject floor;
    private Dictionary<Vector3, GameObject> CellWallsTop = new Dictionary<Vector3, GameObject>();
    private Dictionary<Vector3, GameObject> CellWallsLeft = new Dictionary<Vector3, GameObject>();
    private List<Vector3> RunSet = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < width; x++)
        {
            for(int z = 0; z <length;z++)
            {
                if (z != length - 1)
                {
                    GameObject UpWall = Instantiate(bushobject,transform);
                    UpWall.transform.localScale = new Vector3(5, 5, 1);
                    UpWall.transform.position = new Vector3(x * 5, 2.5f, z * 5 + 2.5f);
                    CellWallsTop.Add(new Vector3(x, 0, z), UpWall);
                }
                if (x != 0)
                {
                    GameObject SideWall = Instantiate(bushobject,transform);
                    SideWall.transform.localScale = new Vector3(1, 5, 5);
                    SideWall.transform.position = new Vector3(x * 5 - 2.5f, 2.5f, z * 5);
                    CellWallsLeft.Add(new Vector3(x, 0, z), SideWall);
                }
            }
        }

        GameObject floorinstance = Instantiate(floor, transform);
        floorinstance.transform.localScale = new Vector3(5*width, 1, 5 * length);
        floorinstance.transform.position = new Vector3(5*(width/2)-2.5f, -0.5f, 5 * (length / 2)-2.5f);
        floor.name = "floor";

        GameObject LeftWall = Instantiate(bushobject, transform);
        LeftWall.transform.localScale = new Vector3(1, 5, 5*length);
        LeftWall.transform.position = new Vector3(-2.5f, 2.5f, 5*(length/2)-2.5f);
        LeftWall.name = "left wall";

        GameObject RightWall = Instantiate(bushobject, transform);
        RightWall.transform.localScale = new Vector3(1, 5, 5 * length);
        RightWall.transform.position = new Vector3(5*width-2.5f, 2.5f, 5 * (length / 2)-2.5f);
        RightWall.name = "right wall";

        GameObject BottomWall = Instantiate(bushobject, transform);
        BottomWall.transform.localScale = new Vector3(5*width, 5, 1);
        BottomWall.transform.position = new Vector3(5*(width/2)-2.5f, 2.5f, -2.5f);
        BottomWall.name = "bottom wall";

        GameObject TopWall = Instantiate(bushobject, transform);
        TopWall.transform.localScale = new Vector3(5 * width, 5, 1);
        TopWall.transform.position = new Vector3(5 * (width / 2)-2.5f, 2.5f, 5*length-2.5f);
        TopWall.name = "top wall";

        for (int x=0;x<width;x++)
        {
            for(int z=0;z<length;z++)
            {
                if(x==0)
                {
                    if(z!=length-1)
                    {
                        Destroy(CellWallsTop[new Vector3(x, 0, z)]);
                    }
                }
                else
                {
                    float chance = Random.value;
                    RunSet.Add(new Vector3(x, 0, z));
                    if (chance<0.5f && z!=length-1)
                    {
                        Destroy(CellWallsTop[new Vector3(x, 0, z)]);
                    }
                    else
                    {
                        if(RunSet.Count > 1)
                        {
                            int index = Random.Range(0, RunSet.Count);
                            Destroy(CellWallsLeft[RunSet[index]]);
                            RunSet.Clear();
                        }
                        else
                        {
                            Destroy(CellWallsLeft[new Vector3(x,0,z)]);
                            RunSet.Clear();
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
