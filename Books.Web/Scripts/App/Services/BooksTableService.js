var BooksTableService = (function () {
    return {
        init: function () {
	        var sortField = $("#SortField").val();
	        var descSort = $("#DescSort").val() === "true";

            var model = new BooksViewModel(sortField, descSort);
            model.initHeaders();
            model.getBooks();
            model.apply();
        }
    }
})();