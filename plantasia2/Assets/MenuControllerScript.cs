using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuControllerScript : MonoBehaviour {

    public GameObject MenuPanel;
    public Button MenuButton, QuitButton, ExitButton;

    public void OpenMenu()
    {
        MenuPanel.gameObject.SetActive(true);
        
    }

    public void CloseMenu()
    {
        MenuPanel.gameObject.SetActive(false);
    }

    public void doExitGame()
    {
        Application.Quit();
    }
}
