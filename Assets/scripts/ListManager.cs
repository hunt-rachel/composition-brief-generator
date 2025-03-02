using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ListManager : MonoBehaviour
{
    //public List<string> timeSignatureList = new List<string>();
    //public List<string> keySignatureList = new List<string>();
    public List<string> instrumentationList = new List<string>();
    //public List<string> lengthList = new List<string>();
    public List<string> purposeList = new List<string>();
    public List<string> gameList = new List<string>();
    public List<string> composerList = new List<string>();
    public List<string> genreList = new List<string>();

    public Dictionary<string, List<string>> masterList = new Dictionary<string, List<string>>();

    public bool listsGot = false;

    // Start is called before the first frame update
    
    void Start()
    {
        CompileMasterList();
    }

    // Adds all lists to a master list dictionary for reference when choosing editing menu
    private void CompileMasterList()
    {
        masterList.Add("Instrumentation", instrumentationList);
        masterList.Add("Purpose", purposeList);
        masterList.Add("Game", gameList);
        masterList.Add("Composer", composerList);
        masterList.Add("Genre", genreList);
    }

    private void deleteFromList(string toDelete, List<string> list)
    {
        list.Remove(toDelete);
    }

    void OnApplicationQuit()
    {
        SaveLists();
        Debug.Log("Application ending after " + Time.time + " seconds");
    }

    //uses information from master list dictionary to create keys for player prefs
    //string list concatenated into string using "###" as highly unlikely this will be used in actual text input by user
    private void SaveLists()
    {
        foreach(string key in masterList.Keys)
        {
            if (masterList[key].Count > 0)
            {
                PlayerPrefs.SetString(key, string.Join("###", masterList[key]));
                Debug.Log("saved " + key + " to player prefs.");
            }

            else
            {
                continue;
            }
            
        }
    }

    //gets each editing list from its respecitve player prefs string
    //and seperates it by "###" seperator
    public void GetLists()
    {
        foreach(string key in masterList.Keys)
        {
            if(PlayerPrefs.HasKey(key))
            {
                string stringToSplit = PlayerPrefs.GetString(key);
                Debug.Log("found " + key + " from player prefs");
                Debug.Log(stringToSplit);
                string[] stringArr = stringToSplit.Split("###");

                foreach (string str in stringArr)
                {
                    masterList[key].Add(str);
                }
            }

            else
            {
                continue;
            }
        }
    }
}
