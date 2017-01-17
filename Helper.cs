using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Helper
{
    public static Vector3 GetMousePosition()
    {
        Vector3 position = Input.mousePosition;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            position.x = hit.point.x;
            position.y = 0.1f;
            position.z = hit.point.z;
        }

        return position;
    }
}

