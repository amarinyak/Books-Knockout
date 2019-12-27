"use strict";

extend(booksApp, {
    config: {
        errors: (function () {
            return {
                initAjaxErrors: function () {
                    $(document).ajaxError(function (e, xhr) {
                        if (xhr.responseJSON) {
                            alert(JSON.stringify(xhr.responseJSON));
                        } else {
                            alert(xhr.statusText);
                        }
                    });
                }
            }
        })()
    }
});