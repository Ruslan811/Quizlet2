using System.Collections.Generic;

namespace CodeBase.Services.Card
{
    public class CardService : ICardManager
    {
        private List<CardModel> _cards = new List<CardModel>();
        private Language _currentLanguage;

        public void SetLanguage(Language language)
        {
            _currentLanguage = language;
        }

        public void CreateCard(string term, string definition, Language language)
        {
            _cards.Add(new CardModel(term, definition, language));
        }

        public void DeleteCard(string term)
        {
            _cards.RemoveAll(card => card.Term == term);
        }

        public List<CardModel> GetAllCards()
        {
            return _cards;
        }

        public bool IsCardCompleted(CardModel card)
        {
            // Для примера всегда возвращаем false
            return false;
        }
    }

    public interface ICardManager
    {
        void CreateCard(string term, string definition, Language language);
        void DeleteCard(string term);
        List<CardModel> GetAllCards();
        bool IsCardCompleted(CardModel card);  // Добавлен метод для проверки завершенности
        void SetLanguage(Language language);
    }

}

public enum Language
{
    English,
    Russian
}

