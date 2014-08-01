var x=0;
var imagem=new Array();
imagem[0]="nome_da_imagem0.jpg";
imagem[1]="nome_da_imagem1.jpg";
imagem[2]="nome_da_imagem2.jpg";  // e assim por diante, conforme o n.º de imagens

var site=new Array();
site[0]="www.nome_do_site0.com";
site[1]="www.nome_do_site1.com";
site[2]="www.nome_do_site2.com"; // e assim por diante, conforme o n.º de sites


            jQuery(document).ready(function($){
                
                $('#grid').hGrid({
                    boxWidth:304,
                    boxMargin:5,
                    gItem:'article'
                });
                
                $(window).resize(function(){
                    
                    $('#grid').hGrid({
                        boxWidth:304,
                        boxMargin:5,
                        gItem:'article'
                    });
                    });
                
            });
