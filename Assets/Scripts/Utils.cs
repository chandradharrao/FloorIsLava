using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    //spawn gameobject of type Textmesh and set its details
    public static TextMesh createWorldText(
        Vector3 worldpos,
        string data,
        Color color
    ){
        GameObject go = new GameObject("World_Text",typeof(TextMesh));
        Transform transform = go.transform;
        transform.localPosition = worldpos;
        
        TextMesh tm = go.GetComponent<TextMesh>();
        tm.text = data;
        tm.color = color;
        tm.anchor = TextAnchor.MiddleCenter;
        tm.fontSize = 5;
        return tm;
    }
}
