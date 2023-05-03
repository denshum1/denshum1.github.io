
async function getAllGoods() {
    var result = await fetch("https://localhost:7278/api/Good1");
    console.log(result);

 if (result.status !== 200) {
     console.log('Ошибка: ' + result.status);
     return;
 }
 var data = await result.json();
 for (let i = 0; i < data.length; i++) {
     console.log(data[i]);
     addGoodCard(data[i]);
 }
 
}
function addGoodCard(good) {
    let list = document.getElementById('goods-list');
    let card = document.createElement('div');
    card.className = "card";

    card.innerHTML =
        '<img src="' + 'https://prezentacii.org/upload/cloud/18/09/75772/images/screen11.jpg' + '" alt="Denim Jeans" style="width:100%">' +
        '<h1>' + good.name + '</h1>' +
        '<p class="price">' + good.price + '</p>' +
        '<p>' + good.description + '</p>' +
        '<p><button>Add to Cart</button></p>';


    list.appendChild(card);
}
getAllGoods();