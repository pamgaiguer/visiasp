$(document).ready(function() {
    figures = [
    newFigure('http://lorempixel.com/370/150'), 
    newFigure('http://lorempixel.com/g/370/150'), 
    newFigure('http://lorempixel.com/370/150'), 
    newFigure('http://lorempixel.com/g/370/150'), 
    newFigure('http://lorempixel.com/370/150'), 
    newFigure('http://lorempixel.com/g/370/150'), 
    newFigure('http://lorempixel.com/370/150/sports'), 
    newFigure('http://lorempixel.com/370/150'), 
    newFigure('http://lorempixel.com/370/150/sports'), 
    newFigure('http://lorempixel.com/370/150'), 
    newFigure('http://lorempixel.com/370/150'), 
    newFigure('http://lorempixel.com/370/150')
   ];
    $(figures).each(function() {
        $('.col-md-12').append(this);
    });
});

function newFigure(img) {
    var figure = document.createElement('figure');
    var image = document.createElement('img');
    image.src = img;
    $(figure).append(image);
    return figure;
}