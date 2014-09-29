using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    void OnGUI() {
        GUI.Box(new Rect(10, 1, 100, 95), "MainMenu");
        if(GUI.Button(new Rect(20, 40, 80, 20), "Start")) {
            Application.LoadLevel(1);
        }
        if(GUI.Button(new Rect(20, 65, 80, 20), "Quit")) {
            Application.Quit();
        }
    }

}
