define(['postman', 'knockout' 'viewModel' 'dataservice'], (postman, ko, vm, ds) => {
    return function (params) {

        let username = ko.observable();
        let password = ko.observable();
        let email = ko.observable();

        let createUser = () => {

            let user = {
                username: username();
                password: password();
                email: email();

            };
            ds.createUser(user, (newUser) => {
                if (newUser == undefined) {
                    alert('not correctly signed in');
                    username('');
                    password('');
                    email('');
                }

                else {
                    alert('you are signed in')
                    vm.changeContent('Login');

                }

            });

        };


        return {
            username,
            password,
            email,
            createUser
        };
    }
});