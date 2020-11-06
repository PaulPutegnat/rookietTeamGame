using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEAM7_cursor : MonoBehaviour
{
    public Texture2D crosshair;
    private Vector2 cursorHotSpot;

    void Start()
    {
        cursorHotSpot = new Vector2(crosshair.width/2, crosshair.height/2);
        Cursor.SetCursor(crosshair, cursorHotSpot, CursorMode.ForceSoftware);
    }
}
