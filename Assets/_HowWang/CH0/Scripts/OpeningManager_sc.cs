using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using R3;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OpeningManager_sc : MonoBehaviour
{
    [Inject] private ZenjectSceneLoader _sceneLoader;
    [Inject] private AudioManager _audioManager;
    [Inject(Id = "Clear")] private bool _bClearGame;

    public Sprite[] sprUser;
    public SpriteRenderer sprBackground;
    public GameObject goUser;
    public SpriteRenderer rendererUser;

    public Button btnStart;
    public Button btnExtra;

    public new ParticleSystem particleSystem;
    public Sprite sprLoading;

    private void Awake()
    {
        if (_bClearGame)
        {
            sprBackground.gameObject.SetActive(false);
        }

        rendererUser = goUser.GetComponent<SpriteRenderer>();
        btnStart.OnClickAsObservable().Subscribe(_ =>
        {
            
            btnStart.image.sprite = sprLoading;
            _sceneLoader.LoadSceneAsync(1); //CH1
        });
        btnExtra.OnClickAsObservable().Subscribe(_ =>
        {
            _sceneLoader.LoadSceneAsync(5); //EXTRA Room
        });
        _audioManager.PlayBGM(E_BGM.Opening.ToString());
        
        // Note: LoadSceneWithId Sample
        /*
         [Inject] private ZenjectSceneLoader _sceneLoader;

    public void PlayGame(int LevelNumber)
    {
        var s = E_ZenjectID.Level.ToString();
        _sceneLoader.LoadScene(1, LoadSceneMode.Single,
            container => container.BindInstance(LevelNumber).WithId(s));
    }
         */
    }

    void Start()
    {
        btnStart.gameObject.SetActive(false);
        // DOTween.Sequence()
        Tweener doScale = goUser.transform.DOScale(new Vector3(9, 9, 2), 1).OnComplete(() =>
        {
            rendererUser.sprite = sprUser[0];
            goUser.transform.DORotate(new Vector3(0, 0, 720), 4, RotateMode.FastBeyond360);
            goUser.transform.DOMoveX(-25, 4).OnComplete(() =>
            {
                if (_bClearGame)
                {
                    btnExtra.gameObject.SetActive(true);
                }
                btnStart.gameObject.SetActive(true);
                btnStart.transform.DOShakeScale(1, .5f).SetLoops(-1);
            });
            particleSystem.Play();
        }) /*.Pause()*/;

        // doScale.PlayForward();
    }
}

public enum E_ZenjectID
{
    Clear,
}