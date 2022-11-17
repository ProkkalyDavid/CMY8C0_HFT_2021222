let cars = [];
fetch('http://localhost:43002/car')
    .then(x => x.json())
    .then(y => {
        cars = y;
        console.log(cars);
        display();
    });

function display() {
    cars.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td></tr>";
    });
}