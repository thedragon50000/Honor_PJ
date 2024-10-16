using Doublsb.Dialog;
using UnityEngine;
using Zenject;

public class testerInstaller : MonoInstaller
{
    // public AudioManager audio;
    public DialogManager dialog;

    public override void InstallBindings()
    {
        Container.Bind<Tester_sc>().FromNewComponentOnNewGameObject().AsSingle();
        // Container.BindInstance(audio).AsSingle();
        Container.BindInstance(dialog).AsSingle();
        
        
        //這個用不用好像沒差
        // Container.Bind<GameInstall>().AsSingle().NonLazy();
    }

    //這個用不用好像沒差
    public class GameInstall : IInitializable
    {
        readonly AudioManager _audio;
        readonly DialogManager _dialog;

        public GameInstall(AudioManager audio, DialogManager dialog)
        {
            _audio = audio;
            _dialog = dialog;
        }

        public void Initialize()
        {
            print("This is Start void of Zenject");
        }
    }
}