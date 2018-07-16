using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenuChecker : MonoBehaviour
{
    public TutorialMenu tutorialMenu;

    private void OnBecameInvisible()
    {
        print("OnBecameInvisible");
        tutorialMenu.inCameraView = false;
    }

    private void OnBecameVisible()
    {
        print("OnBecameVisible");
        tutorialMenu.inCameraView = true;
    }
}
