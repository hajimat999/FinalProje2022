document.querySelectorAll('.product-img-item').forEach(e => {
    e.addEventListener('click', () => {
        let img = e.querySelector('img').getAttribute('src')
        document.querySelector('#product-img > img').setAttribute('src', img)
    })
})




var a1 = document.getElementsByClassName("a1")[0];
var a2 = document.getElementsByClassName("a1")[1];
var a3 = document.getElementsByClassName("a1")[2];
document.getElementsByClassName("content-section")[0].style.display="block"
a1.style.color="yellow"
a1.addEventListener("click", function(e){
    e.preventDefault();
    if( document.getElementsByClassName("content-section")[0].style.display=="block"){
        document.getElementsByClassName("content-section")[0].style.display="none";
        document.getElementsByClassName("content-section")[1].style.display="none";
        document.getElementsByClassName("content-section")[2].style.display="none";
        a1.style.color="white"
        a2.style.color="white"
        a3.style.color="white"
    }
    else{
        document.getElementsByClassName("content-section")[0].style.display="block";
        document.getElementsByClassName("content-section")[1].style.display="none";
        document.getElementsByClassName("content-section")[2].style.display="none";
        a1.style.color="yellow"
        a2.style.color="white"
        a3.style.color="white"
    }
        
});
a2.addEventListener("click", function(e){
    e.preventDefault();
    if(document.getElementsByClassName("content-section")[1].style.display=="none"){
        document.getElementsByClassName("content-section")[0].style.display="none";
        document.getElementsByClassName("content-section")[1].style.display="block";
        document.getElementsByClassName("content-section")[2].style.display="none";
        a2.style.color="yellow"
        a1.style.color="white"
        a3.style.color="white"
    }
    else{
        document.getElementsByClassName("content-section")[0].style.display="none";
        document.getElementsByClassName("content-section")[1].style.display="none";
        document.getElementsByClassName("content-section")[2].style.display="none";
        a2.style.color="white"
    } 
});
a3.addEventListener("click", function(e){
    e.preventDefault();
    if(document.getElementsByClassName("content-section")[2].style.display=="none"){
        document.getElementsByClassName("content-section")[0].style.display="none";
        document.getElementsByClassName("content-section")[1].style.display="none";
        document.getElementsByClassName("content-section")[2].style.display="block";
        a3.style.color="yellow"
        a2.style.color="white"
        a1.style.color="white"
    }
    else{
        document.getElementsByClassName("content-section")[0].style.display="none";
        document.getElementsByClassName("content-section")[1].style.display="none";
        document.getElementsByClassName("content-section")[2].style.display="none";
        a3.style.color="white"
    }
    
    
});