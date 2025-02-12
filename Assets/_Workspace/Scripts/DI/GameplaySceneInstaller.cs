using InventorySystem;
using Zenject;
using UnityEngine;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField]
    private StickInput _stickInput;
    [SerializeField]
    private TapPanel _tapPanel;

    public override void InstallBindings()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Container.Bind<IInputRotation>().To<MouseInput>().FromNew().AsSingle();
            Container.Bind<IInput>().To<KeyboardInput>().FromNew().AsSingle();
        }
        else
        {
            Container.Bind<IInputRotation>().To<MouseInput>().FromNew().AsSingle();
            Container.Bind<IInput>().To<KeyboardInput>().FromNew().AsSingle();
        }

        Container.Bind<CharacterMovement>().AsSingle();
        Container.Bind<Inventory>().AsSingle();
        Container.Bind<CameraRotation>().AsSingle();
    }
}