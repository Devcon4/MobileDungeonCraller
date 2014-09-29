using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

//Delegates to be used.
public delegate void masterSectionManagerController();

public class SectionManager {

    //Delegates to be used.
    masterSectionManagerController masterSecManController;

    //Variables to be used.
    int dungeonSize;
    void MasterController() {
       
        masterSecManController+=SetDungeonSize;

    }

    void SetDungeonSize() {

    }

    void PickFromPoints() {
        


    }

    void ManageSection() {

        

    }
}
