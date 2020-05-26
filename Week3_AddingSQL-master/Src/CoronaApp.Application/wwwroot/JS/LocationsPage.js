'use strict'

let row = 0;
let patientToSave = { patientId: "", locationsList: [] };
const helloTitle = document.createElement('h1');
helloTitle.innerText = 'Hello Epidemiological Report';
document.body.appendChild(helloTitle);

const patientId = document.createElement('h2');
patientId.innerText = 'Report Your Path';
document.body.appendChild(patientId);

const bodyTableRows = document.createElement('tbody');
bodyTableRows.id = 'bodyTableRows';

const buttonsDiv = document.createElement('div');
buttonsDiv.id = 'buttonsDiv';
const inputsDiv = document.createElement('div');
inputsDiv.id = 'inputsDiv';
const tableDiv = document.createElement('div');
tableDiv.id = 'tableDiv';
const locationsTable = document.createElement('table');
const bodyTable = document.createElement('tbody');

const patientIdInput = document.createElement('input');
patientIdInput.setAttribute("type", "text");
patientIdInput.placeholder = 'Patient ID';
patientIdInput.id = 'PatientID';
patientIdInput.classList.add("locationInput");
patientIdInput.maxLength = 9;
document.body.appendChild(patientIdInput);
patientIdInput.addEventListener("keyup", getLocationsById);

const colValues = ['Start date', 'End date', 'city', 'location', 'remove'];
const tableRow = document.createElement('tr');
tableRow.classList.add("tableRow");
tableRow.id = row;
for (let k = 0; k < 5; k++) {
    const tableCol = document.createElement('th');
    tableCol.innerText = colValues[k];
    tableCol.classList.add("tableCol");
    tableCol.id = k + ',' + row;
    tableRow.appendChild(tableCol);
}
bodyTable.appendChild(tableRow);
const thDiv = document.createElement('div');
row++;

const startDateInput = document.createElement('input');
startDateInput.setAttribute("type", "date");
startDateInput.placeholder = 'Start date';
startDateInput.id = 'startDateInput';
startDateInput.classList.add("locationInput");
inputsDiv.appendChild(startDateInput);
//document.body.appendChild(startDateInput);

const endDateInput = document.createElement('input');
endDateInput.setAttribute("type", "date");
endDateInput.placeholder = 'End date';
endDateInput.id = 'endDateInput';
startDateInput.classList.add("locationInput");
inputsDiv.appendChild(endDateInput);
//document.body.appendChild(endDateInput);

const cityInput = document.createElement('input');
cityInput.setAttribute("type", "text");
cityInput.placeholder = 'City';
cityInput.id = 'cityInput';
cityInput.classList.add("locationInput");
inputsDiv.appendChild(cityInput);
//document.body.appendChild(cityInput);

const locationInput = document.createElement('input');
locationInput.setAttribute("type", "taxt");
locationInput.placeholder = 'location';
locationInput.id = 'locationInput';
locationInput.classList.add("locationInput");
inputsDiv.appendChild(locationInput);
inputsDiv.style.display = "none";
//document.body.appendChild(locationInput);

const addLocationBtn = document.createElement('button');
addLocationBtn.innerText = 'Add location';
buttonsDiv.appendChild(addLocationBtn);
//document.body.appendChild(addLocationBtn);
addLocationBtn.addEventListener("click", function () {
    let report = {
        rowId: row,
        id: document.getElementById('PatientID').value,
        startDate: document.getElementById('startDateInput').value,
        endDate: document.getElementById('endDateInput').value,
        city: document.getElementById('cityInput').value,
        locations: document.getElementById('locationInput').value
    };

    let location = {        
        startDate: document.getElementById('startDateInput').value,
        endDate: document.getElementById('endDateInput').value,
        city: document.getElementById('cityInput').value,
        locations: document.getElementById('locationInput').value
    };
    patientToSave.patientId = document.getElementById('PatientID').value;
    patientToSave.locationsList.push(location);
    document.getElementById('startDateInput').value = "";
    document.getElementById('endDateInput').value = "";
    document.getElementById('cityInput').value = "";
    document.getElementById('locationInput').value = "";
    localStorage.setItem([row, document.getElementById('PatientID').value], JSON.stringify(report));
    addTable(report, 1);

});

