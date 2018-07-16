using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControl : MonoBehaviour
{
    public GameObject vrCamera;
    public GameObject player;
    public GameObject tutorial_monster_1;
    public GameObject tutorial_monster_2;
    public TutorialInstruction1 tutorialInstruction1;
    public TutorialInstruction2 tutorialInstruction2;
    public TutorialMenu tutorialMenu;
    public GameObject comboText;
    public GameObject cockPit;
    public TutorialHud hudControl;

    private void Start()
    {
        cockPit.gameObject.SetActive(true);
        hudControl.gameObject.SetActive(true);
        spawn_enemy_1();
    }

    private void Update()
    {
        tutorial_monster_1.transform.LookAt(player.transform);
        tutorial_monster_2.transform.LookAt(player.transform);
    }

    public void spawn_enemy_1()
    {
        Invoke("spawn_enemy_1_invoke", 0.1f);
    }

    public void spawn_enemy_1_invoke()
    {
        tutorial_monster_1.GetComponent<BoxCollider>().enabled = false;
        tutorial_monster_1.GetComponent<TutorialEnemy>().attackRate = 1f;
        tutorial_monster_1.GetComponent<TutorialEnemy>().SetAlive(true);
        tutorial_monster_1.transform.position = vrCamera.transform.position + vrCamera.transform.forward * 5f + vrCamera.transform.up * -1.1f;
    }

    public void spawn_enemy_2()
    {
        Invoke("spawn_enemy_2_invoke", 0.1f);
    }

    public void spawn_enemy_2_invoke()
    {
        tutorial_monster_2.GetComponent<TutorialEnemy>().SetAlive(true);
        tutorial_monster_2.transform.position = vrCamera.transform.position + vrCamera.transform.forward * 5f + vrCamera.transform.up * -1.1f;
    }

    public void spawn_menu_1()
    {
        tutorialInstruction1.gameObject.SetActive(true);
    }

    public void spawn_menu_2()
    {
        tutorialInstruction2.gameObject.SetActive(true);
    }

    public void spawn_menu_3()
    {
        tutorialMenu.gameObject.SetActive(true);
    }
}
