let pr1 = new Promise<number>((res,rej)=>
    {
        res(21)
    })
    pr1.then((value:number)=>{console.log(value); return value;})
    .then((value)=>console.log(value*2))
    
    async function return21()
    {
        return 21;
    }
    
    async function task6()
    {
        let num = await return21();
        console.log(num);
        console.log(num*2);
    }
    
    task6();