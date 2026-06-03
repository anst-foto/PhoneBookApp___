namespace PhoneBookApp.Model;

/// <summary>
/// Класс для хранения номера телефона в базе данных
/// </summary>
public class Phone
{
    /// <summary>
    /// Идентификатор записи в БД
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Ссылка на запись о человеке, которому принадлежит номер
    /// </summary>
    public int PersonId { get; set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public required string Number { get; set; }
}