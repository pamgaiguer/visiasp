/// <reference path="_reference.js" />
$(window).load(function () {

    'use strict';
    
    var
        // Menu lateral esquerdo (Categorias)
        $menu = $('#menuCat'),

        // Container de imagens
        $imgs = $('#photoContainer'),

        // Show case dos projetos (Carousel)
        $expo = $('#expoPhoto'),

        // Attr para buscar a categoria (Melhora o minification)
        dCat = 'data-categoria',

        // Attr para buscar o proj
        dProj = 'data-projeto',

        // Attr para buscar showcase
        dShow = 'data-showcase',

        // Armazena o id da categoria
        catId = 0,

        // Armazena o id do projeto
        projId = 0,

        // Urls
        getTumbsUrl = '/projetos/getThumb?categId=',
        getSlideShowUrl = '/projetos/getSlideShow?projId=',

        // Gets thumbs from server
        getThumb = function (data) {

            $expo.html("");
            $imgs.html("Carregando fotos...");
            $.get(getTumbsUrl + catId).then(renderThumb, renderError);

        },

        renderThumb = function (data) {

            if (data)
                $imgs.html(data);

            $imgs.find("div").each(function (i) {
                $(this).fadeIn(500 + (50 * (i + 1)));
            })

        },

        getSlideShow = function () {

            $imgs.html("");
            $expo.html("Carregando fotos...");
            $.get(getSlideShowUrl + projId).then(renderSlideShow, renderError);

        },

        renderSlideShow = function (data) {

            $expo.html(data);

        },

        renderError = function () {
            $expo.html("Um erro ocorreu ao tentar acessar as fotos, tente novamente mais tarde.");
            $imgs.html("Um erro ocorreu ao tentar acessar as fotos, tente novamente mais tarde.");
        },

        ativaMenuProjetos = function () {

            // Suma daqui :)
            $menu.find('.projectList').hide(200);

            // Remove todas as classes dos ul
            $menu.children('li').removeClass('active');

            // Procura a ul filha do elemento clicado pelo id (cat + numeroCat) e mostra sapreula
            $menu.find('ul#cat' + catId).show(200);

        },

        // Pega o item ativo e ja carrega os itens necessarios de acordo com a rota
        init = function () {

            // Acha o menu ativo na hora da rota e pega seu catId
            var $elCat = $menu.find('li[' + dCat + '].active');
            var $elProj = $menu.find('li[' + dProj + '].active-select');

            catId = $elCat.attr(dCat) || 0;
            projId = $elProj.attr(dProj) || 0;

            // Ativa menu
            if (catId && catId != undefined)
                ativaMenuProjetos();

            // Imagens
            renderThumb();

            $elCat.addClass('active');
            $elProj.addClass('active-select');

            $imgs.show(200);
        },

        // Clique no menu de categorias
        onClickCat = function (e) {

            // Pegamos o anchor clicado e subidos um nivel para pegar o li
            var $el = $(e.target)

            if ($el.attr("data-showcase") != undefined)
                return onShowCase(e);

            $el = $el.closest('li');

            // Pega a categoria do [data-categoria]
            var cat = $el.attr(dCat);

            // Cancela acao padrao do anchor
            e.preventDefault();

            // Ativa menu
            catId = cat;
            projId = 0;
            ativaMenuProjetos();
            getThumb();

            // Coloca a classe no li
            $el.addClass('active');

        },

        // Clique para showcase
        onShowCase = function (e) {
            // Pegamos o anchor clicado e subidos um nivel para pegar a div
            var $el = $(e.target);
            $el = $el.attr("data-menu") == undefined ? $el.closest('div[data-proj-image]') : $el.closest('li');
            projId = $el.attr(dProj);
            catId = $el.attr(dCat);

            // Cancela acao padrao do anchor
            e.preventDefault();

            // Ativa o menu
            ativaMenuProjetos();
            $menu.find('li.active-select').removeClass('active-select');
            $menu.find('li[' + dCat + '="' + catId + '"]').addClass('active');
            $menu.find('li[' + dProj + '="' + projId + '"]').addClass('active-select');

            getSlideShow();
        };

    // Bind de eventos
    $imgs.on('click', 'a[data-showcase]', onShowCase);
    $menu.on('click', 'li[' + dCat + ']', onClickCat);
    //$menu.on('click', 'li[' + dProj + ']', onShowCase);

    // Carrega o menu inicial da rota
    init();

});