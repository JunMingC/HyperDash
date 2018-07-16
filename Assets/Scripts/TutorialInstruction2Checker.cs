using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInstruction2Checker : MonoBehaviour
{
    public TutorialInstruction2 tutorialInstruction2;

    private void OnBecameInvisible()
    {
        print("OnBecameInvisible");
        tutorialInstruction2.inCameraView = false;
    }

    private void OnBecameVisible()
    {
        print("OnBecameVisible");
        tutorialInstruction2.inCameraView = true;
    }
}
