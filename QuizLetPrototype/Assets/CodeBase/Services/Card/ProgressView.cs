using CodeBase.Services.Card;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ProgressView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI progressText;
    private List<CardModel> _cards;
    private int _currentIndex;
    private int _completedCount;
    private int _correctAnswers;  // Счетчик правильных ответов

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        _cards = new List<CardModel>();
        _currentIndex = 0;
        _completedCount = 0;
        _correctAnswers = 0;
        ShowCard();
        UpdateProgress();
    }

    public void OnCardClicked()
    {
        if (_cards.Count == 0) return;

        _completedCount++;
        _currentIndex = (_currentIndex + 1) % _cards.Count;
        ShowCard();
        UpdateProgress();
    }

    // Обработчик правильного ответа
    public void OnCorrectAnswer()
    {
        _correctAnswers++;
        UpdateProgress();
    }

    private void ShowCard()
    {
        if (_cards.Count == 0) return;

        var currentCard = _cards[_currentIndex];
        // Логика отображения карты, например:
        // Выводим определение на экране
        // questionText.text = currentCard.Definition;
    }

    private void UpdateProgress()
    {
        progressText.text = $"Прогресс: {_correctAnswers}";
    }
}



public class ProgressManager
{
    private const string ProgressFileName = "progress.json";

    public void SaveProgress(int correctAnswers, List<CardModel> cards)
    {
        var progressData = new ProgressData
        {
            CorrectAnswers = correctAnswers,
            Cards = cards
        };

        string json = JsonUtility.ToJson(progressData);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, ProgressFileName), json);
    }

    public ProgressData LoadProgress()
    {
        string filePath = Path.Combine(Application.persistentDataPath, ProgressFileName);

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<ProgressData>(json);
        }

        return new ProgressData();  // Если нет данных, возвращаем пустой прогресс
    }
}

[System.Serializable]
public class ProgressData
{
    public int CorrectAnswers;
    public List<CardModel> Cards;
}
