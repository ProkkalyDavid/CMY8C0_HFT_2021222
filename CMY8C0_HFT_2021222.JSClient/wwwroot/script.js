let cars = [];

getdata();

async function getdata() {
    await fetch('http://localhost:43002/car')
        .then(x => x.json())
        .then(y => {
            cars = y;
            console.log(cars);
            display();
        });
}

function display() {
    cars.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td></tr>";
    });
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