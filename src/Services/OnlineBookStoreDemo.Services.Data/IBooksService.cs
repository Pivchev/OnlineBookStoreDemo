namespace OnlineBookStoreDemo.Services.Data
{
    using System.Collections.Generic;

    using OnlineBookStoreDemo.Services.Models.Books;

    public interface IBooksService
    {
        IEnumerable<BookSimpleViewModel> GetAllBooks();

        BookDetailsViewModel GetBookById(int id);

        IEnumerable<BookSimpleViewModel> GetBooksByCategoryId(int categoryId);

        IEnumerable<BookSimpleViewModel> GetBooksBySearchModel(BooksSearchModel searchModel);
    }
}
