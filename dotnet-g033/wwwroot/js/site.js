//Index Filter
function filterFunction() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("naam");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
function filterVerantwoordelijkeFunction() {

    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("verantwoordelijke");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

// OpenzettenIndex filters
function filterOpenzettenFunction() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("naam");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
function filterVerantwoordelijkeOpenzettenFunction() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("verantwoordelijke");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[2];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

// Star rating
$(':radio').change(function () {
    console.log('New star rating: ' + this.value);
});

submitForm = function () {
    document.getElementById("form1").submit();
}

const init = function () {
    const form = document.getElementById("formInschrijven");
    const node = document.getElementById("gebruikerToevoegen");
    if (node != null && form != null) {
        node.addEventListener("keyup", function (event) {
            if (event.keyCode === 13) {
                form.form.submit();
            }
        });
    }
};



window.onload = init;