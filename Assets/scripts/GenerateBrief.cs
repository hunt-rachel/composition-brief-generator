using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateBrief : MonoBehaviour
{
    //generated texts
    public TMP_Text timeSigText;
    public TMP_Text keySigText;
    public TMP_Text instText;
    public TMP_Text lengthText;
    public TMP_Text purposeText;
    public TMP_Text inspoText;

    public ListManager LM;

    //non-user defined lists
    //time signature - number of beats randomly generated
    int[] typeOfBeat = { 4, 8 };

    //key signature lists
    string[] keyScale = { "C", "C# /Db", "D", "D# /Eb", "E", "F", "F# /Gb", "G", "G# /Ab", "A", "A# /Bb", "B" };
    string[] keyTonality = {"Major", "Minor", "Dorian", "Phrygian", "Lydian", "Mixolydian", "Aeolian", "Locrian"};
    
    public void generateBrief()
    {
        //generated time signature
        //probabilites fixed to make common time signatures more likely, but still chance for complex time signature. 
        timeSigText.text = generateTimeSig();
        
        //generated key signature - CHANGE TO ALTER PROBABILITIES
        keySigText.text = keyScale[Random.Range(0, keyScale.Length)] + " " + keyTonality[Random.Range(0, keyTonality.Length)];

        //generated instrumentation
        if (LM.instrumentationList.Count == 0) {
            instText.text = "No instrumentation added yet!";
        }

        else
        {
            instText.text = LM.instrumentationList[Random.Range(0, LM.instrumentationList.Count)];
        }

        //length text here

        //generated purpose
        if (LM.purposeList.Count == 0)
        {
            purposeText.text = "No purpose added yet!";
        }

        else
        {
            purposeText.text = LM.purposeList[Random.Range(0, LM.purposeList.Count)];
        }

        //figure out how to do inspo based on drop down selection
    }

    //generates complex time signatures at random given specific ranges to allow for feasability
    public string generateComplexTimeSig()
    {
        float numOfBeats = Random.Range(3, 13);
        string beatNum = numOfBeats.ToString();
        string beatType = typeOfBeat[Random.Range(0, typeOfBeat.Length)].ToString();

        string complexTimeSig = beatNum + "/" + beatType;

        return complexTimeSig;
    }

    //rigs probability for users so more common time signatures are more likely, but complex ones aren't impossible
    public string generateTimeSig()
    {
        string[] timesToChooseFrom = {"4/4", "3/4", "6/8", generateComplexTimeSig()};

        string timeSig = timesToChooseFrom[Random.Range(0, timesToChooseFrom.Length)]; 
        
        return timeSig;
    }
}
