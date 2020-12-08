/// <reference path="../css/lib/twitter-bootstrap/js/bootstrap.min.js" />
/// <reference path="lib/require.js/require.min.js" />
/// <reference path="lib/jquery/jquery.min.js" />
require.config({
    baseUrl: "js",
    paths: {
        knockout: "lib/knockout/knockout-latest.debug",
        text: "lib/require-text/text.min",
        jquery: "lib/jquery/jquery.min",
        bootstrap: "../css/lib/twitter-bootstrap/js/bootstrap.bundle.min",
        postman: "services/postman"
    },
    shim: {
        bootstrap: ['jquery']
    }
});

require(['knockout', 'text'], (ko) => {
    ko.components.register('home', {
        viewModel: { require: "components/home/home" },
        template: { require: "text!components/home/home.html" }
    });

    ko.components.register('profile', {
        viewModel: { require: "components/profile/profile" },
        template: { require: "text!components/profile/profile.html" }
    });
    ko.components.register('search', {
        viewModel: { require: "components/search/search" },
        template: { require: "text!components/search/search.html" }
    });
       ko.components.register('login', {
        viewModel: { require: "components/login/login" },
        template: { require: "text!components/login/login.html" }
    });
});



require(['knockout', 'viewModel', 'bootstrap'], (ko, vm) => {
    ko.applyBindings(vm);
});