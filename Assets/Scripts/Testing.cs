using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private Camera camera = null;
    private Grid grid = null;
    public Transform[] origins;

    private void Start(){
        Debug.Log("Created Grid!");
        camera = Camera.main;
        int i = 0;

        foreach (Transform origin in origins){
            Debug.Log(origin.position);
            // grid = new Grid(4,3,1f,origin.position-(new Vector3(0,4)*(0.5f)));
            grid = new Grid(4*i,3*i,1f,origin.position);
            i+=1;
        }
    }

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            Vector3 screenPos = Input.mousePosition;
            Vector3 worldPos = camera.ScreenToWorldPoint(screenPos);
            grid.setValue(worldPos,69);
        }

        if(Input.GetMouseButtonDown(1)){
            Vector3 screenpos = Input.mousePosition;
            Vector3 worldpos = camera.ScreenToWorldPoint(screenpos);
            Debug.Log(grid.getValue(worldpos));
        }
    }
}
