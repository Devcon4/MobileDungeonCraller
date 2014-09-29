using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
public class CreateSectionController {

    //Classes to be created.
    Tools tools = new Tools();
    TagCore tagCore = new TagCore();
    CreateObject createObject = new CreateObject();

    public void MakeStartSection(Information thisStory, List<GameObject> usableObjects) {
        List<GameObject> startPointObjects = new List<GameObject>();
        List<GameObject> potentialStartObjects = new List<GameObject>();
        GameObject startPoint;

        startPointObjects = tagCore.FindGameObjectsWithThisTagInThisList("StartSection", usableObjects);
        potentialStartObjects = tagCore.FindGameObjectsWithThisTagInThisList(thisStory.setting.ToString(), startPointObjects);
        startPoint = potentialStartObjects[Random.Range(0, potentialStartObjects.Count)];

        //Debug.Log(startPoint.name);
        Debug.Log(Quaternion.Euler(Vector3.forward).eulerAngles.ToString());
        createObject.MakeObject(startPoint, Vector3.zero, Quaternion.Euler(Vector3.forward));
    }

    public void MakeHallSection(GameObject point, List<GameObject> usableObjects, Information thisStory) {
        List<GameObject> halObjs = new List<GameObject>();
        List<GameObject> potentialHalls = new List<GameObject>();
        List<GameObject> hallPoints = new List<GameObject>();

        halObjs = tagCore.FindGameObjectsWithThisTagInThisList("Hall", usableObjects);
        potentialHalls = tagCore.FindGameObjectsWithThisTagInThisList(thisStory.setting.ToString(), halObjs);
        GameObject hallSection = potentialHalls[Random.Range(0, potentialHalls.Count)];

        hallPoints = tagCore.FindAllGameObjectsWithThisTagThatAreChildrenOfThisGameObject("Point", hallSection);

        //Debug.Log(hallSection.name + "  count:" + hallSection.transform.childCount);

        //hallPoints.ForEach((t) => Debug.Log("HallPoints: " + t.name + " Count: " + hallPoints.Count));

        GameObject closestHallPoint = tools.FindClosest(hallPoints, hallSection);
        Vector3 pointPos = point.transform.position;

        /*if (point.transform.position.x <= 0) {
            pointPos.x += closestHallPoint.transform.position.x;
        } else {
            pointPos.x -= closestHallPoint.transform.position.x;
        }
        if (point.transform.position.z <= 0) {
            pointPos.z += closestHallPoint.transform.position.z;
        } else {
            pointPos.z -= closestHallPoint.transform.position.z;
        }*/

        //Debug.Log(point.transform.rotation.eulerAngles.ToString());

        createObject.MakeObject(hallSection, pointPos, point.transform.rotation);

    }
}