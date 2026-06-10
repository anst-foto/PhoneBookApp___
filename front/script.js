const button = document.getElementById('button_getAll');
const output = document.getElementById('output');

button.addEventListener('click', async () => {
    output.innerHTML = '';

    const url = 'http://localhost:5202/persons';
    let response = await fetch(url);
    if (response.ok) {
        let json = await response.json();
        for (const person of json) {
            console.debug(person);

            for (const key in person) {
                console.log(person[key]);

                output.innerHTML += `
                <p><b>${key}</b>: ${person[key]}</p>
                `;
            }
            output.innerHTML += '<hr />';
        }
    } else {
        alert("Ошибка HTTP: " + response.status);
    }
})