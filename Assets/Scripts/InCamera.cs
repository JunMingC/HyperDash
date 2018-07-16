using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCamera : MonoBehaviour
{
    public MenuControl menuControl;

    private void OnBecameInvisible()
    {
        menuControl.inCameraView = false;
    }

    private void OnBecameVisible()
    {
        menuControl.inCameraView = true;
    }
}
