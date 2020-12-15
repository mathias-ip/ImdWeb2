define(['postman','knockout'], (postman, ko) => {
    return function () {
        
        let names = ko.observableArray();
        let gotoContact = () => {
            postman.publish("changeContent", "search");
        }

        let id = ko.observable();
        let getNames = () => {
            fetch('api/Titles/search/' + id())
                .then(response => response.json())
                .then(names);


        };
        let movies = ko.observableArray();
        let gotoContact2 = () => {
            postman.publish("changeContent", "search2");
        }

        let id2 = ko.observable();
        let getMovie = () => {
            fetch('api/Titles/name/' + id2())
                .then(response => response.json())
                .then(movies);
            


        };

        

        return {
            gotoContact,
            names,
            id,
            getNames,
            getMovie,
            movies,
            id2
        };
    }
});





