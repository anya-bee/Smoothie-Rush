using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private TextMeshProUGUI displayNameText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    [SerializeField] private KeyCode interactKey;

    private static DialogueManager instance; 

    private const string SPEAKER_TAG = "speaker";
    private const string FRUTA_1 = "fruta1";
    private const string FRUTA_2 = "fruta2";
    private const string FRUTA_3 = "fruta3";

    private const string PERFECT = "Perfect";
    private const string GOOD = "Good";

    public string[] npcOrder = new string[3];

    public string juiceState;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("found more than one dialogue manager in the scene");
        }
        instance = this; 
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
        if (Input.GetKeyDown(interactKey))
        {
            ContinueStory();
        }

        

    }

    public void EnterDialogueMode( TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        // reset stuff 


        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // set text for the current dialogue line
            dialogueText.text = currentStory.Continue();
            // handle tags 
            HandleTags(currentStory.currentTags);
        }

        else
        {
            ExitDialogueMode();
        }
    }



    private void HandleTags(List<string> currentTags)
    {
        //loop through each tag and handle it accordingly 
        foreach ( string tag in currentTags)
        {
            // parse de tag 
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag couldnt be parsed LOL");
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim(); 
            

            switch (tagKey)
            { 
             case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
             case FRUTA_1:
                    npcOrder[0] = tagValue;
                    break;
             case FRUTA_2:
                    npcOrder[1] = tagValue;
                    break;
             case FRUTA_3:
                    npcOrder[2] = tagValue;
                    break;

            default:
                    Debug.LogWarning("Tage came in but is not being handled");
                    break;

            }




        }
    }


    private void checkOrderManager()
    {
        juiceState = GameObject.FindWithTag("Glass").GetComponent<JuiceGlass>().result;
        
       



    }


}
