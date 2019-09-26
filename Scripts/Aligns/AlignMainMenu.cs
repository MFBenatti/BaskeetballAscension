using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignMainMenu : MonoBehaviour
{
    public GameObject mainMenu;

    public void Awake()
    {
        mainMenu.transform.position = new Vector2(Screen.width / 2, Screen.height / 2 + Screen.height / 5f);
    }
}
