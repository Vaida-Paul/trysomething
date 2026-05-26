using Books.Models.DTOs;

namespace Books.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookReadDTO>> GetAllAsync(int userId);
        Task<BookReadDTO?> GetByIdAsync(int id, int userId);

        Task<BookReadDTO> CreateAsync(BookCreateDTO bookCreateDTO, int userId);
        Task<bool> UpdateAsync(int id, BookUpdateDTO bookUpdateDTO, int userId);
        Task<bool> DeleteAsync(int id, int userId);

    }
}
