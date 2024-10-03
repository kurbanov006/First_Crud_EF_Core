using Infrastructure.Models;

namespace Infrastructure.Services;

public interface IBookService
{
    Task<bool> Create(Book book);
    Task<bool> Update(Book book);
    Task<bool> Delete(int id);
    Task<Book?> GetById(int id);
    Task<IEnumerable<Book?>> GetAll();
}