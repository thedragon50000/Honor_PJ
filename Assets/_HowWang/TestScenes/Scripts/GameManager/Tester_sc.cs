using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
// using UnityEngine.UIElements;
using UnityEngine.UI;
using Zenject;

public class Tester_sc : MonoBehaviour
{
    [Inject]
    public DialogManager dialogManager;
    public bool bIsTalking = false;

    [Inject]
    void Init()
    {
        print("dialogManager:" + dialogManager.name);
    }

    public void EnddingDialogue()
    {
        bIsTalking = false;
    }

    public void DialogueShow(List<DialogData> dialogTexts)
    {
        bIsTalking = true;
        dialogManager.Show(dialogTexts);
    }

    public bool IsTalking()
    {
        return bIsTalking;
    }
}