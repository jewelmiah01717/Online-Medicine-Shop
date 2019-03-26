/// <reference path="../app/app.js" />


app.factory('omsSvc', function ($resource) {


    var odataUrlCompany = "http://localhost:5609/odata/Companies";
    var odataUrlGenericName = "http://localhost:5609/odata/Generics";
    var odataUrlDosageFormat = "http://localhost:5609/odata/DosageFormats";
    var odataUrlPurchase = "http://localhost:5609/odata/Purchases";
    var odataUrlStock = "http://localhost:5609/odata/Stocks";
    var odataUrlOrder = "http://localhost:5609/odata/Orders";
    var odataUrlOrderDetails = "http://localhost:5609/odata/OrderDetails";
    var odataUrlCustomer = "http://localhost:5609/odata/Customers";
    
    var ApiUrlProductView = "http://localhost:8430/api/vw_ViewProducts";
    var ApiUrlSaleDetail = "http://localhost:8430/api/vw_SaleDetail";

    
    return $resource("", {}, {
        //Company
        'getallCompany': { method: 'GET', url: odataUrlCompany },
        'saveCompany': { method: 'POST', url: odataUrlCompany },
        'updateCompany': { method: 'PUT', params: { key: "@key" }, url: odataUrlCompany + "(:key)" },
        'searchCompany': { method: 'GET', params: { key: "@key" }, url: odataUrlCompany + "(:key)" },
        'deleteCompany': { method: 'DELETE', params: { key: "@key" }, url: odataUrlCompany + "(:key)" },

        //DosageFormat
        'getallDosageFormat': { method: 'GET', url: odataUrlDosageFormat },
        'saveDosageFormat': { method: 'POST', url: odataUrlDosageFormat },
        'updateDosageFormat': { method: 'PUT', params: { key: "@key" }, url: odataUrlDosageFormat + "(:key)" },
        'searchDosageFormat': { method: 'GET', params: { key: "@key" }, url: odataUrlDosageFormat + "(:key)" },
        'deleteDosageFormat': { method: 'DELETE', params: { key: "@key" }, url: odataUrlDosageFormat + "(:key)" },

        //GenericName
        'getallGenericName': { method: 'GET', url: odataUrlGenericName },
        'saveGenericName': { method: 'POST', url: odataUrlGenericName },
        'updateGenericName': { method: 'PUT', params: { key: "@key" }, url: odataUrlGenericName + "(:key)" },
        'searchGenericName': { method: 'GET', params: { key: "@key" }, url: odataUrlGenericName + "(:key)" },
        'deleteGenericName': { method: 'DELETE', params: { key: "@key" }, url: odataUrlGenericName + "(:key)" },

        //Purchase
        'getallPurchase': { method: 'GET', url: odataUrlPurchase },
        'savePurchase': { method: 'POST', url: odataUrlPurchase },
        'updatePurchase': { method: 'PUT', params: { key: "@key" }, url: odataUrlPurchase + "(:key)" },
        'searchPurchase': { method: 'GET', params: { key: "@key" }, url: odataUrlPurchase + "(':key')" },
        'deletePurchase': { method: 'DELETE', params: { key: "@key" }, url: odataUrlPurchase + "(:key)" },

        //Customer
        'getallCustomer': { method: 'GET', url: odataUrlCustomer },
        'saveCustomer': { method: 'POST', url: odataUrlCustomer },
        'updateCustomer': { method: 'PUT', params: { key: "@key" }, url: odataUrlCustomer + "(:key)" },
        'searchCustomer': { method: 'GET', params: { key: "@key" }, url: odataUrlCustomer + "(:key)" },
        'deleteCustomer': { method: 'DELETE', params: { key: "@key" }, url: odataUrlCustomer + "(:key)" },


        //Stock
        'getallStock': { method: 'GET', url: odataUrlStock },

        //Order
        'getallOrder': { method: 'GET', url: odataUrlOrder },
        'saveOrder': { method: 'POST', url: odataUrlOrder },

        //OrderDetails
        'getallOrderDetail': { method: 'GET', url: odataUrlOrderDetails },
        'saveOrderDetail': { method: 'POST', url: odataUrlOrderDetails },

        //ProductView
        'getallProductView': { method: 'GET', url: ApiUrlProductView },
        //SalesView
        'getallSalesView': { method: 'GET', url: ApiUrlSaleDetail },
               
    });
});