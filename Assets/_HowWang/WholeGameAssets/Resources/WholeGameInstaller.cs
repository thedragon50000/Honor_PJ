using UnityEngine;
using Zenject;

public class WholeGameInstaller : MonoInstaller
{
    public AudioManager audio;
    
    public override void InstallBindings()
    {
        //綁定全局的AudioManager
        Container.Bind<AudioManager>().FromComponentInNewPrefab(audio).AsSingle().NonLazy();
        
    }
}