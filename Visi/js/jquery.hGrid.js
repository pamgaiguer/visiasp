(function($){

$.noConflict();

jQuery.fn.hGrid = function(options){	

	

	//Seta os valores padrões do grid

	var defaults = {

		boxWidth:300,

		boxMargin:2,

		gItem:'li'

	}

		 

	var options =  jQuery.extend(defaults, options); //Define a lista de opções padrões

    

	//Esse codigo eh sempre nessesario em qualquer plugin

	return this.each(function(){

		

		var timer;
			

		var item_children = jQuery(this).find(options.gItem); //Pega os itens que estao dentro do elemento selecionado ( grid )

		var arraySize = item_children.size(); //Conta quantos itens existem 

		//Atribui a variavel colunas a quantidade de colunas existentes

		var colunas = Math.floor(jQuery(this).width()/(options.boxWidth + options.boxMargin)); 

		var lista = new Array(); //lista Itens Primaria que sera subtraida

		var listaOriginal = new Array(); //Essta lista nao sera modificada

		var listb = new Array(); //Nova lista para incremento da lista modificada

		

		var x =0;

		while ( x < arraySize ){

			

			//Cria a lista Original

			listaOriginal[x] = new Array(toString(x));

			listaOriginal[x]['tamanho'] = parseInt(item_children.eq(x).attr('data-block'));

			listaOriginal[x]['classes'] = item_children.eq(x).attr('class');

			listaOriginal[x]['imagem'] = item_children.eq(x).html(); 

			

			//Cria a lista para modificacao

			lista[x] = new Array(toString(x));

			lista[x]['tamanho'] = parseInt(item_children.eq(x).attr('data-block'));

			lista[x]['classes'] = item_children.eq(x).attr('class');

			lista[x]['imagem'] = item_children.eq(x).html();

			console.log(x);

		x++;}
		
		

	

		jQuery(this).html(''); //Limpa o html com os itens feitos pelo usuario

	

		var soma = 0; //soma para incremento

		var testesoma; //Teste da soma para saber se vai ser maior, menor ou igual a coluna

		var hood=0; //Variavel de teste para saber se existe proximos itens que cabe na linha

		var a = 0; //incremento para lista nova

		var g = 0; //loop da lista

		//veriffica se a lista esta vazia, enquanto a lista nao estiver vazia ela continua executando os testes

		while ( lista.length != 0 ){ 


			testesoma = soma + lista[g]['tamanho'];//Faz o teste da soma

			//Primeiro verifica se o teste de soma vai ser menor que a quantidade de colunas

			if ( testesoma < colunas ){

				

				//Sendo verdadeiro ele insere o valor na lista de incremento

				listb[a] = new Array(toString(a));

				listb[a]['tamanho'] = lista[g]['tamanho'];

				listb[a]['classes'] = lista[g]['classes'];

				listb[a]['imagem'] = lista[g]['imagem'];	

				soma = soma + lista[g]['tamanho']; //Faz a soma

				lista.splice(g,1); //Deleta da lista de modificação

				//soma = 0;

				a=a+1; //Adiciona +1 a lista de incremento

				g = 0; //Volta ao indice da lista de modificacao

				hood=0; //Zera a variavel de teste

			

			//Verifica se o teste da soma e igual a coluna

			}else if( testesoma == colunas ){

				

				//Sendo verdadeiro, ainda continua a inserir os itens

				listb[a] = new Array(toString(a));

				listb[a]['tamanho'] = lista[g]['tamanho'];

				listb[a]['classes'] = lista[g]['classes'];

				listb[a]['imagem'] = lista[g]['imagem'];

				soma = soma + lista[g]['tamanho']; //Faz a soma

				lista.splice(g,1); //Deleta da lista de modificação

				soma = 0; //A soma eh zerada pois chegou ao limite de colunas

				a=a+1; //Adiciona +1 a lista de incremento

				g=0; //Volta ao indice do loop da lista

				hood=0; //Zera a variavel de teste

			

			//Verifica se o teste da soma e maior, se for maior ele vai pular o item e fazer uma nova verificacao

			}else if( testesoma > colunas ){

				

				hood++; //Adiciona a variavel de teste +1

				g=g+1; //Adiciona +1 ao loop da lista

				

				//Verifica se a variavel de teste e igual o tamanho da lista

				if ( hood >= lista.length ){
					
					//Caso verdadeira 

					g=0; //Volta ao indice do loop da lista
	

					//E coloca o item na linha, pois nao ha mais nenhum item para encaixar. ( final de lista )

					listb[a] = new Array(toString(a));

					listb[a]['tamanho'] = lista[g]['tamanho'];
					
					console.log(listb[a]['tamanho'] + ' - ' + lista[g]['tamanho'] );

					listb[a]['classes'] = lista[g]['classes'];

					listb[a]['imagem'] = lista[g]['imagem'];

					lista.splice(g,1); //Deleta o item da lista de modificacao

					a=a+1; //Adiciona +1 a lista do loop da lista


				}

				

			}


		}

			

		//reinsere o conteudo atraves de um loop	

		var y = 0; //Variavel do loop

		while ( y < arraySize ){

			jQuery(this).append('<article class="'+listb[y]['classes']+'" data-block="'+ listb[y]['tamanho'] +'" >'+ listb[y]['imagem'] +'</article>');//Faz um append no documento grid

		y++;}
		
		//lista.clear();
		//listb.clear();

		

		// tenho que pegar novamente os valores para poder reescreve-los

		var item_children1 = jQuery(this).find(options.gItem); //atribui um elemento a uma variavel

		var arraySize = item_children.size(); //Atribui a quantidade de itens a uma variavel

		var wWidth = jQuery(window).width(); //Define a largura do documento

		var wHeight = jQuery(window).height(); //Define a altura do documento

		var colum, diff, hRation, wSingleItem; //Cria algumas variaveis para manipulacao

		var numberItens = 0; //Zera o contador do numero de itens

		var obj = jQuery(this);

		

		//Caso o usuario faca um resize na tela

		function resize(item_children){

			

			//Cria uma variavel com o numero de colunas

			colum = Math.floor(jQuery(obj).width()/(options.boxWidth + options.boxMargin));

			//Cria uma variavel com a diferenca do grid
			
			
			jQuery(obj).width('auto');
			
			var widthObj = jQuery(obj).width();
			
			jQuery(obj).width(jQuery(obj).width());
			

			diff = jQuery(obj).width() - (colum *(options.boxWidth + options.boxMargin));


			//Calcula a largura do item

			wSingleItem = options.boxWidth + (diff / colum);

			

			//Calcula a proporcao da altura

			hRation = wSingleItem / options.boxWidth;

			

			//Faz a verificacao para saber se o item eh de largura de 2 blocos ou 1 bloco

			jQuery(item_children).each(function(){

				

				if(jQuery(this).attr('data-block') == '1'){	//Caso verdade do item ser de 1 bloco	

					numberItens += 1; //Adiciona a variavel de numero de itens +1 ( 1 coluna )

					jQuery(this).css({ //Atribui margem e largura no item para ele ficar proporcionalmente igual

						'width':wSingleItem,

						'height':options.boxWidth * hRation,

						'margin-right':options.boxMargin,

						'margin-bottom':options.boxMargin

					});

					

				} else if(jQuery(this).attr('data-block') == '2'){ //Caso o item tenha 2 blocos de largura 

					

					//Calcula a proporcao da largura do item

					var wItem1x2 = (options.boxWidth * 2 + ((diff / colum) * 2)) + options.boxMargin;	

					

					numberItens += 2; //Adiciona a variavel de numero de itens +2 ( 2 colunas )

					

					jQuery(this).css({ //Atribui margem e largura no item para ele ficar proporcionalmente igual

						'width':wItem1x2,

						'height':options.boxWidth * hRation,

						'margin-right':options.boxMargin,

						'margin-bottom':options.boxMargin

					});

				}

			})
			
			
			//BUG NO IFONE!!! RESOLVER
			if (navigator.userAgent.match(/iPhone/i)){
				
			}else{

			item_children.hide();

			//Faz o fade nas imagens na hora em que monta

			function fadeIn(idx){

				item_children.eq(idx).fadeIn(200, function(){

					fadeIn(jQuery(this).index()+1);

				});

			}

			

			clearTimeout(timer);

			

			timer = setTimeout(function(){

				fadeIn(0);
				

			},1000);

			
			
				
			}


		}

		

		resize(item_children1); //Efetua o resize quando carrega



		

    });

	

};



})(jQuery);