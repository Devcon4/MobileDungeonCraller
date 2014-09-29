/*
 * Purpose: This is the core class for the dungeon generation code.
 * It handles and maintains how levels will fit together and matches the scene to its coresponding discription.
 * 
 * Special Notes: This is a core class.
 * 
 * Author: Devyn Cyphers.
 */

using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

//Delegates to be created.
public delegate void masterDungeonGenController1();
public delegate void masterDungeonGenController2(GameObject parentObj);

public class DungeonGenCore : MonoBehaviour {

    //Classes to be created.
    Tools tools=new Tools();
    TagCore tagCore=new TagCore();
    XMLReaderUtility xmlReaderUtility=new XMLReaderUtility();
    CreateObject createObject=new CreateObject();
    CreateSectionController CreateSection=new CreateSectionController();

    //Variables to be used.
    public GameObject StartSection;
    public int dungeonSize;
    public List<GameObject> allObjects = new List<GameObject>();
    public Information thisStory=new Information();
    List<Information> allStories=new List<Information>();
    public List<GameObject> usableObjects=new List<GameObject>();
    List<Stats> characterStats=new List<Stats>();
    public List<GameObject> createdObjects = new List<GameObject>();

    //delegates to be used.
    masterDungeonGenController1 masterDunGenController1;
    masterDungeonGenController2 masterDunGenController2;

    //Getters and Setters.


    // Initialization.
    void Start() {
        masterDunGenController1+=StoreData;
        masterDunGenController1+=PickStory;
        masterDunGenController1+=SetDungeonSize;
        masterDunGenController1+=GenStartSection;
        masterDunGenController2+=GenHallSection;
        BeginGeneration();
    }

    void BeginGeneration() {
        masterDunGenController1();
        masterDunGenController2(StartSection);
    }

    //Randomly picks a story.
    void PickStory() {
        int stryNum=UnityEngine.Random.Range(0, allStories.ToArray().Length);
        thisStory=allStories[stryNum];
        masterDunGenController1-=PickStory;
    }

    void StoreData() {
        //Lists all found stories.
        allStories=xmlReaderUtility.ListAllStories("StoryTypes.xml");

        //List all character information.
        characterStats=xmlReaderUtility.ListCharStats("CharacterStats.xml");

        masterDunGenController1-=StoreData;
    }

    void SetDungeonSize() {
        dungeonSize = UnityEngine.Random.Range(7, 28);
        masterDunGenController1 -= SetDungeonSize;
    }

    //Creates the start Section.
    void GenStartSection() {

        CreateSection.MakeStartSection(thisStory, usableObjects);
        StartSection = tools.FindLastObjectCreated();

        masterDunGenController1 -= GenStartSection; 

    }

    //Creates the Hall Sections.
    void GenHallSection(GameObject parentObj) {
        List<GameObject> parentObjectPoints = new List<GameObject>();

        parentObjectPoints = tagCore.FindGameObjectsWithThisTagThatAreChildrenOfThisGameObject("Point", parentObj);

        //Debug.Log(parentObj.name+"  count:"+parentObj.transform.childCount);
        //parentObjectPoints.ForEach((t) => Debug.Log("ParentObjectPoints: " + t.name + " Count: " + parentObjectPoints.Count));

        CreateSection.MakeHallSection(parentObjectPoints[0], usableObjects, thisStory);

        //parentObjectPoints.ForEach((t) => CreateSection.MakeHallSection(t, usableObjects, thisStory));

        masterDunGenController2 -= GenHallSection;
    }
}