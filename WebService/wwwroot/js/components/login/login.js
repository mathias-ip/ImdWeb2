define(['postman', 'knockout'], (postman, ko) => {
    return function (params) {


        let username = ko.observable();
        let password = ko.observable();
        let email = ko.observable();


        let createUser = () => {
            let user = {
                username: username(),
                password: password(),
                email: email()
            };


            fetch('api/Titles/CreateUser/', {
                method: 'POST',
                body: JSON.stringify(user),
                headers: {
                    
                    'Content-Type': 'application/json;charset=UTF-8'
                }

            });

<<<<<<< Updated upstream
            /*  ds.createUser(user, (newUser) => {
                  if (newUser == undefined) {
                      alert('not correctly signed in');
                      username('');
                      password('');
                      email('');
                  }
  
                  else {
                      alert('you are signed in')
                      vm.changeContent('Search');
  
                  }
  
              });*/
=======
          

>>>>>>> Stashed changes
        };

        return {
            username,
            password,
            email,
            createUser
        };
    }
});