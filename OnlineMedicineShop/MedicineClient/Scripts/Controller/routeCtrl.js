/// <reference path="../angular.js" />


//Angular.JS Routing
app.config(function ($routeProvider) {
    $routeProvider.
    when('/admin', { templateUrl: '/AdminDashBoard.html', controller: 'accCtrl' }).
    when('/com', { templateUrl: '/Tables/Company.html', controller: 'omsCtrl' }).
    when('/dof', { templateUrl: '/Tables/DosageFormat.html', controller: 'omsCtrl' }).
    when('/gen', { templateUrl: '/Tables/Generic.html', controller: 'omsCtrl' }).
    when('/pur', { templateUrl: '/Tables/Purchase.html', controller: 'omsCtrl' }).
    when('/sto', { templateUrl: '/Tables/Stock.html', controller: 'omsCtrl' }).
    when('/odtls', { templateUrl: '/Tables/Orderdetails.html', controller: 'omsCtrl' }).
    when('/sldtls', { templateUrl: '/Pages/SalesView.html', controller: 'omsCtrl' }).
    when('/ordr', { templateUrl: '/Tables/Order.html', controller: 'omsCtrl' }).
    when('/pStore', { templateUrl: '/Pages/ProductStore.html', controller: 'omsCtrl' }).
    when('/sPrd', { templateUrl: '/Pages/Product.html', controller: 'omsCtrl' }).
    when('/home', { templateUrl: '/Home.html', controller: 'omsCtrl' }).
    otherwise({ redirectTo: '/home' });
    
});