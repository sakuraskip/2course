debugger
function makeCounter()
{
    let currentCount = 1;

    return function ()
    {
        return currentCount++;
    };
}

let counter = makeCounter();

console.log(counter())
console.log(counter())
console.log(counter())
let counter2 = makeCounter();
console.log(counter2())

///////////////////////////////
let currentCount = 1;

function makeCounter2()
{
    return function ()
    {
        return currentCount++;
    };
}
console.log("\n вариант 2")
let counter3 = makeCounter2();
let counter4 = makeCounter2();

console.log(counter3())
console.log(counter3())

console.log(counter4())
console.log(counter4())
/////////////////////////////task2
function volume(a)
{
    return (b,c)=>
    {
        return a*b*c;
    }
}

const countVolume = volume(15);
console.log(countVolume(30,15));
countVolume(15,30);
console.log(volume(35)(15,45));
///////////////////////////////////
function* task3() {
    let x = 0;
    let y = 0;
    for (let j = 0; j < 10; j++) {
        const moveDirection = yield {x, y};

            switch (moveDirection) {
                case "left":
                    x = x - 5;
                    break;
                case "up":
                    y = y + 5;
                    break;
                case "right":
                    x = x + 5;
                    break;
                case "down":
                    y = y - 5;
                    break;
                default:
                    console.log("ГОЛ пошло не по плану")
            }
        console.log(`позиция: x = ${x},y = ${y}`);
        }

        let windowTest = 1232;

}



let generator = task3();
generator.next()

for (let i = 0; i < 10; i++) {
    const moveDirection = prompt("введите left, right, up, down, что-то из этого");
generator.next(moveDirection);
}

//////////////////////////////////
window.weakmap = new Map();
window.counter3 = 1221;
window.windowTest = "ээээ";
console.log(windowTest);
