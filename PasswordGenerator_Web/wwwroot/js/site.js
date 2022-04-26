// Creating the variables for later use
var lengthOfPassword;
var freeCharacters;
var selects;
var errorDiv;
var remainingCharactersText;

var lengthSelect;

var isLetter;
var letterSelect;

var isNumber;
var numberSelect;

var isSymbol;
var symbolSelect;

var selectDict;

var submitButton;

var resultButton;

// Running the following script on page load
// Getting all the neccessary HTML elements for the javascript to opareate as it should
window.onload = function () {
    lengthSelect = document.getElementById("lengthSelect");
    errorDiv = document.getElementById("errorDiv");
    remainingCharactersText = document.getElementById("freeCharacters");

    isLetter = document.getElementById("isLetter");
    letterSelect = document.getElementById("letterSelect");

    isNumber = document.getElementById("isNumber");
    numberSelect = document.getElementById("numberSelect");

    isSymbol = document.getElementById("isSymbol");
    symbolSelect = document.getElementById("symbolSelect");

    selectDict = {
        "isLetter": letterSelect,
        "isNumber": numberSelect,
        "isSymbol": symbolSelect
    }

    submitButton = document.getElementById("submitButton");

    resultButton = document.getElementById("resultButton");

    selects = [letterSelect, numberSelect, symbolSelect];

    for (var i = 6; i <= 25; i++) {
        var opt = document.createElement("option");
        opt.innerHTML = i;
        opt.value = i;
        lengthSelect.appendChild(opt);
    }
    lengthOfPassword = lengthSelect.value;
    freeCharacters = lengthOfPassword;
    document.getElementById("freeCharacters").innerHTML = freeCharacters;
}

// This method is responsible to checik a switch's state and after changeing it the right way, disable or enable the selector connected to it, then send a "SwitchClicked()" method.
function IsSwitchClicked(obj) {
    if (obj.hasAttribute("checked")) {
        obj.removeAttribute("checked");
        selectDict[obj.id].setAttribute("disabled", "");
        SwitchClicked(selectDict[obj.id], selectDict[obj.id].hasAttribute("disabled"));
    }
    else {
        obj.setAttribute("checked", "");
        selectDict[obj.id].removeAttribute("disabled");
        SwitchClicked(selectDict[obj.id], selectDict[obj.id].hasAttribute("disabled"));
    }
}

// Every time a switch has been clicked, depending on the state if it (switch),
// deleting or deleting and refilling the select elements.
function SwitchClicked(element, on) {
    while (element.firstChild) {
        element.firstChild.remove();
    }

    if (!on) {
        for (var i = 0; i <= lengthOfPassword; i++) {
            var opt = document.createElement("option");
            opt.innerHTML = i;
            opt.value = i;
            element.appendChild(opt);
        }
    }
}

// Whenever a new number has been chosen, the wollowing srcipt will calculate
// the remaining number of characters to be used, and changing the style of the 
// indicator text to the right color.
function SelectChange() {
    freeCharacters = lengthOfPassword;
    for (var i = 0; i < selects.length; i++) {
        if (!selects[i].hasAttribute("disabled")) {
            freeCharacters -= selects[i].value;
        }
    }
    if (freeCharacters < 0 && errorDiv.classList.contains("text-secondary")) {
        errorDiv.classList.remove("text-secondary");
        errorDiv.classList.add("text-danger");
    }
    else if (freeCharacters >= 0 && errorDiv.classList.contains("text-danger")) {
        errorDiv.classList.remove("text-danger");
        errorDiv.classList.add("text-secondary");
    }
    remainingCharactersText.innerHTML = freeCharacters;
    ButtonUpdate()
}

// Updates the "Submit" button's state depending on the number of characters left.
function ButtonUpdate() {
    if (freeCharacters < 0 && !submitButton.hasAttribute("disabled"))
        submitButton.setAttribute("disabled", "");
    else if (freeCharacters >= 0 && submitButton.hasAttribute("disabled"))
        submitButton.removeAttribute("disabled");
}

// Every time the length of the password has been changed, this script will trigger a refill on all the selects.
function LengthSelected() {
    lengthOfPassword = lengthSelect.value;
    for (var i = 0; i < selects.length; i++) {
        if (!selects[i].hasAttribute("disabled")) {
            SwitchClicked(selects[i], selects[i].hasAttribute("disabled"));
        }
    }
    SelectChange();
}

// Copies the innerHTML to the PC's clipboard.
function CopyToClipBoard() {
    navigator.clipboard.writeText(resultButton.innerHTML);
}