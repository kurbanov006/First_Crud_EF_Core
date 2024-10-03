using Infrastructure.DataContext;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BookService : IBookService
{
    private readonly AppDbContext dbContext;

    public BookService(AppDbContext _dbContext)
    {
        dbContext = _dbContext;
    }
    
    
    public async Task<bool> Create(Book book)
    {
        try
        {
            if (book == null!)
            {
                Console.WriteLine($"Book is null");
                return false;
            }
            
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw; 
        }
    }

    public async Task<bool> Update(Book book)
    {
        try
        {
            if (book == null!)
            {
                Console.WriteLine("Book is null");
                return false;
            }

            Book? res = await dbContext.Books.FindAsync(book.Id);
            if (res == null)
            {
                Console.WriteLine("Не удалось найти книгу!");
                return false;
            }

            res.Author = book.Author;
            res.Title = book.Title;
            res.Description = book.Description;
            
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            if (id == null)
            {
                Console.WriteLine("Введите корректный id");
                return false;
            }

            Book? book = await dbContext.Books.FindAsync(id);
            if (book == null)
            {
                Console.WriteLine("Не удалось найти книгу!");
                return false;
            }
            
            dbContext.Books.Remove(book);
            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Book?> GetById(int id)
    {
        try
        {
            if(id == null)
            {
                Console.WriteLine($"Введите корректный id");
                return null;
            }

            Book? book = await dbContext.Books.FindAsync(id);
            return book;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Book?>> GetAll()
    {
        try
        {
            return await dbContext.Books.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}