using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ChangeMenus : MonoBehaviour
{
    public Button goBackButton; //button to return to previous screen

    public TMP_Text titleText; //text for title of 

    public TMP_Text[] mainTextArr; //array of text in main generator screen (not text in any of the editing menus)

    public TMP_Dropdown listDropdown; //dropdown of titles of editing screens
    public TMP_Dropdown inspoDropdown; //dropdown of what to be inspired by

    public TMP_InputField userInput; //user input field

    public GameObject scrollView; //scroll view

    public ListManager LM;

    public List<string> editingList = new List<string>();

    //for list instantiation
    public GameObject contentParent;
    public GameObject listItemPrefab;
    public int testAmt;
    public Vector3 currPosition;
    public Vector3 direction;
    public float spacing;

    void Start()
    {
        goBackButton.interactable = false; //disables go back button as there is no previous screen

        //all parts of editing menu disabled for main menu
        userInput.interactable = false;
        userInput.gameObject.SetActive(false);
        scrollView.gameObject.SetActive(false);

        titleText.text = "Composition Brief Generator";
    }
    
    //returns key for dictionary containing lists
    //specific to list to be edited for specific editing menu chosen
    public void goToEditingMenu()
    {
        //enables button to return to main screen
        goBackButton.interactable = true;
        titleText.text = "Editing: " + getDropdownValue(listDropdown);
        
        //enabling editing menu text
        userInput.gameObject.SetActive(true);
        scrollView.gameObject.SetActive(true);
        userInput.interactable = true;

        disableMainText();

        Debug.Log("now editing: " + getDropdownValue(listDropdown));

        //clears content space for instantiation
        clearListSpace();
        
        //instantiates relevant list as prefab
        instantiateList(getDropdownValue(listDropdown));
    }

    public void clearListSpace()
    {
        foreach (Transform child in contentParent.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    public void instantiateList(string dropdown)
    {
        //gets associated list from dropdown selection
        editingList = findListToShow(dropdown);
        Debug.Log("editing list first index: " + editingList[0]); //debugging to check correct list found
        
        currPosition = contentParent.transform.position;
        
        for (int i = 0; i < editingList.Count; i++)
        {
            GameObject listItem = Instantiate(listItemPrefab, currPosition, Quaternion.identity, contentParent.transform);

            listItem.GetComponentInChildren<TMP_Text>().text = editingList[i];

            currPosition += new Vector3(0, spacing, 0);
        }
    }

    public List<string> findListToShow(string dropdown)
    {
        List<string> listToShow = new List<string>();

        switch(dropdown) {
            case "Instrumentation":
                listToShow = LM.instrumentationList;
                break;

            case "Purpose":
                listToShow = LM.purposeList;
                break;

            case "Game":
                listToShow = LM.gameList;
                break;

            case "Composer":
                listToShow = LM.composerList;
                break;

            case "Genre":
                listToShow = LM.genreList;
                break;

            default:
                Debug.Log("list to instantiate not found");
                break;
        }

        return listToShow;
    }

    //returns to main menu
    public void goBack()
    {
        goBackButton.interactable = false;

        titleText.text = "Composition Brief Generator";

        userInput.interactable = false;
        userInput.gameObject.SetActive(false);
        scrollView.gameObject.SetActive(false);

        enableMainText();

        Debug.Log("going back");
    }

    //gets text for editing menu title
    public string getDropdownValue(TMP_Dropdown dropdown)
    {
        return dropdown.options[dropdown.value].text; 
    }

    public void disableMainText()
    {
        foreach (var text in mainTextArr)
        {
            text.enabled = false;
        }

        inspoDropdown.gameObject.SetActive(false);
    }

    public void enableMainText()
    {
        foreach (var text in mainTextArr)
        {
            text.enabled = true;
        }

        inspoDropdown.gameObject.SetActive(true);
    }

}
