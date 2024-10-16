using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class Test_OnClick_sc : baseOnClick
{
    public override void Start()
    {
        base.Start();
        lstDialog.Add(new DialogData("test換表情:怒" + Cmd.ChangeEmotion(E_Padko_Mood.Angry.ToString()) +
                                     "", E_Character.Padko.ToString()));
        lstDialog.Add(new DialogData("test換表情:怒+愛心" + Cmd.ChangeEmotion(E_Padko_Mood.Angry_heart.ToString()),
            E_Character.Padko.ToString()));
    }

    // protected override void MouseClick()
    // {
    //     gameManager.DialogueShow(lstDialog);
    // }
}