
//7-8



console.log("\n\n")


let promise2 = new Promise((res,rej)=>
    {
        res('resolved promise -3 ')
    })
    
    promise2.then((res)=>
    {
        console.log(res)
        return res
    })
    .then((res1)=>
    {
        console.log(res1)
    })

