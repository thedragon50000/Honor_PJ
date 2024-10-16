using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class Ending_sc : MonoBehaviour
{
    [Inject] private AudioManager _audioManager;
    [Inject] private ZenjectSceneLoader _sceneLoader;
    private bool bClear = true;
    
    public Text txtStaff;

    // Start is called before the first frame update
    void Start()
    {
        _audioManager.PlayBGM(E_BGM.Ending.ToString());
        txtStaff.rectTransform.DOMoveY(4200, 70).OnComplete(() => _sceneLoader.LoadScene(0, LoadSceneMode.Single,
            container => container.BindInstance(bClear).WithId(E_ZenjectID.Clear.ToString())));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _sceneLoader.LoadScene(0, LoadSceneMode.Single,
                container => container.BindInstance(bClear).WithId(E_ZenjectID.Clear.ToString())
            );
        }
    }
}