var BookEditViewModel = function(book, successCallback) {
    var self = this;

    self.myBook = book;
    self.isEditMode = self.myBook != null;
    self.title = self.isEditMode
	    ? resources.appUI.editBook
	    : resources.appUI.addBook;

    if (self.isEditMode) {
	    self.book = new BookViewModel(ko.toJS(self.myBook));
    } else {
	    self.book = new BookViewModel({});
	    self.book.authors.push(new AuthorViewModel({}));
    }

    self.save = function (bookEdit) {
        if (bookEdit.book.isValid()) {
	        BooksDataService.saveOrUpdate(bookEdit.book, successCallback);
        }
    }
}