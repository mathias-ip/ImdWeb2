define(['postman'], (postman) => {
    return function () {

        let gotoContact = () => {
            postman.publish("changeContent", "search");
        }

        return {
            gotoSearch
        };
    }
});

define(['knockout']), (ko) => {
    let names = ko.observableArray();

}

let getNames = (callback) => {
    fetch('search/{id}')
        .then(response => response.json())
        .then(callback);

};

getNames(x => {
    names(x)
    )

}