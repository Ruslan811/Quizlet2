using static Unity.VisualScripting.Icons;

namespace CodeBase.Services.Card
{
    public class CardModel
    {
        public string Term { get; private set; }  // Термин
        public string Definition { get; private set; }  // Определение
        public bool IsFlipped { get; private set; }  // Статус переворота
        public Language Language { get; private set; }
        public CardModel(string term, string definition, Language language)
        {
            Term = term;
            Definition = definition;
            IsFlipped = false;  // По умолчанию карточка не перевернута
            Language = language;
        }

        // Метод для переворота карточки
        public void FlipCard()
        {
            IsFlipped = !IsFlipped;  // Переворачиваем состояние
        }
    }
}
