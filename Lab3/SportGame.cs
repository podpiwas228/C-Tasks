//Вариант 8. Спортивные игры
//Область: Спорт
//Описание: Создать абстрактный класс SportGame, который будет содержать метод PlayGame().
//Наследники класса могут быть FootballGame, BasketballGame, TennisGame.
//Каждый класс реализует метод PlayGame(), который описывает правила игры.
abstract class SportGame 
{
    public abstract string PlayGame();
}
