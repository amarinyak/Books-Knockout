var Site = (function () {
    return {
        initAjaxErrors: function() {
            $(document).ajaxError(function (e, xhr) {
                alert(xhr.responseJSON.error);
            });
        }
    }
})();

$(function () {
    Site.initAjaxErrors();
	ValidationService.initRules();
});