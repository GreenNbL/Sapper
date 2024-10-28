using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject mainMenu;
    public void SwitchScene(int sceneIndex)
    {
        /*for(int i = 0; i < scenes.Length; i++)
            scenes[i].SetActive(false);
        scenes[sceneIndex].SetActive(true);  */
        SceneManager.LoadScene(sceneIndex); 
    }
    public void Quit()
    {
        Application.Quit();    
    }
    public void openMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void openSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        
    }

}
