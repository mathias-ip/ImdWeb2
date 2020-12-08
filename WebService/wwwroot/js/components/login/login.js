define(['postman'], (postman) => {
    return function () {

        let gotoContact = () => {
            postman.publish("changeContent", "login");
        }

        return {
            gotoLogin
        };
    }
});