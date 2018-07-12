using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    //value to store mouse position when clicked
    Vector2 mousePos;
    //use for checking if we're gonna place walls horizontally or vertically. 0 - hor, 1 - vert
    int pos;

    public GameObject wall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //check where we clicked and place a wall there
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Vector3 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);
            //quick fix, because we were instatiating position of the object in the same height as camera is in world space
            //so it wasn't seen by mian camera
            pos.z = 0f;
            Instantiate(wall,pos,new Quaternion(0f,0f,0f,0f));
        }
		
	}
}
