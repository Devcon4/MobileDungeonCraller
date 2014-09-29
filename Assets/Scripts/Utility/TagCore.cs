/*
 * Purpose: This is a self made tagging system for multiple tags.
 * Allows you to find objects by several specified features.
 * 
 * Special Notes: This is a core class.
 * 
 * Author: Devyn Cyphers.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TagCore {
    
    //Returns all scene objects with the given tag(tag).
    public List<GameObject> FindGameObjectsWithThisTag(string tag) {
        List<GameObject> foundObjects = new List<GameObject>();
        foreach (GameObject obj in GameObject.FindObjectsOfType(typeof(GameObject)))  {
            if (obj != null) {
                if (obj.GetComponent<Tag>().tags.Contains(tag)) {
                    foundObjects.Add(obj);
                } 
            }
        }
        return foundObjects;
    }

    //Returns A object with the given tag(tag) WARNING: Can cause problems.
    public GameObject FindAObjectWithThisTag(string tag) {
        GameObject foundObject = new GameObject();
        foreach (GameObject obj in GameObject.FindObjectsOfType(typeof(GameObject))) {
            if (obj != null) {
                if (obj.GetComponent<Tag>().tags.Contains(tag)) {
                    foundObject = obj;
                    return foundObject;
                }
            }
        }
        return null;
    }

    //Returns all objects with the given tag(tag).
    public List<GameObject> FindAllGameObjectsWithThisTag(string tag) {
        List<GameObject> foundObjects = new List<GameObject>();
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject))) {
            if (obj != null) {
                if (obj.GetComponent<Tag>().tags.Contains(tag)) {
                    foundObjects.Add(obj);
                }
            }
        }
        return foundObjects;
    }

    //Returns all objects with the given tag(tag) in the given list(lookList).
    public List<GameObject> FindGameObjectsWithThisTagInThisList(string tag, List<GameObject> lookList) {
        List<GameObject> foundObjects=new List<GameObject>();
        foreach(GameObject obj in lookList) {
            if(obj!=null) {
                if(obj.GetComponent<Tag>().tags.Contains(tag)) {
                    foundObjects.Add(obj);
                }
            }
        }
        return foundObjects;
    }

    //Returns all objects with the given tag(tag) that are children of the parent object(obj).
    public List<GameObject> FindGameObjectsWithThisTagThatAreChildrenOfThisGameObject(string tag, GameObject obj) {
        List<GameObject> foundObjects=new List<GameObject>();

        Transform[] allChildren = obj.GetComponentsInChildren<Transform>();
        foreach(Transform tran in allChildren) {
            GameObject obj2 = tran.gameObject;
            if(obj2!=null) {
                if(obj2.GetComponent<Tag>().tags.Contains(tag)) {
                    foundObjects.Add(obj2.transform.gameObject);
                }
            }
        }
        //foundObjects.ForEach((t) => Debug.Log(t.name));
        //Debug.Log(foundObjects.Count);
        return foundObjects;
    }

    //Returns all, even non-instantiated, objects with the given tag(tag) that are children of the parent object(obj).
    public List<GameObject> FindAllGameObjectsWithThisTagThatAreChildrenOfThisGameObject(string tag, GameObject obj) {
        List<GameObject> foundObjects = new List<GameObject>();

        Transform[] allChildren = obj.GetComponentsInChildren<Transform>(true);
        foreach (Transform tran in allChildren) {
            GameObject obj2 = tran.gameObject;
            if (obj2 != null) {
                if (obj2.GetComponent<Tag>().tags.Contains(tag)) {
                    foundObjects.Add(obj2.transform.gameObject);
                }
            }
        }
        //foundObjects.ForEach((t) => Debug.Log(t.name));
        //Debug.Log(foundObjects.Count);
        return foundObjects;
    }

    //Returns all objects with the given setting(setting).
    public List<GameObject> FindObjectsOfSetting(Information.Setting setting) {
        List<GameObject> settingObjs=new List<GameObject>();

        settingObjs=FindGameObjectsWithThisTag(setting.ToString());

        return settingObjs;
    }

    //Returns all of the objects with the given setting(setting) that are in the given list(lookList).s
    public List<GameObject> FindObjectsOfSettingInThisList(Information.Setting setting, List<GameObject> lookList) {
        List<GameObject> settingObjs=new List<GameObject>();

        settingObjs=FindGameObjectsWithThisTagInThisList(setting.ToString(), lookList);

        return settingObjs;
    }

}
