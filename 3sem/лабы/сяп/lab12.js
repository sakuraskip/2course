class Sudoku
{
    constructor()
    {
        this.board = this.newfield()
    }
    generatefield()
    {
        for(let i=0;i<20;i++)
        {
            let testrow = Math.floor(Math.random()*9);
            let testcol = Math.floor(Math.random()*9);
            while(this.board[testrow][testcol] ==0)
            {
                testrow = Math.floor(Math.random()*9);
                testcol = Math.floor(Math.random()*9);
            }
            this.board[testrow][testcol] = 0; 
        }
        console.log(this.board);
    }
    completesudoku()
    {
        for(let num =1;num<=9;num++)
        {
            for(let row =0;row<9;row++)
            {
                for(let col =0;col<9;col++)
                {
                   if(this.board[row][col] == 0)
                   {
                      this.placeNum(num,col,row);
                   }
                }
            }
        }
        console.log(this.board);

    }
    newfield()
    {
        const board = [];
        const row1 = [6,7,2,1,5,4,9,3,8];
        const row2 = [3,5,4,2,8,9,1,6,7];
        const row3 = [8,1,9,3,7,6,2,5,4];
        const row4 = [7,2,1,6,4,3,8,9,5];
        const row5 = [9,4,8,5,1,2,3,7,6];
        const row6 = [5,6,3,8,9,7,4,1,2];
        const row7 = [4,8,5,7,3,1,6,2,9];
        const row8 = [2,3,7,9,6,8,5,4,1];
        const row9 = [1,9,6,4,2,5,7,8,3];
        board.push(row1); board.push(row2); board.push(row3);
        board.push(row4);board.push(row5);board.push(row6);
        board.push(row7);board.push(row8);board.push(row9);
        return board;
    }
    placeNum(num,col,row)
    {
        if(this.checkrow(num,row) && this.checkcolumn(num,col) && this.checksquare(num,row,col))
        {
            this.board[row][col] = num;
            console.log(`поставил цифру ${num} в строку ${row+1} в столбец ${col+1}`);
        }
    }
    checkrow(num,row)
    {
        for(let i=0;i<9;i++)
        {
            if(this.board[row][i] === num)
            {
                console.log("ошибочная строка: " +i);
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
                console.log("ошибочный столбец: "+ i);
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
fd.placeNum(8,1,4);

//

