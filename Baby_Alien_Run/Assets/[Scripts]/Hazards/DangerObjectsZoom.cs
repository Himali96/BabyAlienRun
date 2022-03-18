using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerObjectsZoom : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        if ((transform.position.x - player.position.x) < 10 && (transform.position.x - player.position.x) > 0)
        {
            UI_Counter._instance.isZoomingIn = true;
        }
    }
}
