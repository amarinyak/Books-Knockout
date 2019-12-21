"use strict";

var booksApp = booksApp || {};

$(function () {
	var appConfigData = $("#AppConfigData").val();

	booksApp.config.errors.initAjaxErrors();
	booksApp.config.validation.initRules();

	booksApp.appConfigInitializer.init(JSON.parse(appConfigData)).done(function () {
		var booksTable = $(".js-books-table");
		var editModal = $(".js-books-edit-modal");

		var urlSearchParams = new URLSearchParams(window.location.search);
		var sortField = urlSearchParams.get("sortField") || booksApp.appConfig.defaultSortOrder;
		var descSort = urlSearchParams.get("descSort") || booksApp.appConfig.defaultDescSort;

		booksApp.services.booksViewModelInitializer.init(booksTable, editModal, sortField, descSort);
	});
});