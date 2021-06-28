using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Vector3 rotationPoint;
    public bool alowRotate=true;
    private float previousTime;
    private float fallTime = 0.5f;
    public static int height = 30;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];
    private bool spawnCondition = true;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0); 
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)&&alowRotate)
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if (!ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }

        if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            previousTime = Time.time;
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckLine();
                this.enabled = false;
                if (spawnCondition==true) FindObjectOfType<Spawn>().NewTetromino();
                else if (spawnCondition == false) return;
            }
        }
    }

    void CheckLine()
    {
        for(int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLine(int i)
    {
        for(int j = 0; j<width; j++)
        {
            if (grid[j, i] == null)
            {
                return false;
            }
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for(int j=0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        for(int y = i; y < height; y++)
        {
            for(int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                    Score_txt.scoreValue += 10;
                }
            }
        }
    }
    void AddToGrid()
    {
        foreach(Transform children in transform)
        {
            int borderX = Mathf.RoundToInt(children.transform.position.x);
            int borderY = Mathf.RoundToInt(children.transform.position.y);
            grid[borderX, borderY] = children;
            if (borderY == 20)
            {
                FindObjectOfType<SetPanel>().GetPanel();
                spawnCondition = false;
            }
        }
    }
    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int borderX = Mathf.RoundToInt(children.transform.position.x);
            int borderY = Mathf.RoundToInt(children.transform.position.y);

            if(borderX < 0 || borderX >= width || borderY < 0 )
            {
                return false;
            }
            if (grid[borderX, borderY] != null) 
            {
                return false;
            }  
        }
        return true;
    }
    
}
