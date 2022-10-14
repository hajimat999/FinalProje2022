let products = [
    
]

let product_list = document.querySelector('#products')

renderProducts = (products) => {
    products.forEach(e => {
        let prod = `
            <div class="col-4 col-md-6 col-sm-12">
                <div class="product-card">
                    <div class="product-card-img">
                        <img src="${e.image1}" alt="">
                        <img src="${e.image2}" alt="">
                    </div>
                    <div class="product-card-info">
                        <div class="product-btn">
                            <a href="~/product-detail.html" class="btn-flat btn-hover btn-shop-now">shop now</a>
                            <button class="btn-flat btn-hover btn-cart-add">
                                <i class='bx bxs-cart-add'></i>
                            </button>
                            <button class="btn-flat btn-hover btn-cart-add">
                                <i class='bx bxs-heart'></i>
                            </button>
                        </div>
                        <div class="product-card-name">
                            ${e.name}
                        </div>
                        <div class="product-card-price">
                            <span><del>${e.old_price}</del></span>
                            <span class="curr-price">${e.curr_price}</span>
                        </div>
                    </div>
                </div>
            </div>
        `
        product_list.insertAdjacentHTML("beforeend", prod)
    })
}

renderProducts(products)
renderProducts(products)

let filter_col = document.querySelector('#filter-col')

document.querySelector('#filter-toggle').addEventListener('click', () => filter_col.classList.toggle('active'))

document.querySelector('#filter-close').addEventListener('click', () => filter_col.classList.toggle('active'))

let checkbox1 = document.getElementById('remember1')
let checkbox2 = document.getElementById('remember2')
let checkbox3 = document.getElementById('remember3')
let checkbox4 = document.getElementById('remember4')
let checkbox5 = document.getElementById('remember5')
checkbox1.addEventListener("click", function () {

    checkbox2.checked = false;
    checkbox3.checked = false;
    checkbox4.checked = false;
    checkbox5.checked = false;

})
checkbox2.addEventListener("click", function () {

    checkbox1.checked = false;
    checkbox3.checked = false;
    checkbox4.checked = false;
    checkbox5.checked = false;

})
checkbox3.addEventListener("click", function () {

    checkbox2.checked = false;
    checkbox1.checked = false;
    checkbox4.checked = false;
    checkbox5.checked = false;

})
checkbox4.addEventListener("click", function () {

    checkbox2.checked = false;
    checkbox3.checked = false;
    checkbox1.checked = false;
    checkbox5.checked = false;

})
checkbox5.addEventListener("click", function () {

    checkbox2.checked = false;
    checkbox3.checked = false;
    checkbox4.checked = false;
    checkbox1.checked = false;

})
let checkbox6 = document.getElementById('remember6')
let checkbox7 = document.getElementById('remember7')
let checkbox8 = document.getElementById('remember8')
let checkbox9 = document.getElementById('remember9')
let checkbox10 = document.getElementById('remember10')
checkbox6.addEventListener("click", function () {

    checkbox7.checked = false;
    checkbox8.checked = false;
    checkbox9.checked = false;
    checkbox10.checked = false;
})
checkbox7.addEventListener("click", function () {

    checkbox6.checked = false;
    checkbox8.checked = false;
    checkbox9.checked = false;
    checkbox10.checked = false;
})
checkbox8.addEventListener("click", function () {

    checkbox7.checked = false;
    checkbox6.checked = false;
    checkbox9.checked = false;
    checkbox10.checked = false;
})
checkbox9.addEventListener("click", function () {

    checkbox7.checked = false;
    checkbox8.checked = false;
    checkbox6.checked = false;
    checkbox10.checked = false;
})
checkbox10.addEventListener("click", function () {

    checkbox7.checked = false;
    checkbox8.checked = false;
    checkbox9.checked = false;
    checkbox6.checked = false;
})
let checkbox11 = document.getElementById('remember11')
let checkbox12 = document.getElementById('remember12')
let checkbox13 = document.getElementById('remember13')
let checkbox14 = document.getElementById('remember14')
let checkbox15 = document.getElementById('remember15')
checkbox11.addEventListener("click", function () {

    checkbox12.checked = false;
    checkbox13.checked = false;
    checkbox14.checked = false;
    checkbox15.checked = false;
})
checkbox12.addEventListener("click", function () {

    checkbox11.checked = false;
    checkbox13.checked = false;
    checkbox14.checked = false;
    checkbox15.checked = false;
})
checkbox13.addEventListener("click", function () {

    checkbox12.checked = false;
    checkbox11.checked = false;
    checkbox14.checked = false;
    checkbox15.checked = false;
})
checkbox14.addEventListener("click", function () {

    checkbox12.checked = false;
    checkbox13.checked = false;
    checkbox11.checked = false;
    checkbox15.checked = false;
})
checkbox15.addEventListener("click", function () {

    checkbox12.checked = false;
    checkbox13.checked = false;
    checkbox14.checked = false;
    checkbox11.checked = false;
})