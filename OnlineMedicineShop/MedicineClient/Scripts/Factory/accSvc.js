/// <reference path="../app/app.js" />


app.factory('accSvc', function ($resource) {
    var userUrl = "http://localhost:5609/odata/UserDetails/";

    return $resource("", {}, {
        'signUpUser': { method: "POST", url: userUrl },




    });
});
