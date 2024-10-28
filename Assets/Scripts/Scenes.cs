using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void SwitchScene(int sceneIndex)
    {
        /*for(int i = 0; i < scenes.Length; i++)
            scenes[i].SetActive(false);
        scenes[sceneIndex].SetActive(true);  */
        SceneManager.LoadScene(sceneIndex);
        
    }
        
   
}
