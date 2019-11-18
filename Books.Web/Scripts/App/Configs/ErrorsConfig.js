"use strict";

var ErrorsConfig = (function() {
	return {
		initAjaxErrors: function() {
			$(document).ajaxError(function (e, xhr) {
				alert(xhr.responseJSON.error);
			});
		}
	}
})();