/*
 * Purpose: Manages how objects are linked to certain settings. It keeps ship objects only to ship maps
 * and planet objects to planet maps.
 * 
 * Special Notes:
 * 
 * Author: Devyn Cyphers.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ObjectSorter : MonoBehaviour {
    //variables to be used.
    public List<GameObject> allObjects=new List<GameObject>();
    public List<GameObject> logicalObjects=new List<GameObject>();
    public List<GameObject> forestObjects=new List<GameObject>();
    public List<GameObject> ShipObjects=new List<GameObject>();
    public List<GameObject> CaveObjects=new List<GameObject>();
    public List<GameObject> OutpostObjects=new List<GameObject>();
    public List<GameObject> CityObjects=new List<GameObject>();
    public List<GameObject> PlanetObjects=new List<GameObject>();
    public List<GameObject> SpaceObjects=new List<GameObject>();
    public List<GameObject> AstroidsObjects=new List<GameObject>();
    //enum to be used.
    public enum Settings { Forest, Ship, Cave, Outpost, City, Planet, Space, Astroids, Logical };

    //Returns a list of usable objects from the given setting(settings).
    public List<GameObject> FindObjectsOfThisSetting(Settings settings) {
        switch(settings) {
            case Settings.Forest: return forestObjects;
            case Settings.Ship: return ShipObjects;
            case Settings.Cave: return CaveObjects;
            case Settings.Outpost: return OutpostObjects;
            case Settings.City: return CityObjects;
            case Settings.Planet: return PlanetObjects;
            case Settings.Space: return SpaceObjects;
            case Settings.Astroids: return AstroidsObjects;
            case Settings.Logical: return logicalObjects;
            default: return null;
        }
    }

}
