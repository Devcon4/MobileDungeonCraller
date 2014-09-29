using UnityEngine;
using System.Collections;

public class CreateObject {

    GameObject LastObj;

    GameObject TheGameController() {
       return GameObject.Find("GameController");
    }

    public void MakeObject(GameObject obj, Vector3 pos, Quaternion rot){
        LastObj = (GameObject)GameObject.Instantiate(obj, pos, rot);
        TheGameController().GetComponent<DungeonGenCore>().createdObjects.Add(LastObj);
    }
}