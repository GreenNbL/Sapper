using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToMenu : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Scenes scene = GetComponent<Scenes>();
            scene.SwitchScene(0);
        }

    }
}
