/// <reference path="_reference.js" />
$(window).load(function () {

    'use strict';

    // Menu lateral esquerdo (Categorias)
    var $menu = $('#menuCat');

    // Container de imagens
    var $imgs = $('#photoContainer');

    // Show case dos projetos (Carousel)
    var $expo = $('#expoPhoto');

    // Attr para buscar a categoria (Melhora o minification)
    var dCat = 'data-categoria';

    // Attr para buscar o proj
    var dProj = 'data-projeto';

    // Attr para buscar showcase
    var dShow = 'data-showcase';

    // Armazena o id da categoria
    var catId = 0;

    // Armazena o id do projeto
    var projId = 0;

    var ativaMenuProjetos = function () {

        // Suma daqui :)
        $menu.find('.projectList').hide(200);

        // Remove todas as classes dos ul
        $menu.children('li').removeClass('active');

        // Procura a ul filha do elemento clicado pelo id (cat + numeroCat) e mostra sapreula
        $menu.find('ul#cat' + catId).show(200);

    };

    var ativaImagens = function () {
        
        // Armazena o seletor!
        var selector = "";

        // Regra:
        // Verifica se existe projeto, caso existe, com certeza existe categoria
        // Caso nao tenha, verifia categoria
        // Caso nao tenha, exibe todas que nao possuem atributo data-onlyshow
        if (projId != undefined && projId > 0) {
            selector = 'div[data-proj-image][' + dProj + '="' + projId + '"][' + dCat + '="' + catId + '"]:not([data-showonly])';
        } else if (catId != undefined && catId > 0) {
            selector = 'div[data-proj-image][' + dCat + '="' + catId + '"][data-showonly]';
        } else {
            selector = "div[data-proj-image][data-showonly]";
        }

        // Anima a exibicao e terminar sumindo com as desnecessarias
        $imgs.find("div[data-proj-image]:not(" + selector + ")").each(function () {
            $(this).hide();
        })
        $imgs.find(selector).each(function (i) {
            $(this).hide().fadeIn(500 + (50 * (i+1)));
        })

    }

    // Pega o item ativo e ja carrega os itens necessarios de acordo com a rota
    var init = function () {

        // Acha o menu ativo na hora da rota e pega seu catId
        var $elCat = $menu.find('li[' + dCat + '].active');
        var $elProj = $menu.find('li[' + dProj + '].active-select');

        catId = $elCat.attr(dCat) || 0;
        projId = $elProj.attr(dProj) || 0;

        // Ativa menu
        if (catId && catId != undefined)
            ativaMenuProjetos();

        // Imagens
        ativaImagens();

        $elCat.addClass('active');
        $elProj.addClass('active-select');

        $imgs.show(200);
    };

    // Clique no menu de categorias
    var onClickCat = function (e) {

        // Pegamos o anchor clicado e subidos um nivel para pegar o li
        var $el = $(e.target)

        if ($el.attr("data-showcase") != undefined)
            return onShowCase(e);

        $el = $el.closest('li');

        // Pega a categoria do [data-categoria]
        var cat = $el.attr(dCat);

        // Cancela acao padrao do anchor
        e.preventDefault();

        // Retira show case caso tenha
        $expo.hide();
        $imgs.show();

        // Ativa menu
        catId = cat;
        projId = 0;
        ativaMenuProjetos();
        ativaImagens();

        // Coloca a classe no li
        $el.addClass('active');

    };

    // Clique no menu de projetos
    //var onClickProj = function (e) {

    //    // Pegamos o anchor clicado e subidos um nivel para pegar o li
    //    var $el = $(e.target).closest('li');

    //    // Pega o projetoId do [data-projeto]
    //    var proj = $el.attr(dProj);

    //    // Cancela acao padrao do anchor
    //    e.preventDefault();

    //    // Retira show case caso tenha
    //    $expo.hide();
    //    $imgs.show();

    //    // Mostra imagens do projeto
    //    projId = proj;
    //    ativaImagens();

    //    // Coloca css fresco =D
    //    // Remove todas as classes dos li
    //    $menu.find('li.active-select').removeClass('active-select');
    //    $el.addClass('active-select');

    //};

    // Clique para showcase
    var onShowCase = function (e) {
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

        // Esconde as imagens para mostrar o showcase
        $imgs.hide();
        $expo.find('div[' + dShow + ']').hide();
        $expo.find('div[' + dShow + '="' + projId + '"]').show();
        $expo.show();
    }

    // Bind de eventos
    $imgs.on('click', 'a[data-showcase]', onShowCase);
    $menu.on('click', 'li[' + dCat + ']', onClickCat);
    //$menu.on('click', 'li[' + dProj + ']', onShowCase);

    // Carrega o menu inicial da rota
    init();

});