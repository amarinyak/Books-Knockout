"use strict";

var TableHeaderViewModel = function(title, sortField) {
    var self = this;

    self.title = title;
    self.sortField = sortField;

    self.canSort = ko.pureComputed(function() {
	    return self.sortField != null;
    });
}