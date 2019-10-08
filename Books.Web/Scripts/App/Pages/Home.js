var Home = (function () {
    return {
        init: function () {
            BooksTableService.init();
        }
    }
})();

$(function () {
    Home.init();
    ValidationService.initRules();
});