using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : Game
{
    
    private void Awake()
    {
        app.way = gameObject.GetComponent<Way>();
        app.data.dots = gameObject.GetComponentsInChildren<Transform>();
    }
}
