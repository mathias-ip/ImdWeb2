define(['postman'], (postman) => {
    return function () {

        let gotoContact = () => {
            postman.publish("changeContent", "contact");
        }

        return {
            gotoContact
        };
    }
});