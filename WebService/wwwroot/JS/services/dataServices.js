
define([], () => {
    const movieApiUrl = "api/Titles/search/";
    const nameApiUrl = "api/Titles/name/";
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

    return {
        getSearchNames,
        getSearchMovies,
        getSearchNamesUrlWithPageSize,
        getSearchMoviesUrlWithPageSize
    };
});