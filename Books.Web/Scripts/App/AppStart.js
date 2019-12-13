"use strict";

var booksApp = booksApp || {};

$(function() {
	var apiUrl = $("#AppConfig_WebApiUrl").val();
	
	booksApp.config.errors.initAjaxErrors();
	booksApp.config.validation.initRules();
	
	booksApp.appConfigInitializer.init(apiUrl).done(function() {
		var booksTable = $(".js-books-table");
		var editModal = $(".js-books-edit-modal");

		var urlSearchParams = new URLSearchParams(window.location.search);
		var sortField = urlSearchParams.get("sortField") || booksApp.appConfig.sortOrderDefault;
		var descSort = urlSearchParams.get("descSort") || booksApp.appConfig.descSortDefault;

		console.log(sortField);

		booksApp.services.booksViewModelInitializer.init(booksTable, editModal, sortField, descSort);
	});
});