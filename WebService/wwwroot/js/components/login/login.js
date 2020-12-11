define(['postman', 'knockout'], (postman, ko) => {
    return function () {

        let gotoContact = () => {
            postman.publish("changeContent", "login");
        }

        return {
            gotoLogin
        };
    }
});