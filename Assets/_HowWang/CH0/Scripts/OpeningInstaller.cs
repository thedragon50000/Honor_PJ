using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "OpeningInstaller", menuName = "Installers/OpeningInstaller")]
public class OpeningInstaller : ScriptableObjectInstaller<OpeningInstaller>
{
    public bool bClearGame;
    
    public override void InstallBindings()
    {
        string s = E_ZenjectID.Clear.ToString();
        Container.BindInstance(bClearGame).WithId(s).IfNotBound();
    }
    
}