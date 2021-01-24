define(['postman', 'knockout', 'viewModel'], (postman, ko, vm) => {
    return function (params) {


        //laver variable navne til login
        let username = ko.observable();
        let password = ko.observable();
        let email = ko.observable();


        //krav til user i form af brugernavn, password og email
        let createUser = () => {
            let user = {
                username: username(),
                password: password(),
                email: email()

            };


                //Sender dataen tilbage til datalaget ved hjælp af post
                fetch('user/CreateUser/', {
                    method: 'POST',
                    body: JSON.stringify(user),
                headers: {

                    'Content-Type': 'application/json;charset=UTF-8'
                }
            
                });
            vm.changeContent("Home");

        };
        return {
            username,
            password,
            email,
            createUser
        };
    }
});