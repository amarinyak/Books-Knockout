var BooksViewModel = function (sortField, descSort) {
    var self = this;

    var booksTable = $(".js-books-table");
    self.editModal = $(".js-books-edit-modal");
    self.editModel = ko.observable();
    
    self.books = ko.observableArray();
    self.visible = ko.observable(false);

    self.headers = ko.observableArray();
    self.sortField = ko.observable(sortField);
    self.descSort = ko.observable(descSort);

    self.getBooks = function () {
        BooksDataService.getList(function (data) {
            self.updateBooks(data.books);
            self.visible(true);
        });
    }

    self.updateBooks = function (books) {
        ko.utils.arrayForEach(books, function (book) {
            var isExists = false;

            for (var i = 0; i < self.books().length; i++) {
                var myBook = self.books()[i];

                if (book.id === myBook.id()) {
                    myBook.update(book);
                    isExists = true;
                }
            }

            if (!isExists) {
	            self.books.push(new BookViewModel(book));
            }
        });

        sortBooks(self.sortField(), self.descSort());
    }

    self.apply = function() {
        ko.applyBindings(self, booksTable[0]);
    }

    self.initHeaders = function () {
        self.headers.push(new TableHeaderViewModel(resources.appUI.cover));
        self.headers.push(new TableHeaderViewModel(resources.appUI.title, true, "title"));
        self.headers.push(new TableHeaderViewModel(resources.appUI.author));
        self.headers.push(new TableHeaderViewModel(resources.appUI.pageCount));
        self.headers.push(new TableHeaderViewModel(resources.appUI.year, true, "year"));
        self.headers.push(new TableHeaderViewModel(resources.appUI.publisher));
        self.headers.push(new TableHeaderViewModel(resources.appUI.isbn));
        self.headers.push(new TableHeaderViewModel(""));
    }

    self.sort = function (tableHeader) {
        if (!tableHeader.canSort) return;

        if (self.descSort() === true || self.sortField() !== tableHeader.sortField) self.descSort(false);
        else self.descSort(true);

        self.sortField(tableHeader.sortField);
        sortBooks(tableHeader.sortField, self.descSort());

        history.replaceState({
            sortField: tableHeader.sortField,
            descSort: self.descSort()
        }, null, "?sortField=" + tableHeader.sortField + "&descSort=" + self.descSort());
    }

    self.delete = function (book) {
        BooksDataService.delete(book, function () {
            self.books.remove(book);
        });
    }

    self.edit = function (book) {
        openEditModal(book);
    }

    self.create = function () {
        openEditModal(null);
    }

    function openEditModal(book) {
        self.editModel(new BookEditViewModel(book, createOrUpdateCallBack));
        self.editModal.modal("show");
    }

    function createOrUpdateCallBack(data) {
        BooksDataService.getById(data.bookId, getByIdCallback);
        closeEditModal();
    }

    function getByIdCallback(data) {
        self.updateBooks([data.book]);
    }

    function closeEditModal() {
        self.editModal.modal("hide");
    }

    function sortBooks(sortField, descSort) {
        self.books.sort(function (l, r) {
            return l[sortField]() === r[sortField]()
                ? 0
                : l[sortField]() < r[sortField]()
                    ? descSort ? 1 : -1
                    : descSort ? -1 : 1;
        });
    }
}