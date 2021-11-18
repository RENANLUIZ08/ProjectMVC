var url = "https://desafioonline.webmotors.com.br/api/OnlineChallenge";

var selectionMarca = document.getElementById("selMarca");
var selectionModelo = document.getElementById("selModelo");
var selectionVersao = document.getElementById("selVersao");

var hiddenMarca = document.getElementById("marca");
var hiddenModelo = document.getElementById("modelo");
var hiddenVersao = document.getElementById("versao");

window.onload = async function () {
    await CallApi("Make", selectionMarca, hiddenMarca.value);
}

async function CallApi(uriApi, selection, value) {
    var Api = `${url}/${uriApi}`;
    var objs = {};
    var nameSelection = selection.options[0].text;
    selection.options[0].text = "Aguarde...";

    var xhttp = new XMLHttpRequest();
    await xhttp.open("GET", Api, true);
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            objs = JSON.parse(xhttp.responseText);
            objs.forEach(function (obj) {
                var option = document.createElement('option');
                option.value = obj.ID;
                option.innerHTML = obj.Name;
                if (value == obj.Name) {
                    option.selected = true;
                    selection.appendChild(option);
                    selection.onchange();
                }
                else {
                    selection.appendChild(option);
                }
                //default selection
                selection.options[0].text = nameSelection;
            })

        }
    }
    xhttp.send();
}

async function ChangeMake(selection) {

    var value = selection.value;
    var text = selection.options[selection.selectedIndex].text;

    if (text == hiddenMarca.value) {
        ClearSelection([selectionModelo, selectionVersao]);
    }
    else {
        ClearSelection([selectionModelo, selectionVersao], [hiddenModelo, hiddenVersao]);
    }

    if (value != '0') {
        document.getElementById("marca").value = text;
        await CallApi(`Model?MakeId=${value}`, selectionModelo, hiddenModelo.value);
    }
    else {
        document.getElementById("marca").value = "";
    }
}

async function ChangeModel(selection) {
    var value = selection.value;
    var text = selection.options[selection.selectedIndex].text;

    if (text == hiddenModelo.value) {
        ClearSelection([selectionVersao]);
    }
    else {
        ClearSelection([selectionVersao], [hiddenVersao]);
    }

    if (value != '0') {
        document.getElementById("modelo").value = text;
        await CallApi(`Version?ModelId=${value}`, selectionVersao, hiddenVersao.value);
    }
    else {
        document.getElementById("modelo").value = "";
    }
}

async function ChangeVersion(selection) {
    var value = selection.value;
    var text = selection.options[selection.selectedIndex].text;
    if (value != '0') {
        document.getElementById("versao").value = text;
    }
    else {
        document.getElementById("versao").value = "";
    }

}

function ClearSelection(selections, hiddens) {
    for (var i = 0; i < selections.length; i++) {
        if (selections[i].options.length > 1) {
            for (x = selections[i].options.length - 1; x > 0; x--) {
                selections[i].options.remove(x);
            }
        }
    }

    if (hiddens !== undefined) {
        for (var i = 0; i < hiddens.length; i++) {
            hiddens[i].value = "";
        }
    }
}