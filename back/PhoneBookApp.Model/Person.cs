namespace PhoneBookApp.Model;

/// <summary>
/// Класс для хранения информации о человеке в базе данных
/// </summary>
public class Person
{
    /// <summary>
    /// Идентификатор записи в БД
    /// </summary>
    public int Id {get; set;}
    
    /// <summary>
    /// Фамилия человека
    /// </summary>
    public required string LastName {get; set;}
    
    /// <summary>
    /// Имя человка
    /// </summary>
    public required string FirstName {get; set;}
    
    /// <summary>
    /// Признак удаленной персоны из базы
    /// </summary>
    public bool IsDeleted { get; set; } = false;
}