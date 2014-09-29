/* 
 * purpose: This class is used to find Points given a target.
 * 
 * Special Notes: N/A
 * 
 * Author: Devyn Cyphers
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PointHandler : MonoBehaviour {

    //Classes to be used.
    TagCore tagCore=new TagCore();

    //Returns a list of points within the scene.
    List<GameObject> FindPointsInScene() {
        return tagCore.FindGameObjectsWithThisTag("Point");
    }

    //Returns a list of points within an object.
    List<GameObject> FindPointsOfThisObject(GameObject obj) {
        return tagCore.FindGameObjectsWithThisTagThatAreChildrenOfThisGameObject("Point", obj);
    }


}
