class Sudoku
{
    constructor()
    {
        this.board = this.newfield()
    }
    generatefield()
    {
       let testrow = Math.floor(Math.random()*9);
       let testcol = Math.floor(Math.random()*9);
       let testnum = Math.floor(Math.random()*9);
       this.board[testrow][testcol] = testnum;
        for(let num =1;num <=9;num++)
        {
            for(let row =0;row<9;row++)
            {
                for(let col =0;col<9;col++)
                {
                    if(this.board[row][col] === 0 &&this.checkrow(num,row) && this.checkcolumn(num,col) && this.checksquare(num,row,col))
                    {
                        this.board[row][col] = num;
                    }
                }
            }
        }
        console.log(this.board);
    }
    newfield()
    {
        const board = [];
        for (let i = 0; i < 9; i++) {
            const row = Array(9).fill(0); 
            board.push(row);
        }
        return board;
    }
    placeNum(num,col,row)
    {
        if(this.checkrow(num,row) && this.checkcolumn(num,col) && this.checksquare(num,row,col))
        {
            this.board[row][col] = num;
        }
    }
    checkrow(num,row)
    {
        for(let i=0;i<9;i++)
        {
            if(this.board[row][i] === num)
            {
                //console.log("ошибочная строка: " +i);
                return false;
            }
        }
        return true;
    }
    checkcolumn(num,col)
    {
        for(let i=0;i<9;i++)
        {
            if(this.board[i][col] === num)
            {
               // console.log("ошибочный столбец: "+ i);
                return false;
            }
        }
        return true;
    }
    checksquare(num,row,col)
    {
        const firstrowInBox = Math.floor(row/3)*3;
        const firstColInBox = Math.floor(col/3)*3;

        for(let row1 = firstrowInBox; row1<firstrowInBox+3;row1++)
        {
            for(let col1 = firstColInBox; col1<firstColInBox+3;col1++)
            {
                if(this.board[row1][col1] === num)
                {
                    return false;
                }
            }
        }
        return true;
    }

}

const fd = new Sudoku();

fd.generatefield()