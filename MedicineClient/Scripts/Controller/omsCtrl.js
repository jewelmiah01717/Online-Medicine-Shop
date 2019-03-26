/// <reference path="../app/app.js" />
/// <reference path="../Factory/omsSvc.js" />

app.controller('omsCtrl', function ($scope, omsSvc, $http) {
    
    //--------------- Shopping Cart -------------------------------
    $scope.cartItems = [];
    currentCart = {};
    var TotalPrice = 0;
    var TotalQuantity = 0;
    //--------------------------Decrement-------------------------------------
    $scope.Decrement = function (m) {
        currentCart.ProductId = m.ProductId;
        currentCart.ProductName = m.ProductName;
        currentCart.SaleQuantity = 1;
        currentCart.SalePrice = m.SalePrice;
        currentCart.mSalePrice = m.SalePrice;

        if ($scope.cartItems.length == 0) {
            $scope.cartItems.push(currentCart);
        }
        else {

            if (!decheck(currentCart.ProductId, 1))
                $scope.cartItems.push(currentCart);
        }

        currentCart = {};
        calculate();
    };

    var decheck = function (idn, f) {
        var found = false;
        for (var i = 0; i < $scope.cartItems.length; i++) {
            if ($scope.cartItems[i].ProductId == idn) {
                $scope.cartItems[i].SaleQuantity -= f;
                $scope.cartItems[i].mSalePrice = $scope.cartItems[i].SalePrice * $scope.cartItems[i].SaleQuantity;
                found = true;
                break;
            }
        }
        return found;
    }
    //--------------------------Increment-------------------------------------
    $scope.insertCart = function (m) {
        currentCart.ProductId = m.ProductId;
        currentCart.ProductName = m.ProductName;
        currentCart.SaleQuantity = 1;
        currentCart.SalePrice = m.SalePrice;
        currentCart.mSalePrice = m.SalePrice;

        if ($scope.cartItems.length == 0) {
            $scope.cartItems.push(currentCart);
        }
        else {

            if (!check(currentCart.ProductId, 1))
                $scope.cartItems.push(currentCart);
        }

        currentCart = {};
        calculate();
    };

    var check = function (idn, f) {
        var found = false;
        for (var i = 0; i < $scope.cartItems.length; i++) {
            if ($scope.cartItems[i].ProductId == idn) {
                $scope.cartItems[i].SaleQuantity += f;
                $scope.cartItems[i].mSalePrice = $scope.cartItems[i].SalePrice * $scope.cartItems[i].SaleQuantity;
                found = true;
                break;
            }
        }
        return found;
    }

    var calculate = function () {
        var gt = 0;
        var tm = 0;
        for (var i = 0; i < $scope.cartItems.length; i++) {
            tm += $scope.cartItems[i].SaleQuantity;
            gt += $scope.cartItems[i].mSalePrice;
        }
        $scope.TotalQuantity = tm;
        $scope.TotalPrice = gt;
        TotalPrice = gt;
        TotalQuantity = tm;
    }

    $scope.removeCart = function (m) {

        $scope.cartItems.splice($scope.cartItems.indexOf(m), 1);
        calculate();
    };
    $scope.clearCart = function () {

        $scope.cartItems.splice($scope.cartItems);
        calculate();
    };
    //-------------------------------------------------------------

    
    //----------------------Company-----------------------------------
    $scope.getallCompany = function () {
        (new omsSvc()).$getallCompany()
        .then(function (data) {
            $scope.companies = data.value;
        });
    }

    $scope.saveCompany = function () {
        var newData = $scope.company;
        return (new omsSvc({
            "CompanyName": newData.CompanyName
        })).$saveCompany()
        .then(function (data) {
            $scope.company = {};
            $scope.getallCompany();
        });
    }

    $scope.searchCompany = function () {
        var con = this.com;
        return (new omsSvc({

        })).$searchCompany({ key: con.CompanyId })
        .then(function (data) {
            $scope.company = data;
        });
    }

    $scope.updateCompany = function () {
        var con = this.company;
        if (con) {
            (new omsSvc({
                "CompanyId": con.CompanyId,
                "CompanyName": con.CompanyName
            })).$updateCompany({ key: con.CompanyId })
        .then(function (data) {
            $scope.company = {};
            $scope.getallCompany();

        });
        }
    }

    $scope.deleteCompany = function () {
        var con = this.company;
        if (confirm('Are you sure?')) {
            var con = this.com;
            return (new omsSvc({

            })).$deleteCompany({ key: con.CompanyId })
        .then(function (data) {
            $scope.getallCompany();

        });
        }
    }
    //----------------------Generic-----------------------------------
    $scope.getallGenericName = function () {
        (new omsSvc()).$getallGenericName()
        .then(function (data) {
            $scope.genericNames = data.value;
        });
    }

    $scope.saveGenericName = function () {
        var newData = $scope.generic;
        return (new omsSvc({
            "GenericName": newData.GenericName
        })).$saveGenericName()
        .then(function (data) {
            $scope.generic = {};
            $scope.getallGenericName();
        });
    }

    $scope.searchGenericName = function () {
        var con = this.gen;
        return (new omsSvc({

        })).$searchGenericName({ key: con.GenericId })
        .then(function (data) {
            $scope.generic = data;
        });
    }

    $scope.updateGenericName = function () {
        var con = this.generic;
        if (con) {
            (new omsSvc({
                "GenericId": con.GenericId,
                "GenericName": con.GenericName
            })).$updateGenericName({ key: con.GenericId })
        .then(function (data) {
            $scope.generic = {};
            $scope.getallGenericName();

        });
        }
    }

    $scope.deleteGenericName = function () {
        var con = this.generic;
        if (confirm('Are you sure?')) {
            var con = this.gen;
            return (new omsSvc({

            })).$deleteGenericName({ key: con.GenericId })
        .then(function (data) {
            $scope.getallGenericName();

        });
        }
    }
    //----------------------DosageFormat-----------------------------------
    $scope.getallDosageFormat = function () {
        (new omsSvc()).$getallDosageFormat()
        .then(function (data) {
            $scope.dosageFormats = data.value;
        });
    }

    $scope.saveDosageFormat = function () {
        var newData = $scope.dosage;
        return (new omsSvc({
            "DosageFormatName": newData.DosageFormatName
        })).$saveDosageFormat()
        .then(function (data) {
            $scope.dosage = {};
            $scope.getallDosageFormat();
        });
    }

    $scope.searchDosageFormat = function () {
        var con = this.dof;
        return (new omsSvc({

        })).$searchDosageFormat({ key: con.DosageFormatId })
        .then(function (data) {
            $scope.dosage = data;
        });
    }

    $scope.updateDosageFormat = function () {
        var con = this.dosage;
        if (con) {
            (new omsSvc({
                "DosageFormatId": con.DosageFormatId,
                "DosageFormatName": con.DosageFormatName
            })).$updateDosageFormat({ key: con.DosageFormatId })
        .then(function (data) {
            $scope.dosage = {};
            $scope.getallDosageFormat();

        });
        }
    }

    $scope.deleteDosageFormat = function () {
        var con = this.dosage;
        if (confirm('Are you sure?')) {
            var con = this.dof;
            return (new omsSvc({

            })).$deleteDosageFormat({ key: con.DosageFormatId })
        .then(function (data) {
            $scope.getallDosageFormat();

        });
        }
    }
    //----------------------Purchase-----------------------------------
    $scope.getallPurchase = function () {
        (new omsSvc()).$getallPurchase()
        .then(function (data) {
            $scope.purchases = data.value;
        });
    }
   
    $scope.savePurchase = function () {
        var imageToLoad = document.getElementById('pic');
        var imageDataUrl = ConvertImageToBase64(imageToLoad, 'pic');
        var date = new Date();
        var newData = $scope.purchase;
        //newData.SalePrice = parseFloat(newData.SalePrice, 10).toFixed(2);
        newData.ProductPhoto = imageDataUrl;
        return (new omsSvc({
            "PurchaseDate": date.getFullYear() + '-' + ('0' + (date.getMonth() + 1)).slice(-2) + '-' + ('0' + date.getDate()).slice(-2),
            "PurchaseQuantity": newData.PurchaseQuantity,
            "ProductId": newData.ProductId,
            "ProductName": newData.ProductName,
            "ProductDescription": newData.ProductDescription,
            "BoxPrice":newData.BoxPrice,
            "StripOrVialPerBox": newData.StripOrVialPerBox,
            "PiecePerStrip": newData.PiecePerStrip,
            "UnitPrice": parseFloat(newData.UnitPrice,10).toFixed(2),
            "Comission": newData.Comission,
            "SalePrice": parseFloat(newData.SalePrice, 10).toFixed(2),
            "ProductPhoto": newData.ProductPhoto,
            "MedicineUnit": newData.MedicineUnit,
            "ReorderLevel": newData.ReorderLevel,
            "GenericId": newData.GenericId,
            "CompanyId": newData.CompanyId,
            "DosageFormatId": newData.DosageFormatId
        })).$savePurchase()
        .then(function (data) {
            $scope.purchase = {};
            $scope.showProduct();
        });
    }
    
    $scope.searchPurchase = function () {
       
        var con = this.purchase;
       
        return (new omsSvc({

        })).$searchPurchase({ key: con.ProductId })
        .then(function (data) {
            $scope.purchase = data;
        });
    }
    $scope.searchPurchaseGrid = function () {
        $scope.purchase = this.pur;
    }

    $scope.updatePurchase = function () {
        var imageToLoad = document.getElementById('picUpdate');
        var imageDataUrl = ConvertImageToBase64(imageToLoad, 'picUpdate');
        var con = this.pur;
        var date = new Date();
        con.ProductPhoto = imageDataUrl;
        if (con) {
            (new omsSvc({
                "PurchaseId": con.PurchaseId,
                "PurchaseDate": date.getFullYear() + '-' + ('0' + (date.getMonth() + 1)).slice(-2) + '-' + ('0' + date.getDate()).slice(-2),
                "PurchaseQuantity": con.PurchaseQuantity,
                "ProductId": con.ProductId,
                "ProductName": con.ProductName,
                "ProductDescription": con.ProductDescription,
                "BoxPrice": con.BoxPrice,
                "StripOrVialPerBox": con.StripOrVialPerBox,
                "PiecePerStrip": con.PiecePerStrip,
                "UnitPrice": parseFloat(con.UnitPrice, 10).toFixed(2),
                "Comission": con.Comission,
                "SalePrice": parseFloat(con.SalePrice, 10).toFixed(2),
                "ProductPhoto": con.ProductPhoto,
                "MedicineUnit": con.MedicineUnit,
                "ReorderLevel": con.ReorderLevel,
                "GenericId": con.GenericId,
                "CompanyId": con.CompanyId,
                "DosageFormatId": con.DosageFormatId
            })).$updatePurchase({ key: con.PurchaseId })
        .then(function (data) {
            $scope.purchase = {};
            //$scope.getallPurchase();
            $scope.showProduct();

        });
        }
    }

    $scope.deletePurchase = function () {
        var con = this.purchase;
        if (confirm('Are you sure?')) {
            var con = this.pur;
            return (new omsSvc({

            })).$deletePurchase({ key: con.PurchaseId })
        .then(function (data) {
            //$scope.getallPurchase();
            $scope.showProduct();

        });
        }
    }
    //-------------------------Customer------------------------------

    $scope.getallCustomer = function () {
        (new omsSvc()).$getallCustomer()
        .then(function (data) {
            $scope.customers = data.value;
        });
    }

    $scope.saveCustomer = function () {
        var newData = $scope.customer;
        var date = new Date();
        return (new omsSvc({
            "CustomerName": newData.CustomerName,
            "CustomerAddress": newData.CustomerAddress,
            "CustomerPhone": newData.CustomerPhone,
            "CustomerEmail": newData.CustomerEmail,
            "CustomerApplyDate": date.getFullYear() + '-' + ('0' + (date.getMonth() + 1)).slice(-2) + '-' + ('0' + date.getDate()).slice(-2),
            "CustomerApplyStatus": newData.CustomerApplyStatus
        })).$saveCustomer()
        .then(function (data) {
            $scope.customer = {};
            $scope.getallCustomer();
        });
    }

    $scope.searchCustomer = function () {
        var con = this.cus;
        return (new omsSvc({

        })).$searchCustomer({ key: con.CustomerId })
        .then(function (data) {
            $scope.customer = data;
        });
    }
   
    $scope.updateCustomer = function () {
        
        var date = new Date();
        var con = this.customer;
        if (con) {
            (new omsSvc({
                "CustomerId": con.CustomerId,
                "CustomerName": con.CustomerName,
                "CustomerAddress": con.CustomerAddress,
                "CustomerPhone": con.CustomerPhone,
                "CustomerEmail": con.CustomerEmail,
                "CustomerApplyDate": con.date.getFullYear() + '-' + ('0' + (date.getMonth() + 1)).slice(-2) + '-' + ('0' + date.getDate()).slice(-2),
                "CustomerApplyStatus": con.CustomerApplyStatus
            })).$updateCustomer({ key: con.CustomerId })
        .then(function (data) {
            $scope.customer = {};
            $scope.getallCustomer();

        });
        }
    }

    $scope.deleteCustomer = function () {
        var con = this.customer;
        if (confirm('Are you sure?')) {
            var con = this.cus;
            return (new omsSvc({

            })).$deleteCustomer({ key: con.CustomerId })
        .then(function (data) {
            $scope.getallCustomer();

        });
        }
    }

    $scope.click = function () {
        window.location = "/AdminDashBoard.html#/addcst"
    }


    //----------------------Stock-----------------------------------
    $scope.getallStock = function () {
        (new omsSvc()).$getallStock()
        .then(function (data) {
            $scope.stocks = data.value;
        });
    }
    //----------------------Order-----------------------------------
    $scope.getallOrder = function () {
        (new omsSvc()).$getallOrder()
        .then(function (data) {
            $scope.orders = data.value;
        });
    }
    
    $scope.saveOrder = function () {
        var newData = $scope.order;
        var date = new Date();
        return (new omsSvc({
            "CustomerName": newData.CustomerName,
            "CustomerAddress": newData.CustomerAddress,
            "CustomerPhone": newData.CustomerPhone,
            "CustomerEmail": newData.CustomerEmail,
           "OrderDate": date.getFullYear() + '-' + ('0' + (date.getMonth() + 1)).slice(-2) + '-' + ('0' + date.getDate()).slice(-2),
           //"GrandTotal": parseFloat(newData.TotalQuantity, 10).toFixed(2),
            //"TotalItem": newData.TotalQuantity,
            //"CustomerId": newData.CustomerId
        })).$saveOrder()
        .then(function (data) {
            $scope.order = {};
        });
    }


    //----------------------OrderDetail-----------------------------------
    $scope.getallOrderDetail = function () {
        (new omsSvc()).$getallOrderDetail()
        .then(function (data) {
            $scope.orderDetails = data.value;
        });
    }

    $scope.saveOrderDetail = function () {

        var newOrderData = $scope.order;
        var date = new Date();
        var oid = 0;
        (new omsSvc({
            "CustomerName": newOrderData.CustomerName,
            "CustomerAddress": newOrderData.CustomerAddress,
            "CustomerPhone": newOrderData.CustomerPhone,
            "CustomerEmail": newOrderData.CustomerEmail,
            "OrderDate": date.getFullYear() + '-' + ('0' + (date.getMonth() + 1)).slice(-2) + '-' + ('0' + date.getDate()).slice(-2),
            "GrandTotal": parseFloat(TotalPrice, 10).toFixed(2),
            "GrandTotalItem": TotalQuantity,
            
        })).$saveOrder()
        .then(function (data) {
            oid = data.OrderId;
            

            for (var i = 0; i < $scope.cartItems.length; i++) {
                var newData = $scope.cartItems[i];
            
                (new omsSvc({
                    "ProductId": newData.ProductId,
                    "SaleQuantity": newData.SaleQuantity,
                    "TotalSale": parseFloat(newData.mSalePrice, 10).toFixed(2),
                    "SalePrice": parseFloat(newData.SalePrice, 10).toFixed(2),
                    "OrderId": oid
                })).$saveOrderDetail()
                
              .then(function (data) {

              });
            }//loop

            //$scope.order = {};
            //$scope.cartItems = [];
            $scope.TotalQuantity = 0;
            $scope.TotalPrice = 0;
            alert("Your Order Has been recieved");
        });

       
        //for (var i = 0; i < $scope.cartItems.length; i++) {
        //    var newData = $scope.cartItems[i];
        //    alert("Details : "+oid);
        //    (new omsSvc({
        //        "ProductId": newData.ProductId,
        //        "SaleQuantity": newData.SaleQuantity,
        //        "SalePrice": parseFloat(newData.mSalePrice, 10).toFixed(2),
        //        //"OrderId": oid
        //    })).$saveOrderDetail()
        //  .then(function (data) {
              
        //  });
        //}//loop
    //--------------- Save Order ---------------
       
 
    }
       
    //})
              

    //---------------ProductView-----------------------------------------
    $scope.showProduct = function () {
        $http.get("http://localhost:5609/api/vw_ViewProducts")
        .then(function (response) {
            $scope.productView = response.data;
        }, function (response) {
            
        });

    }
  
    
    //---------------SalesDettails-----------------------------------------
    $scope.showSalesDetail = function () {
        
        $http.get("http://localhost:5609/api/vw_SaleDetails")
        .then(function (response) {
            $scope.totalSalesView = response.data;
        }, function (response) {
            
        });

    }

    $scope.showSalesDetailById = function (idn) {
        
        $http.get("http://localhost:5609/api/vw_SaleDetails/"+idn)
        .then(function (response) {
            $scope.totalSalesViewbyId = response.data;
        }, function (response) {
            
        });

    }

    $scope.searchPv = function () {
        $scope.productv = this.product;
               
    }
    //-------------------------print Reciept-----------------------
    $scope.printDiv = function (printable) {
        var docHead = document.head.outerHTML;
        var printContents = document.getElementById(printable).outerHTML;
        var winAttr = "location=yes, statusbar=no, menubar=no, titlebar=no, toolbar=no,dependent=no, width=865, height=600, resizable=yes, screenX=200, screenY=200, personalbar=no, scrollbars=yes";

        var newWin = window.open("", "_blank", winAttr);
        var writeDoc = newWin.document;
        writeDoc.open();
        writeDoc.write('<!doctype html><html>' + docHead + '<body onLoad="window.print()">' + printContents + '</body></html>');
        writeDoc.close();
        newWin.focus();
    }
    //-------------------------print Reciept-----------------------
})
//-------------------------------For Image---------------------------

//-------------------------------Add---------------------------
function ConvertImageToBase64(imageToConvertBase64, picture) {
    var drawCanvas = document.createElement("canvas");
    var p = document.getElementById(picture);
    drawCanvas.width = 150;
    drawCanvas.height = 150;
    var copyImageToCanvas = drawCanvas.getContext("2d");

    copyImageToCanvas.drawImage(p, 0, 0, 150, 150);
    var dataUrlOfImage = drawCanvas.toDataURL("image/png");
    return dataUrlOfImage.replace(/^data:image\/(png|jpg|JPG);base64,/, "");
}


//-------------------------------Update---------------------------
function readURL(input, t) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#' + t)
                .attr('src', e.target.result)
                .width(150)
                .height(150);
        };

        reader.readAsDataURL(input.files[0]);
        input.value = '';
    }
}

