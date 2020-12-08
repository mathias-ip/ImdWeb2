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

        //getNames();

        

        return {
            gotoContact,
            names,
            id,
            getNames
        };
    }
});





