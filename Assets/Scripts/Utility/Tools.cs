/*
 * This class holds utilites and tools that are used throught.
 * It is designed to shorten class length and minimize repeating code.
 * 
 * Special Notes: 
 * 
 * Author: Devyn Cyphers
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Tools {

    //Classes to be created.
    TagCore tagCore = new TagCore();

    GameObject TheGameController() {
        return GameObject.Find("GameController");
    }

    //Find last object created.
    public GameObject FindLastObjectCreated() {
        List<GameObject> createdObjects = TheGameController().GetComponent<DungeonGenCore>().createdObjects;
        int last;

        last = createdObjects.Count-1;
        return createdObjects[last];
    }
    
    //Finds all objects with the the given tag(tag) as a list(doesn't use the new tag system);
    public List<GameObject> FindObjectsWithTagOBS(string tag) {
        List<GameObject> objectsWithTag = new List<GameObject>();
        objectsWithTag.AddRange(GameObject.FindGameObjectsWithTag(tag));
        return objectsWithTag;
    }

    //Randomly generates a number within the given preamaters(min, max);
    public float FloatRandomGen(float min, float max) {
        return Random.Range(min, max);
    }
    public int IntRandomGen(int min, int max) {
        return Random.Range(min, max);
    }

    public GameObject FindClosest(List<GameObject> potentialObjs, GameObject parentObj) {
        GameObject closestObj = new GameObject();
        potentialObjs.ForEach((t) => Debug.Log(t.name));
        foreach (GameObject obj in potentialObjs) {
            float dist = parentObj.transform.position.sqrMagnitude;
            float testDist = Mathf.Infinity;

            if (dist < testDist) {

                testDist = dist;
                closestObj = obj;

            }
        }
        return closestObj;
    }
}
