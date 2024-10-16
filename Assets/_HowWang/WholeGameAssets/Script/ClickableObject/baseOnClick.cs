using System;
using System.Collections;
using System.Collections.Generic;
using Doublsb.Dialog;
using R3;
using R3.Triggers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class baseOnClick : MonoBehaviour
{
    protected readonly CommandManager Cmd = new();
    public baseTxtReader txtReader;
    
    /// <summary>
    /// 為了方便從外部加入Action而宣告
    /// </summary>
    protected List<DialogData> lstDialog = new();
    protected void Awake()
    {
        txtReader = gameObject.GetComponent<baseTxtReader>();
    }

    public virtual void Start()
    {
        // this.OnMouseDownAsObservable().Where(_=>!gameManager.IsTalking()).Subscribe(_ =>
        // {
        //     MouseClick();
        // });
    }

    protected virtual void MouseClick()
    {
        lstDialog = txtReader.Read_and_Transform();
        // gameManager.DialogueShow(lstDialog);
    }

    // protected void StartDialogIfNotTalking(List<DialogData> dialog)
    // {
    //     if (gameManager.IsTalking())
    //     {
    //         return;
    //     }
    //
    //     gameManager.DialogueShow(dialog);
    // }

    protected void ActionAddAt(List<DialogData> temp, int[] iDialogAction, UnityAction[] actions)
    {
        int itemp = -1;

        foreach (int i in iDialogAction)
        {
            if (i > temp.Count)
            {
                print("錯誤，指定的位置超出對話總數");
                return;
            }
        }

        foreach (int i in iDialogAction)
        {
            itemp++;
            temp[i - 1].Callback += actions[itemp];
        }
    }

    protected void ActionAddAt(List<DialogData> temp, int iDialogAction, UnityAction action)
    {
        if (iDialogAction > temp.Count)
        {
            print("錯誤，指定的位置超出對話總數");
            return;
        }

        //注意！這是覆寫
        temp[iDialogAction - 1].Callback += action;
    }

    /// <summary>
    /// 對答案時需要key
    /// </summary>
    /// <param name="dialogDatas"></param>
    /// <param name="question"></param>
    /// <param name="speaker"></param>
    /// <param name="selections"></param>
    /// <param name="selectionkeys"></param>
    protected void AddSelection(List<DialogData> dialogDatas, string question, string speaker, string[] selections,
        string[] selectionkeys)
    {
        var question1 = new DialogData(question, speaker);
        for (int i = 0; i < selections.Length; i++)
        {
            question1.SelectList.Add(selectionkeys[i], selections[i]);
        }

        question1.Callback = AfterSelect;
        dialogDatas.Add(question1);
    }

    /// <summary>
    /// 對答案時不用key
    /// </summary>
    /// <param name="dialogDatas"></param>
    /// <param name="question"></param>
    /// <param name="speaker"></param>
    /// <param name="selections"></param>
    protected void AddSelection(List<DialogData> dialogDatas, string question, string speaker, string[] selections)
    {
        var question1 = new DialogData(question, speaker);
        for (int i = 0; i < selections.Length; i++)
        {
            question1.SelectList.Add(selections[i], selections[i]);
        }

        question1.Callback = AfterSelect;
        dialogDatas.Add(question1);
    }

    private void AfterSelect()
    {
        var dialog = new List<DialogData>();
        // UnityAction act = gameManager.EndingDialogue;
        // act += () => act = null;
        //
        // CheckSelectResult(dialog, act);
        //
        // gameManager.DialogueShow(dialog);
    }

    protected virtual void CheckSelectResult(List<DialogData> dialog, UnityAction action)
    {
    }
}