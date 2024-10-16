using System;
using System.Collections;
using System.Collections.Generic;
using Doublsb.Dialog;
using R3;
using UnityEngine;
using Zenject;

public class Extra_sc : MonoBehaviour
{
    [Inject] private DialogManager _dialogManager;
    [Inject] private ZenjectSceneLoader _sceneLoader;
    [Inject] private AudioManager _audioManager;
    private List<DialogData> _listDialog;
    private string _strHao = "HaoWang";
    private string _strWink = "<sprite=0>";
    private CommandManager _cmd = new();
    public ParticleSystem paBoing;

    private void Awake()
    {
        
    }

    private IEnumerator AddDialog()
    {
        List<DialogData> temp = new();

        temp.Add(new("嗨妳來了，會來到這房間代表妳剛剛玩完這款遊戲了", _strHao));
        yield return new WaitForEndOfFrame();
        temp.Add(new("我是Hao Wang，姑且是這個遊戲的主程式", _strHao));
        yield return new WaitForEndOfFrame();
        temp.Add(new("這次有幸跟幾位user合作這款遊戲，真的是受益良多", _strHao));
        temp.Add(new("跟各式各樣的人合作時，往往是反思自己的最佳時機", _strHao));
        temp.Add(new("硬著頭皮做自己沒做過的事，也是不錯的經驗" +_cmd.ChangeSpeed(0.001f)+
                     "   <sprite=6>", _strHao));
        temp.Add(new("遊戲的原名叫安憩之地，我想應該是出自聖經、教會的詞吧", _strHao));
        temp.Add(new("結果搜尋一下Resting place，都是出來什麼長眠之地、墳墓之類的中譯", _strHao));
        temp.Add(new("說實在我也搞不太清楚，但教會詩歌的Resting place應該不是在講那類東西", _strHao));
        temp.Add(new("總之我就照用了，就算真的是墳墓......", _strHao));
        temp.Add(new("那也是我倆愛情的墳墓吧" + _cmd.Wait_for_Seconds(3), _strHao));
        temp.Add(new("聊天室別再刷「醒」了。", _strHao));
        
        temp.Add(new("說說這個房間的事吧", _strHao));
        temp.Add(new("其實在劇情定下來之前，這裡就已經做好了", _strHao));
        temp.Add(new("如妳所見這裡座位挺多的，畢竟本來我是打算給遊戲製作組來這裡發表一下心得感想", _strHao));
        temp.Add(new("結果因為各式各樣的情況，這個遊戲是壓線完成的", _strHao));
        temp.Add(new("2月28日遊戲完成的當下，已經沒什麼餘力徵集製作組的心得文了", _strHao));
        temp.Add(new("但是這場景放著又感覺很浪費，所以我來尬聊一下", _strHao, ShowBoing));
        temp.Add(new("我這裡有個酷東西，但是翻遍了劇本找不到地方可以用，所以就廢棄了", _strHao, ShowBoing));
        temp.Add(new("再看一次。", _strHao, ShowBoing));
        temp.Add(new("什麼？妳說可以用在妳身上？", _strHao, () =>
        {
            _audioManager.BGMStop();
        }));
        temp.Add(new(_cmd.PlaySound("noboing") + _cmd.ChangeSpeed(0.001f)+ "<sprite=0>", _strHao, () => { _sceneLoader.LoadScene(0); }));
        // temp.Add(new("  <sprite=0>" , _strHao));
        _listDialog = temp;

        _dialogManager.Show(_listDialog);
    }

    private void ShowBoing()
    {
        paBoing.Stop();
        paBoing.Play();
    }

    void Start()
    {
        // var co = Observable.FromCoroutine(AddDialog);
        // co.StartAsCoroutine();
        _audioManager.PlayBGM(E_BGM.Extra.ToString());
    }

    void Update()
    {
    }
}