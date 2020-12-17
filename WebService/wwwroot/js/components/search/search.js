define(['postman', 'knockout', 'dataServices'], (postman, ko, dataServices) => {
    return function () {
        let pageSizes = ko.observableArray();
        let selectedPageSize = ko.observableArray([10]);
        let prev = ko.observable();
        let next = ko.observable();
        let movieSearch = ko.observable(false);
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
        let getMovie = url => {
            movieSearch(true);
            names([]);
            dataServices.getSearchMovies(url, id2(), data => {
                pageSizes(data.pageSizes);
                prev(data.prev || undefined);
                next(data.next || undefined);
                movies(data.searchitems);
                console.log("movie");
            });
        }

        let getName = url => {
            movieSearch(false);
            movies([]);
            dataServices.getSearchNames(url, id(), data => {
                pageSizes(data.pageSizes);
                prev(data.prev || undefined);
                next(data.next || undefined);
                names(data.searchitems);
                console.log("movie");
            });
        }

        let searchMovie = () => getMovie();
        let searchName = () => getName();

        //let paging beging with previes side
        let showPrev = movies => {
            if (movieSearch()) {
                getMovie(prev());
            }
            else {
                getName(prev());
            }
        
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        //let paging beging with next side 
        let showNext = movies => {
            if (movieSearch()) {
                getMovie(next());
            }
            else
            {
                getName(next());
            }
            console.log(next());
           
        }

        let enableNext = ko.computed(() => next() !== undefined);


        selectedPageSize.subscribe(() => {
            var size = selectedPageSize()[0];
            if (movieSearch()) {
                getMovie(dataServices.getSearchMoviesUrlWithPageSize(size, id2()));
            }

            else {
                getName(dataServices.getSearchNamesUrlWithPageSize(size, id()));
            }
        });
        

        return {
            gotoContact,
            names,
            id,
            getNames,
            getMovie,
            movies,
            id2,
            gotoContact2,
            pageSizes,
            selectedPageSize,
            showPrev,
            enablePrev,
            showNext,
            enableNext,
            next,
            searchMovie,
            getName,
            searchName,
            movieSearch
        };
    }
   
});





