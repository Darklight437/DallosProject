using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEntity : MonoBehaviour
{
    //position of the tile in a 2d grid
    public Vector3 TilePos;
    //put a modifier slot here if we doin mods

    private void Start()
    {
        TilePos = transform.position;
        TilePos.y += 1;
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ActivePlayer = GameObject.FindGameObjectWithTag("Player");
            ActivePlayer.GetComponent<GridActor>().NextTile = gameObject;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
