using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridActor : MonoBehaviour
{

    //reference to current tile
    public GameObject CurrTile;
    
    //target tile for moving towards
    public GameObject NextTile;

    public float SmoothTime = 1.0f;

    //wether this actor is selected
   public bool ActiveActor = false;


    private Vector3 Velocity = Vector3.zero;

    void Start()
    {
        //for testing sake

        CurrTile = GameObject.Find("Tile 0");
        NextTile = GameObject.Find("Tile 1");

        

        transform.position = GetTilePos(CurrTile);
    }


    Vector3 GetTilePos(GameObject Tile)
    {
        return Tile.GetComponent<TileEntity>().TilePos;
    }

    void Update()
    {
        if (ActiveActor)
        {
            gameObject.tag = "Player";
        }
        else
        {
            gameObject.tag = "Actors";
        }


        if (Input.GetKey("space"))
        {
 
           
            //set our position as a fraction of the distasnce between markers
            transform.position = Vector3.SmoothDamp(transform.position, GetTilePos(NextTile), ref Velocity,SmoothTime);

        }

        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ActiveActor = true;
        }

    }



}
