
//7-8
let promise = new Promise((res,rej)=>
{
    res('resolved promise 1')
})

promise.then((res)=>
{
    console.log('resolved promise 2')
    return 'OK'
})
.then((res)=>
{
    console.log(res)
})


console.log("\n\n")


let promise2 = new Promise((res,rej)=>
    {
        res('resolved promise -3 ')
    })
    
    promise2.then((res)=>
    {
        console.log(res)
        return 'ok'
    })
    .then((res1)=>
    {
        console.log(res1)
    })