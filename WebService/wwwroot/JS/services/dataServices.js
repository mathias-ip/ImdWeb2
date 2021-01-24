
define([], () => {
    const movieApiUrl = "search/search/";
    const nameApiUrl = "search/name/";
    let getJson = (url, callback) => {

        fetch(url).then(response => response.json()).then(callback);

    };

    let getSearchMovies = (url, id2, callback) => {

        if (url === undefined) {
            url = movieApiUrl + id2;
        }
        console.log(url);
        getJson(url, callback);
    };



    let getSearchNames = (url, id2, callback) => {

        if (url === undefined) {
            url = nameApiUrl + id2;
        }
        console.log(url);
        getJson(url, callback);
    };

    let getSearchNamesUrlWithPageSize = (size, arg) => {
        return nameApiUrl + arg + "?pageSize=" + size;
    }
    let getSearchMoviesUrlWithPageSize = (size, arg) => {
        return movieApiUrl + arg + "?pageSize=" + size;
    }

    let verifyUser = (username, password, callback) => {
        fetch('api/Users/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ username, password }),
        }).
            then(response => {
                if (response.status === 404) return undefined;
                return response.json();

            }).then(callback);


    }

    return {
        getSearchNames,
        getSearchMovies,
        getSearchNamesUrlWithPageSize,
        getSearchMoviesUrlWithPageSize,
        verifyUser
    };
});