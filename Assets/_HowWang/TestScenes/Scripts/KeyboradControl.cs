using System.Collections;
using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;
using Zenject;

public class KeyboradControl : MonoBehaviour
{
    [Inject] private AudioManager audio;
    void Update()
    {
        //Note: 用Enum來代替字串
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // audio.PlayBGM("Opening");
            
            // audio.PlayBGM(E_BGM.Opening.ToString());

            E_BGM temp = E_BGM.Opening;
            audio.PlayBGM(temp.ToString());
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            audio.PlayBGM("Game_DT");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            audio.PlaySFX("Btn_01");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            audio.PlaySFX("Btn_02");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            audio.BGMStop();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            audio.SFXStop();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            audio.BGMReset(1);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            audio.SFXReset(1);
        }
    }
}