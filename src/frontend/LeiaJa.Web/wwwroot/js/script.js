function scrollXY()
{
    let navBar = document.querySelector('#header');

    document.addEventListener("scroll", ()=>{
        let scrollTop = window.scrollY;

        if(scrollTop > 0){
            navBar.classList.add('rolar');
        }
        else{
            navBar.classList.remove('rolar');
        }
    });
}

function responsiveMenu()
{
    let btnMenuMob = document.querySelector('#btn-menu-mob');
    let line1 = document.querySelector('.line-menumob1');
    let line2 = document.querySelector('.line-menumob2');
    let menuButton = document.querySelector('.menu-mobile');
    let body = document.querySelector('body')

    btnMenuMob.addEventListener("click", ()=>{
        line1.classList.toggle("ativo1");
        line2.classList.toggle("ativo2");
        menuButton.classList.toggle("abrir");
        body.classList.toggle('no-overflow');
    });
}