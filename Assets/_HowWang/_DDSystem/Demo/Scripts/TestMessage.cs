using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.UI;
using Zenject;

public class TestMessage : MonoBehaviour
{
    [Inject] DialogManager dialogManager;

    [Inject] private Tester_sc gameManager;

    public CommandManager cmdManager = new CommandManager();

    public void Start()
    {
    }

    IEnumerator CoDialogue(List<DialogData> dialog)
    {
        yield return null;
        gameManager.DialogueShow(dialog);
    }

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData(
            "我最近"+
            // "\n" +
            "在對別人的專案動手動腳", E_Character.dong.ToString()));

        dialogTexts.Add(new DialogData(
            "這是我婆，給你看一下", E_Character.Padko.ToString()));

        dialogTexts.Add(new DialogData(
            "其實是想告訴你" +
            cmdManager.ChangeEmotion("Sad") +
            "可以換圖片啦", E_Character.Padko.ToString()));

        dialogTexts.Add(new DialogData("介紹一下功能", E_Character.dong.ToString()));

        dialogTexts.Add(new DialogData(
            "可以改變字體" +
            cmdManager.ChangeColor(E_TextColor.red) +
            "顏色，" +
            "/color:white/" +
            "還有" + "\n" +
            "/size:up//size:up/" +
            "字體大小" +
            cmdManager.ChangeSize(E_Up_Down_Init.init) +
            "看一下差別",
            E_Character.dong.ToString(), () => Show_Example(0)));

        dialogTexts.Add(new DialogData("我順便做了一些methods", E_Character.dong.ToString()));
        dialogTexts.Add(new DialogData("讓使用者不容易打錯，" +
                                       cmdManager.ChangeEmotion("Sad") +
                                       "畢竟我討厭字串", E_Character.Padko.ToString(), () => Show_Example(1)));

        dialogTexts.Add(new DialogData(
            "還可以改表情 /emote:Sad/但其實只是換圖（心虛）" +
            cmdManager.WaitingClick() +
            "/emote:Normal/" +
            "美工若有需求可以再試著修改成用圖層方式改變表情" +
            "", E_Character.Padko.ToString(),
            () => Show_Example(2)));

        dialogTexts.Add(new DialogData(
            "這個插件提供一些氣氛營造的效果，像是等個1秒..."
            + cmdManager.Wait_for_Seconds(1) +
            "1秒過去了， 或是點擊滑鼠/click/才出現下一句",
            E_Character.dong.ToString(), () => Show_Example(3)));

        dialogTexts.Add(new DialogData("放慢文字顯示速度 /speed:down/放慢放慢放慢... /speed:init//speed:up/然後突然變快",
            E_Character.dong.ToString(),
            () => Show_Example(4)));

        dialogTexts.Add(new DialogData(
            "也可以自動進入下一句" +
            cmdManager.ChangeSpeed(.5f) +
            " 看仔細........................./close/", E_Character.dong.ToString(),
            () => Show_Example(5)));

        dialogTexts.Add(new DialogData("/speed:0.1/這句不給你skip", E_Character.dong.ToString(), () => Show_Example(6),
            false));

        //若只要不能跳過的效果，action那邊給個null即可
        dialogTexts.Add(new DialogData("當然音效必不可少 /click/" +
                                       cmdManager.PlaySound("haha") +
                                       "搞啥啊（關西腔）", E_Character.tong.ToString(), null, false));
        dialogTexts.Add(new DialogData("已經跟之前的音效播放專案做了整合，整理資源時應該會比較方便吧", "Sa"));

        dialogTexts.Add(new DialogData("之後還有選項的功能，但我還沒看，先這樣" +
                                       cmdManager.Wait_for_Seconds(2) +
                                       "", E_Character.Me.ToString(), EnddingDialogue));

        IEnumerator co = CoDialogue(dialogTexts);
        StartCoroutine(co);
        // gameManager.DialogueShow(dialogTexts)

        // {
        //     for (int i = 0; i < 3; i++)
        //     {
        //         var btn = new List<DialogData>();
        //         btn.Add(new DialogData(
        //             $"按了{i}號按鈕" +
        //             cmdManager.Wait_for_Seconds(0.5f) +
        //             cmdManager.Close()
        //             , "Li"));
        //         btn.Add(new DialogData(cmdManager.Close(), "", EnddingDialogue, false));
        //         DialogueArray[i] = btn;
        //     }
        // }
    }

    private void EnddingDialogue()
    {
        gameManager.EnddingDialogue();
    }

    private void Show_Example(int index)
    {
        // Example[index].SetActive(true);
    }
}