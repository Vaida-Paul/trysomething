using Books.Data;
using Books.Models.DTOs;
using Books.Models.Entities;
using Books.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Books.Services
{
    public class BookService : IBookService
    {
        private readonly BooksDbContext _dbContext;
        public BookService(BooksDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<BookReadDTO> CreateAsync(BookCreateDTO bookCreateDTO, int userId)
        {
            var book = new Book
            {
                Title = bookCreateDTO.Title,
                Author = bookCreateDTO.Author,
                Pages = bookCreateDTO.Pages,
                ImgUrl = bookCreateDTO.ImgUrl,
                UserId = userId

            };
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return new BookReadDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Pages = book.Pages,
                ImgUrl = book.ImgUrl
            };
        }

        

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);
            if (book == null)
            {
                return false;
            }
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        

        public async Task<List<BookReadDTO>> GetAllAsync(int userId)
        {
            return await _dbContext.Books.Where(b => b.UserId == userId).Select(b => new BookReadDTO
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Pages = b.Pages,
                ImgUrl = b.ImgUrl
            }).ToListAsync();
        }

       

        public async Task<BookReadDTO?> GetByIdAsync(int id, int userId)
        {
            return await _dbContext.Books.Where(b => b.Id == id && b.UserId == userId).Select(b => new BookReadDTO
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Pages = b.Pages,
                ImgUrl = b.ImgUrl
            }).FirstOrDefaultAsync();
        }

        

        public async Task<bool> UpdateAsync(int id, BookUpdateDTO bookUpdateDTO, int userId)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);
            if (book == null)
            {
                return false;
            }

            book.Title = bookUpdateDTO.Title;
            book.Author = bookUpdateDTO.Author;
            book.Pages = bookUpdateDTO.Pages;
            book.ImgUrl = bookUpdateDTO.ImgUrl;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        
    }
}
