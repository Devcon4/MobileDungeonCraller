/*
 * Purpose: This utility class pulls config information from any xml file.
 * 
 * Special Notes:
 * 
 * Author: Devyn Cyphers.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using System;

public class XMLReaderUtility {
    //variables to be used.
    private string XMLFolder="Assets\\Scripts\\XML\\";

    Information info=new Information();

    //Lists all data in the given file(file).
    public List<Information> ListAllStories(string file) {
        List<Information> thisStory=new List<Information>();
        List<string> xmlContent=new List<string>();
        List<Information.Characters> charList=new List<Information.Characters>();

        XmlTextReader Reader=new XmlTextReader(XMLFolder+file);

        while(Reader.Read()) {
            Reader.MoveToContent();
            if(Reader.NodeType==XmlNodeType.Element) {
                xmlContent.Add(Reader.Name);
            }else if(Reader.NodeType==XmlNodeType.Text) {
                xmlContent.Add(Reader.Value);
            } else if(Reader.NodeType==XmlNodeType.EndElement) {
                if(Reader.Name=="Story"||Reader.Name=="Quest"||Reader.Name=="Event") {
                    xmlContent.Add("END");
                }
            }
        }
        int i=1;
        foreach(var var1 in xmlContent) {
            Information thisInfo=new Information();
            switch(var1) {
                case "Story": thisInfo.DirTypes=Information.DirectoryTypes.Story; break;
                case "Quest": thisInfo.DirTypes=Information.DirectoryTypes.Quest; break;

                case "Setting": thisInfo.setting=(Information.Setting)Enum.Parse(typeof(Information.Setting), xmlContent[i]); break;
                case "Characters": charList.Add((Information.Characters)Enum.Parse(typeof(Information.Characters), xmlContent[i])); break;
                case "END": thisInfo.listCharacters=charList;
                            thisInfo.ID=thisInfo.DirTypes.ToString()+thisInfo.setting.ToString();
                            thisStory.Add(thisInfo);
                            charList=new List<Information.Characters>();
                            thisInfo=new Information(); break;
            }
            i++;
        }
        //thisStory.ForEach((t) => Debug.Log(string.Format("XMLReaderUtility::ListAllStories: DirTypes: {0}, EntTypes: {1}, ID: {2}, Setting: {3}, Characters: {4}", t.DirTypes, t.EntTypes, t.ID, t.Setting, t.Characters)));
        return thisStory;
    }

    //Lists all of the character stats from a file(file).
    public List<Stats> ListCharStats(string file){
        List<Stats> charStats=new List<Stats>();
        List<string> xmlContent=new List<string>();

        XmlTextReader Reader=new XmlTextReader(XMLFolder+file);

        while(Reader.Read()) {
            Reader.MoveToContent();
            if(Reader.NodeType==XmlNodeType.Element) {
                xmlContent.Add(Reader.Name);
            }
            if(Reader.NodeType==XmlNodeType.Text) {
                xmlContent.Add(Reader.Value);
            }
        }
        Stats thisStats=new Stats();
        int i =1;
        foreach(var var1 in xmlContent) {

            switch(var1) {
                case "Axel": thisStats.ID=var1; break;
                case "Marks": thisStats.ID=var1; break;
                case "Max": thisStats.ID=var1; break;
                case "Sarah": thisStats.ID=var1; break;

                case "Accuracy": thisStats.Accuracy=float.Parse(xmlContent[i]); break;
                case "BaseRateOfFire": thisStats.BaseRateOfFire=float.Parse(xmlContent[i]); break;
                case "Damage": thisStats.Damage=float.Parse(xmlContent[i]); break;
                case "MovementSpeed": thisStats.MovementSpeed=float.Parse(xmlContent[i]); break;
            }
            i++;
            if(thisStats.Accuracy!=0&&thisStats.BaseRateOfFire!=0&&thisStats.Damage!=0&&thisStats.ID!=""&&thisStats.MovementSpeed!=0) {
                charStats.Add(thisStats);
                thisStats=new Stats();
            }
        }
        //charStats.ForEach((t) => Debug.Log(string.Format("XMLReaderUtility::ListCharStats: Accuracy: {0}, BaseRateOfFire: {1}, Damage: {2}, ID: {3}, MovementSpeed: {4}",t.Accuracy, t.BaseRateOfFire, t.Damage, t.ID, t.MovementSpeed)));
        return charStats;
    }

    //Finds matching information(file, directory, entry)(Not Very Usefull.)
    public List<string> FindEntry(string file, string directory, string entry) {
        List<string> EntryInfo=new List<string>();
        
        XmlTextReader Reader=new XmlTextReader(XMLFolder+file);

        Reader.ReadToFollowing(directory);

        do {
            Reader.ReadToDescendant(entry);
            do {
                EntryInfo.Add(Reader.ReadElementContentAsString());
            } while(Reader.ReadToNextSibling(entry));
        } while(Reader.ReadToFollowing(directory));
        return EntryInfo;
    }
}