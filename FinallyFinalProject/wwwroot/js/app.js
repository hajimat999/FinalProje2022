document.querySelectorAll('.dropdown > a').forEach(e => {
    e.addEventListener('click', (event) => event.preventDefault())
})
// Shopping cart
var element=document.getElementById("header-cart")
element.addEventListener("click", function(){
    var element1 = document.getElementById("drop")
    if(element1.style.display=="none"){
        element1.style.display="block"
    }
    else{
        element1.style.display="none"
    }
})
var removeIcon = document.getElementsByClassName("fa-solid fa-xmark")[0]
removeIcon.addEventListener("click", function(){
    var element1 = document.getElementById("drop")
    if(element1.style.display=="block"){
        element1.style.display="none"
    }
})
// contact cart
var div = document.getElementsByClassName("dropdown-content333")[0]
var a = document.getElementsByClassName("fa fa-user")[0]

a.addEventListener("click", function(e){
    e.preventDefault()
    if(div.style.display=="none"){
        div.style.display="block"
        
    }
    else{
        div.style.display="none"
    }
})
document.querySelectorAll('.mega-dropdown > a').forEach(e => {
    e.addEventListener('click', (event) => event.preventDefault())
})

document.querySelector('#mb-menu-toggle').addEventListener('click', () => document.querySelector('#header-wrapper').classList.add('active'))

document.querySelector('#mb-menu-close').addEventListener('click', () => document.querySelector('#header-wrapper').classList.remove('active'))