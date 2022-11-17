fetch('http://localhost:43002/car')
    .then(x => x.json())
    .then(y => console.log(y));