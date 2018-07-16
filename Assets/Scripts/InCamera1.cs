using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCamera1 : MonoBehaviour
{
    public LoseControl loseControl;

    private void OnBecameInvisible()
    {
        print("OnBecameInvisible");
        loseControl.inCameraView = false;
    }

    private void OnBecameVisible()
    {
        print("OnBecameVisible");
        loseControl.inCameraView = true;
    }
}
