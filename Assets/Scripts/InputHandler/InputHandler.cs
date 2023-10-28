using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputHandler
{
    public static float Horzontal
    {
        get
        {
            return Input.GetAxisRaw("Horizontal");
        }
    }
    public static float Vertical
    {
        get
        {
            return Input.GetAxisRaw("Vertical");
        }
    }

    public static Vector3 MousePosition
    {
        get
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
}
