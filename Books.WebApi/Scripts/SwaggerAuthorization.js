(function () {
	var inputApiKey = $("#input_apiKey");
	var inputToken = $('<input placeholder="token" id="input_token" type="text" />');
	inputToken.change(function () {
		var token = "Basic " + inputToken.val();
		var apiKeyAuth = new SwaggerClient.ApiKeyAuthorization("Authorization", token, "header");
		window.swaggerUi.api.clientAuthorizations.add("key", apiKeyAuth);
	});
	inputApiKey.after(inputToken);
	inputApiKey.remove();
})();