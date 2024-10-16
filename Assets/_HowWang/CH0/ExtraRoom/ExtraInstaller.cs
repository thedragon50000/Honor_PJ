using UnityEngine;
using Zenject;
using Doublsb.Dialog;
public class ExtraInstaller : MonoInstaller
{
    public DialogManager dialogManager;
    public override void InstallBindings()
    {
        Container.BindInstance(dialogManager).AsSingle();
    }
}