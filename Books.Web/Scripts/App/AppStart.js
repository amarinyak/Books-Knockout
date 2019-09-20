var Site = (function () {
    return {
        initValidation: function() {
            ko.validation.locale("ru-RU");

            ko.validation.rules["checkIsbn"] = {
                validator: function (val, enabled) {
                    if (!enabled) return true;
                    return ValidationService.checkIsbn(val);
                },
                message: "Неправильный номер ISBN"
            };
            ko.validation.registerExtenders();
        },
        initAjaxErrors: function() {
            $(document).ajaxError(function (e, xhr) {
                alert(xhr.responseJSON.error);
            });
        }
    }
})();

$(function () {
    Site.initValidation();
    Site.initAjaxErrors();
});