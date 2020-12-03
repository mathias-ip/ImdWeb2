"use strict";

function LoginModel() {
	var self = this;

	self.username = ko.observable();
	self.password = ko.observable();
	self.message = ko.observable();
	self.loggingIn = ko.observable(false);

	this.init = function () {
	};

	this.login = function () {

		var token = null;

		var requestData = {
			grant_type: "password",
			username: self.username(),
			password: self.password()
		};

		self.loggingIn(true);
		$.ajax({
			type: 'POST',
			url: 'oauth/token',
			dataType: 'json',
			data: requestData,
			beforeSend: function (xhr) {
				xhr.setRequestHeader("Authorization", 'basic ' + btoa("app:"));
			},
			success: function (data, status, xhr) {
				console.log(data);
				localStorage.setItem("pro2olAuthToken", JSON.stringify(data));
				navModel.init();
				window.location.hash = "/"
			},
			error: function (data) {
				self.loggingIn(false);
				if (data.responseText) {
					self.message(JSON.parse(data.responseText).error_description);
				} else {
					self.message("Login failed");
				}
			},
			async: false,
			jsonp: false
		});

	}

};

LoginModel.inherits(BaseViewModel);
var loginModel = new LoginModel();
loginModel.init();
ko.applyBindings(loginModel, $('#loginContent')[0]);
