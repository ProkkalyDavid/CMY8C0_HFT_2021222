let cars = [];
let connection;
getdata();
setupSignalR();

function setupSignalR() {
        connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:43002/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CarCreated", (user, message) => {
        getdata();
    });
    connection.on("CarDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:43002/car')
        .then(x => x.json())
        .then(y => {
            cars = y;
            //console.log(cars);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    cars.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>` + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:43002/car/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null })
        .then(response => response)
        .then(data => {
            console.log('Succes:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); })
}

function create() {
    let name = document.getElementById('carName').value;
    fetch('http://localhost:43002/car', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name})})
        .then(response => response)
        .then(data =>
        {
            console.log('Succes:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); })
}