const saveLocationsBtn = document.createElement('button');
saveLocationsBtn.innerText = 'Save locations';
buttonsDiv.appendChild(saveLocationsBtn);
//document.body.appendChild(saveLocationsBtn);

buttonsDiv.style.display = "none";
saveLocationsBtn.addEventListener('click', saveLocations)

locationsTable.appendChild(bodyTable);
tableDiv.appendChild(locationsTable);
document.body.appendChild(tableDiv);
document.body.appendChild(inputsDiv);
document.body.appendChild(buttonsDiv);

function getLocationsById() {
    if (patientIdInput.value.length === 9) {
        let c = true;
        if (c) {
            clearTable();
            c = false;
        }
        inputsDiv.style.display = "block";
        buttonsDiv.style.display = "block";
       

        //ajax to getLocationsById
        var xhttp = new XMLHttpRequest();

        xhttp.onreadystatechange = function () {

            if (this.readyState == 4 && this.status == 200) {

                var locations = JSON.parse(xhttp.responseText);
                debugger;
                if (locations.locationsList.length == 1) {
                    addTable(locations.locationsList[0], 1);
                }
                else {
                    addTable(locations.locationsList, locations.locationsList.length);
                }
            }


        };
        xhttp.open("GET", "/api/Patient?patientId=" + document.getElementById('PatientID').value, true);
        xhttp.send();
    }
}


function saveLocations() {
        
    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 200) {
            clearTable();
        }
        else {
            alert("error!");
        }
    }

    xhttp.open("POST", "/api/Patient", true);
    xhttp.setRequestHeader('Content-Type', 'application/json');
    xhttp.send(JSON.stringify(patientToSave));
}

function removeRow(rowNumber, patient) {
    let rowToDelete = document.getElementById(rowNumber);
    rowToDelete.remove();
    localStorage.removeItem([rowNumber, patient.id]);
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            console.log("The location deleted successfully");
        }
        else {
            console.log("error!");
        }
    }

    xhttp.open("DELETE", "/api/Patient", true);
    xhttp.setRequestHeader('Content-Type', 'application/json');
    xhttp.send(JSON.stringify(patient));
}

function clearTable() {
    if (document.getElementById('bodyTableRows') != null) {
        document.getElementById('bodyTableRows').innerHTML = "";
    }
}

function addTable(patient, numberOfRows) {
    let current;
    for (let index = 0; index < numberOfRows; index++) {
        if (numberOfRows === 1) {
            current = patient;
        }
        else {
            current = patient[index];
        }
        const reportValues = [current.startDate, current.endDate, current.city, current.locations, 'x'];
        const tableRow = document.createElement('tr');
        tableRow.classList.add("tableRow");
        tableRow.id = row;
        for (let k = 0; k < 5; k++) {
            const currentRow = row;
            let tableCol = document.createElement('td');
            tableCol.innerText = reportValues[k];
            tableCol.id = k + ',' + currentRow;
            tableCol.classList.add("tableCol");
            if (k === 4) {
                tableCol = document.createElement('button');
                tableCol.innerText = 'x';
                tableCol.addEventListener("click", function () {
                    removeRow(currentRow, current);
                });
            }
            tableRow.appendChild(tableCol);
        }
        bodyTableRows.appendChild(tableRow);
        row++;
    }
    locationsTable.appendChild(bodyTableRows);
}
//locationsTable.appendChild(bodyTable);
//tableDiv.appendChild(locationsTable);
//tableDiv.style.display = "none";
//document.body.appendChild(tableDiv);