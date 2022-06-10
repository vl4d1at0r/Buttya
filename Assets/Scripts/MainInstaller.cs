using System.Collections.Generic;
using Zenject;

public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<List<CelestialBody>>().AsSingle();
    }
}
