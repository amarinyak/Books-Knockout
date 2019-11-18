"use strict";

$(function () {
	ErrorsConfig.initAjaxErrors();
	ValidationConfig.initRules();

	BooksViewModelInitializer.init();
});