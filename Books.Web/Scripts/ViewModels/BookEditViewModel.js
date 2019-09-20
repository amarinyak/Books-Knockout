var BookEditViewModel = function(book, successCallback) {
    var self = this;

    self.myBook = book;
    self.isCreateMode = self.myBook == null;
    self.title = self.isCreateMode ? "Добавить книгу" : "Редактировать книгу";

    if (self.isCreateMode) {
        self.book = new BookViewModel({});
        self.book.authors.push(new AuthorViewModel({}));
    } else {
        self.book = new BookViewModel(ko.toJS(self.myBook));
    }

    self.save = function (bookEdit) {
        if (!bookEdit.book.isValid()) return;

        BooksDataService.saveOrUpdate(bookEdit.book, successCallback);
    }
}