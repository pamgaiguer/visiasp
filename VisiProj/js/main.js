/// <reference path="_reference.js" />
$(function () {

    'use strict';

    // Menu lateral esquerdo (Categorias)
    var $menu = $('#menuCat');

    // Container de imagens
    var $imgs = $('#photoContainer');

    // Attr para buscar a categoria (Melhora o minification)
    var dCat = 'data-categoria';

    // Attr para buscar o proj
    var dProj = 'data-projeto';

    var ativaMenuProjetos = function (catId) {

        // Suma daqui :)
        $menu.find('.projectList').hide(200);

        // Remove todas as classes dos ul
        $menu.children('li').removeClass('active');

        // Procura a ul filha do elemento clicado pelo id (cat + numeroCat) e mostra sapreula
        $menu.find('ul#cat' + catId).show(200);

    };

    var ativaImagens = function (projId) {
        
        // Suma imagens idiotas!
        $imgs.find('div[data-proj-image]').hide(200);

        if (projId == undefined || projId == 0) {
            $imgs.children('div[data-proj-image]').show(200);
            
            return;
        }

        // Acha as imagens do projeto em questao e revela
        $imgs.find('div>a[' + dProj + '="' + projId + '"]').show(200);

    }

    // Pega o item ativo e ja carrega os itens necessarios de acordo com a rota
    var init = function () {

        // Acha o menu ativo na hora da rota e pega seu catId
        var $elCat = $menu.find('li[' + dCat + '].active');
        var $elProj = $menu.find('li[' + dProj + '].active-select');
        var catId = $elCat.attr(dCat);
        var projId = $elProj.attr(dProj);

        // Ativa menu
        if (catId && catId != undefined)
            ativaMenuProjetos(catId);

        // Imagens
        ativaImagens(projId);

        $elCat.addClass('active');
        $elProj.addClass('active-select');

        $imgs.show(200);
    };

    // Clique no menu de categorias
    var onClickCat = function (e) {

        // Pegamos o anchor clicado e subidos um nivel para pegar o li
        var $el = $(e.target).closest('li');

        // Pega a categoria do [data-categoria]
        var cat = $el.attr(dCat);

        // Cancela acao padrao do anchor
        e.preventDefault();

        // Ativa menu
        ativaMenuProjetos(cat);

        // Coloca a classe no li
        $el.addClass('active');

    };

    // Clique no menu de projetos
    var onClickProj = function (e) {

        // Pegamos o anchor clicado e subidos um nivel para pegar o li
        var $el = $(e.target).closest('li');

        // Pega o projetoId do [data-projeto]
        var proj = $el.attr(dProj);

        // Cancela acao padrao do anchor
        e.preventDefault();

        // Mostra imagens do projeto
        ativaImagens(proj);

        // Coloca css fresco =D
        $el.addClass('active-select');

    };

    // Bind de eventos
    $menu.on('click', 'li[' + dCat + ']', onClickCat);
    $menu.on('click', 'li[' + dProj + ']', onClickProj)

    // Carrega o menu inicial da rota
    init();

});