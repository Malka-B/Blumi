const helloTitle = document.createElement('h2');
helloTitle.innerText = 'Hello';
document.body.appendChild(helloTitle);

const input = ["hello", "girls", "good", "afternoon"];

var myPromise = new Promise(function (resolve, reject) {
    window.setTimeout(() => {
        resolve(Math.floor(Math.random() * 10 + 1));  // Promise resolved! :)
        reject("error"); // Promise rejected! :(
    }, 3000);
}
);

myPromise.then(paramater => {
    alert(paramater);
}, parameter2 => {
    alert(parameter2);
})

let makeAllCaps = (input) => {
    return new Promise((resolve, reject) => {
        input.forEach(element => {
            if (typeof (element) != 'string') {
                reject("Sorry, can't sort something not string");
            }
            element = element.toUpperCase();
        });
        resolve(input);
    });
}

let sortWords = (result) => {
    result.sort();
    console.log(result);

}

makeAllCaps(input)
    .then(result => sortWords(result))
    .catch(fromReject => console.log(`Problem: ${fromReject}`));


