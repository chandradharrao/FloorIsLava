using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int nrows;
    private int ncols;
    private int[,] matrix;
    private TextMesh[,] textGameObjects;
    private float cellsize;
    private Vector3 origin;

    void drawCell(
        int startI,
        int startJ
    ){
        Debug.DrawLine(
            grid2world(startI,startJ),
            grid2world(startI,startJ+1),
            Color.white,
            100f
        );

        Debug.DrawLine(
            grid2world(startI,startJ+1),
            grid2world(startI+1,startJ+1),
            Color.white,
            100f
        );

        Debug.DrawLine(
            grid2world(startI+1,startJ+1),
            grid2world(startI+1,startJ),
            Color.white,
            100f
        );

        Debug.DrawLine(
            grid2world(startI+1,startJ),
            grid2world(startI,startJ),
            Color.white,
            100f
        );
    }

    //convert world position to grid index and set its value
    public void setValue(Vector3 worldPos,int value){
        try{
            int[] indices = world2grid(worldPos);

            matrix[indices[0],indices[1]] = value;
            textGameObjects[indices[0],indices[1]].text = value.ToString();
        }
        catch{
            Debug.Log("Clicking outside of the grid!");
        }
    }

    //get the value at the world position
    public int getValue(Vector3 worldPos){
        try{
            int[] indices = world2grid(worldPos);
            return matrix[indices[0],indices[1]];
        }
        catch{
            Debug.Log("Outside grid!");
            return -1;
        }
    }

    public Grid(
        int ncols,
        int nrows,
        float cellsize,
        Vector3 origin
    ){
        this.nrows = nrows; 
        this.ncols = ncols; 
        this.cellsize = cellsize;
        this.origin = origin;

        this.matrix = new int[nrows,ncols];
        this.textGameObjects = new TextMesh[nrows,ncols];

        for(int i= 0;i<matrix.GetLength(0);i++){
            for(int j = 0;j<matrix.GetLength(1);j++){
                matrix[i,j] = -1;

                textGameObjects[i,j] = Utils.createWorldText(
                    grid2world(i,j)+new Vector3(cellsize,-cellsize)*0.5f,
                    i+","+j,
                    Color.white
                );

                //draw a single cell
                drawCell(i,j);
            }
        }     
    }

    //return the world vector position of a matrix index
    public Vector3 grid2world(
        int i,
        int j
    ){
        return (new Vector3(j,ncols-i-1)*cellsize) + origin;
    }

    //return grid indices given world pos
    public int[] world2grid(
            Vector3 worldPos
        ){
        int[] indices = new int[2];
        int i = Mathf.FloorToInt((worldPos.x-origin.x)/cellsize);
        int j = Mathf.FloorToInt((worldPos.y-origin.y)/cellsize);

        indices[1] = i;
        indices[0] = ncols-j-2;
        return indices;
    }
}
