using Setups;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private GameSettings gameSettings;

        public override void InstallBindings()
        {
            Container.Bind<GameSettings>().FromInstance(gameSettings).AsSingle();
        }
    }
}
