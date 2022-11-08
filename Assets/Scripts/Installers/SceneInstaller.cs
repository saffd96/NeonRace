using UnityEngine;
using Zenject;

namespace Installers
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        [SerializeField] private PlatformsController platformsController;

        public override void InstallBindings()
        {
            Container.Bind<PlatformsController>().FromInstance(platformsController).AsSingle();
        }
    }
}
