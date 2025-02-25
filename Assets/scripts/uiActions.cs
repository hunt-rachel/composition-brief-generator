using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro; 

public class UIActions : MonoBehaviour
{
    [SerializeField] private TMP_Text inputText;

    public TMP_InputField inputField;
    public GameObject startScreen;
    public ListManager LM;
    public ChangeMenus CM;
    
    public void startProgram()
    {
        if (LM.listsGot == false)
        {
            LM.GetLists();
            LM.listsGot = true;
        }

        startScreen.SetActive(false);
    }
    
    public void exitProgram()
    {
        Application.Quit();
        Debug.Log("Exiting Program");
    }
    
    public void getInputText(string input)
    {
        //resets input field so it can display placeholder text
        inputField.text = "";

        //deselects input field
        EventSystem.current.SetSelectedGameObject(null);

        string activeTitle = ""; 
        
        //makes associated list for editing menu active so correct data can be added
        foreach (string title in LM.masterList.Keys)
        {
            if (title == CM.getDropdownValue(CM.listDropdown))
            {
                Debug.Log(title + " will now become active list");
                activeTitle = title;
                break;
            }

            else
            {
                continue;
            }
        }

        LM.masterList[activeTitle].Add(input);

        //instantiate prefab of input here
    }
}
