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