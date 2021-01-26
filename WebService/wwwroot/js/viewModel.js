define(['knockout', 'postman'], (ko, postman) => { 
    let currentComponent = ko.observable("home");
    let user = ko.observable();
 
    let menuElements = ["Signup", "Login", "Home", "Profile", "Search"]; //menuer i navigationsmappen
    let changeContent = element => {
        
        currentComponent(element.toLowerCase());
    }

    let isActive = element => {
        return element.toLowerCase() === currentComponent() ? "active" : ""; //Hvilket element er aktivt, 
    }

    postman.subscribe("changeContent", component => {
        changeContent(component);

       


    });

    return {
        currentComponent,
        menuElements,
        changeContent,
        isActive,
        user
    };
});