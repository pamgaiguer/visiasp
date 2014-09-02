/// <reference path="_reference.js" />
$(function () {

    'use strict';

    // Menu lateral esquerdo (Categorias)
    var $menu = $('#menuCat');

    var onClickMenu = function (e) {

        // Pegamos o anchor clicado e subidos um nivel para pegar o li
        var $el = $(e.target).closest('li');

        // Pega a categoria do [data-categoria]
        var cat = $el.attr('data-categoria');

        // Cancela acao padrao do anchor
        e.preventDefault();

        // Suma daqui :)
        $menu.find('.projectList').hide(200);

        // Remove todas as classes dos ul
        $menu.children('li').removeClass('active');

        // Coloca a classe no li
        $el.addClass('active');

        // Procura a ul filha do elemento clicado pelo id (cat + numeroCat)
        var itens = $menu.find('ul#cat' + cat);

        // Caso itens seja vazio, nao continua a acao (Pode ser o Todos, que nao possui filhos)
        if (itens == undefined) {
            return;
        }

        // Mostra menu filho com animacao
        itens.show(200);

    }

    // Bind de eventos
    $menu.on('click', onClickMenu);

});