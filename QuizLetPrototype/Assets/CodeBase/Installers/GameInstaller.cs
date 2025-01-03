using CodeBase.Services.Card;
using CodeBase.UI;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public ReviewWindow reviewWindowPrefab;
    public TestModeWindow testModeWindowPrefab;  // ��������� TestModeWindow
    public WriteModeWindow writeModeWindowPrefab;
    //[SerializeField] private ProgressView progressViewPrefab;
    //private CardPresenter _cardPresenter;
    public override void InstallBindings()
    {
       // Container.Bind<CardPresenter>().AsSingle();
        Container.Bind<ICardManager>().To<CardService>().AsSingle();
        //ProgressView progressView = Container.InstantiatePrefabForComponent<ProgressView>(progressViewPrefab);
        // Container.Bind<ProgressView>().FromInstance(progressViewPrefab).AsSingle();

        
        // ������� � ����������� CardPresenter
       
        Container.Bind<ReviewWindow>().FromComponentInNewPrefab(reviewWindowPrefab).AsSingle();

        Container.Bind<TestModeWindow>().FromComponentInNewPrefab(testModeWindowPrefab).AsTransient(); // ����������� TestModeWindow
        Container.Bind<WriteModeWindow>().FromComponentInNewPrefab(writeModeWindowPrefab).AsSingle();
    }
}

