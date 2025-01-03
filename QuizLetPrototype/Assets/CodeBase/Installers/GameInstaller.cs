using CodeBase.Services.Card;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace CodeBase.UI
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject reviewWindowPrefab;
        [SerializeField] private GameObject testModeWindowPrefab;
        [SerializeField] private GameObject writeModeWindowPrefab;

        public override void InstallBindings()
        {
            Container.Bind<ICardManager>().To<CardService>().AsSingle();
            Container.Bind<ReviewWindow>().FromComponentInNewPrefab(reviewWindowPrefab).AsSingle();
            Container.Bind<TestModeWindow>().FromComponentInNewPrefab(testModeWindowPrefab).AsTransient();
            Container.Bind<WriteModeWindow>().FromComponentInNewPrefab(writeModeWindowPrefab).AsSingle();
        }
    }
}
