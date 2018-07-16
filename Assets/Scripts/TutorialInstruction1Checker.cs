using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInstruction1Checker : MonoBehaviour
{
    public TutorialInstruction1 tutorialInstruction1;

    private void OnBecameInvisible()
    {
        print("OnBecameInvisible");
        tutorialInstruction1.inCameraView = false;
    }

    private void OnBecameVisible()
    {
        print("OnBecameVisible");
        tutorialInstruction1.inCameraView = true;
    }
}
