define(['postman','knockout'], (postman, ko) => {
    return function () {
        
        let names = ko.observableArray();
        let gotoContact = () => {
            postman.publish("changeContent", "search");
        }

        let id = ko.observable();
        let getNames = () => {
            console.log('api/Titles/search/' + id());
            fetch('api/Titles/search/' + id())
                .then(response => response.json())
                .then(names);


        };
        let movies = ko.observableArray();
        let id = ko.observable();
        let getMovie = () => {
            console.log('api/Titles/name/' + id());
            fetch('api/Titles/name/' + id())
                .then(response => response.json())
                .then(movies);


        };

        //getNames();

        

        return {
            gotoContact,
            names,
            id,
            getNames,
            getMovie,
            movies
        };
    }
});





