/// <reference path="../app/app.js" />


app.controller("SlideCtrl", function ($scope) {
    $scope.images = [
        {
            src: "../images/image-slider-1.jpg",
            alt: "image 1",
            link: "http://www.higgidy.co.uk"
        },
         {
             src: "../images/image-slider-2.jpg",
             alt: "image 2",
             link: "http://www.higgidy.co.uk"
         },
          {
              src: "../images/image-slider-3.jpg",
              alt: "image 3",
              link: "http://www.higgidy.co.uk"
          },
           {
               src: "../images/image-slider-4.jpg",
               alt: "image 4",
               link: "http://www.higgidy.co.uk"
           },
    ]

});