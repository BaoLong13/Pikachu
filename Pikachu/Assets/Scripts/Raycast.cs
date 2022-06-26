using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
   [SerializeField] Camera _camera;
    private void Update()
    {
        RaycastHit vHit = new RaycastHit();
        Ray vRay = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(vRay, out vHit, 1000))
        {
            Debug.Log("OK");
            Cursor.visible = false;
        }

    }
}
