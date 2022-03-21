var th = `<tr>
                    <th style="width: 3%;">Sıra</th>
                    <th style="width: 25%;">İsim Soyisim</th>
                    <th style="width: 14%;">Telefon Numarası</th>
                    <th style="width: 48%;">Adres</th>
                    <th style="width: 10%"></th>
                </tr>`
var buttons = {
    deleteBtn: `<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x" viewBox="0 0 16 16">
    <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"/>
    </svg>`,
    updateBtn: `<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-clockwise" viewBox="0 0 16 16">
        <path fill-rule="evenodd" d="M8 3a5 5 0 1 0 4.546 2.914.5.5 0 0 1 .908-.417A6 6 0 1 1 8 2v1z" />
        <path d="M8 4.466V.534a.25.25 0 0 1 .41-.192l2.36 1.966c.12.1.12.284 0 .384L8.41 4.658A.25.25 0 0 1 8 4.466z" />
        </svg>`,
    salesBtn: `<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-currency-dollar" viewBox="0 0 16 16">
  <path d="M4 10.781c.148 1.667 1.513 2.85 3.591 3.003V15h1.043v-1.216c2.27-.179 3.678-1.438 3.678-3.3 0-1.59-.947-2.51-2.956-3.028l-.722-.187V3.467c1.122.11 1.879.714 2.07 1.616h1.47c-.166-1.6-1.54-2.748-3.54-2.875V1H7.591v1.233c-1.939.23-3.27 1.472-3.27 3.156 0 1.454.966 2.483 2.661 2.917l.61.162v4.031c-1.149-.17-1.94-.8-2.131-1.718H4zm3.391-3.836c-1.043-.263-1.6-.825-1.6-1.616 0-.944.704-1.641 1.8-1.828v3.495l-.2-.05zm1.591 1.872c1.287.323 1.852.859 1.852 1.769 0 1.097-.826 1.828-2.2 1.939V8.73l.348.086z"/>
</svg>`
}
var button = document.getElementById("addButton")

getItems()

//Sayfa açıldığında liste çağırılır. GET
function getItems() {
    var table = document.querySelector(".list")
    fetch("https://localhost:5000/api/customer")
        .then(response => response.json())
        .then(customer => {
            table.innerHTML = " "
            table.innerHTML = th
            for (var i in customer) {
                table.innerHTML += `<tr>
                           <td> ${parseInt(i) + 1}</td>
                           <td> ${customer[i].name + " " + customer[i].surName}</td>
                           <td> ${customer[i].phone}</td>
                           <td> ${customer[i].address}</td>
                           <td> <span class="btn" onclick="deleteData(${customer[i].customerId})">${buttons.deleteBtn}</span>
                                <span class="btn" onclick="onEdit(${customer[i].customerId})">${buttons.updateBtn}</span>
                                <a class="btn"  href="/sales?ıd=${customer[i].customerId}">${buttons.salesBtn}</a>
                           </td>
                        </tr>`
                i++
            }
        });
}

//Db ye veri ekleme yapılır ve sonunda liste çağırılır. POST
button.addEventListener("click", function () {
    var data = readInput();
    if (validate(data) == true && button.innerHTML == "Ekle") {
        fetch("https://localhost:5000/api/customer", {
            method: 'POST',
            body: JSON.stringify({
                name: data.name,
                surName: data.surName,
                phone: data.phone,
                address: data.address
            }),
            headers: { "Content-type": "application/json; charset=UTF-8" }
        }).then(res => { getItems(); resetInput(); })
    }
})

//Db den veri silme DELETE
function deleteData(id) {
    fetch(`https://localhost:5000/api/customer/${id}`, {
        method: 'DELETE'
    })
        .then(res => { getItems(); })
}

//Db de verileri güncellememize yarar UPDATE
function updateData(id) {
    button.innerHTML = "Düzenle"
    if (button.innerHTML == "Düzenle") {
        button.addEventListener("click", function () {
            var data = readInput();
            if (validate(data) == true) {
                fetch(`https://localhost:5000/api/customer/${id}`, {
                    method: 'PUT',
                    body: JSON.stringify({
                        "name": data.name,
                        "surName": data.surName,
                        "phone": data.phone,
                        "address": data.address
                    }),
                    redirect: 'follow',
                    headers: { "Content-type": "application/json; charset=UTF-8" }
                }).then(res => {
                    getItems();
                    id = 1;
                    button.innerHTML = "Ekle"
                    resetInput();
                })
            }
        })
    }
}

//Sayfadaki text inputları okur ve data isimli bir object döner.
function readInput() {
    var data = {};
    data["name"] = document.getElementById("name").value;
    data["surName"] = document.getElementById("surName").value;
    data["phone"] = document.getElementById("phone").value;
    data["address"] = document.getElementById("address").value;
    return data;
}

//Düzenlenecek olan veriyi sayfadaki inputlara doldurur ve updateData yı çalıştırır
function onEdit(id) {
    fetch(`https://localhost:5000/api/customer/${id}`, {
        method: 'GET'
    })
        .then(response => response.json())
        .then(customer => {
            document.getElementById("name").value = customer.name
            document.getElementById("surName").value = customer.surName
            document.getElementById("phone").value = customer.phone
            document.getElementById("address").value = customer.address
        })
    updateData(id)
}

//Sayfadaki text inputları silmemize yarar.
function resetInput() {
    document.getElementById("name").value = "";
    document.getElementById("surName").value = "";
    document.getElementById("phone").value = "";
    document.getElementById("address").value = "";
}

//Sayfadaki inputlar doğru doldurulmuşmu diye kontrol eder.
function validate(tableData) {
    if (tableData.name == "") { alert("İsim bilgisini giriniz!!"); return false }
    else if (tableData.phone == "") { alert("Telefon bilgisini giriniz!!"); return false }
    else if (tableData.address == "") { alert("Adres bilgisini giriniz!!"); return false }
    else { return true }
}

