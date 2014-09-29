using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct Information {
    public string ID;
    public enum DirectoryTypes { Story, Quest }
    public enum EntryTypes { MapType, Setting, Characters }
    public enum Setting { Forest, Ship, Cave, Outpost, City, Planet, Space, Astroids }
    public enum Characters { Axel, Sara, Marks, Max }

    public DirectoryTypes DirTypes;
    public EntryTypes EntTypes;
    public Setting setting;
    public List<Characters> listCharacters;

    public Information(string id, DirectoryTypes dirTypes, EntryTypes entTypes, Setting sett, List<Characters> characters) {
        ID=id;
        DirTypes=dirTypes;
        EntTypes=entTypes;
        setting=sett;
        listCharacters=characters;
    }
}