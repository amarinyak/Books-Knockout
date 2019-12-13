"use strict";

extend(booksApp, {
	config: {
		errors: (function() {
			return {
				initAjaxErrors: function() {
					$(document).ajaxError(function(e, xhr) {
						if (xhr.responseJSON) {
							alert(xhr.responseJSON.exceptionMessage);
						} else {
							alert(xhr.statusText);
						}
					});
				}
			}
		})()
	}
});