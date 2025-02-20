class Sudoku {
    constructor() {
        this.board = this.newfield();
         this.errorRows = new Set();
        this.errorColumns = new Set();
        this.errorSquares = new Set();
    }
   
    generatefield() {
        this.completesudoku();
        for (let i = 0; i < 20; i++) {
            let testrow = Math.floor(Math.random() * 9);
            let testcol = Math.floor(Math.random() * 9);
            while (this.board[testrow][testcol] === 0)
            {
                testrow = Math.floor(Math.random() * 9);
                testcol = Math.floor(Math.random() * 9);
            }
            this.board[testrow][testcol] = 0;
        }
        console.log(this.board);
        this.errorRows.clear();
        this.errorColumns.clear();
        this.errorSquares.clear();
    }

    completesudoku() {
        const numbers = this.shuffleArray();
        for (let row = 0; row < 9; row++)
        {
            for (let col = 0; col < 9; col++)
            {
                if (this.board[row][col] === 0)
                { 
                    for (let num of numbers)
                    {
                        if (this.placeNum(num, col, row))
                        {
                            if (this.completesudoku())
                            { 
                                return true;
                            }
                            this.board[row][col] = 0;
                        }
                    }
                    return false;
                }
            }
        }
        return true;
    }
    checkBoard() {
        let норм = true;
        let allcells = document.querySelectorAll(".cell");
        allcells.forEach(cell => {
        let row = parseInt(cell.dataset.row);
        let col = parseInt(cell.dataset.col);
        let square = Math.floor(row / 3) * 3 + Math.floor(col / 3);
        
                if ((this.errorRows.has(row) || this.errorColumns.has(col) || this.errorSquares.has(square))) {
                    норм = false;
                    cell.id = "sadmoment";
                } else if(this.isCompleted()) {
                    cell.id = "good";
                }
                else{
                    cell.id ="";
                }
            });
            this.errorRows.clear();
            this.errorColumns.clear();
            this.errorSquares.clear();
            return норм;
        }

    newfield() {
        const board = Array.from({ length: 9 }, () => Array(9).fill(0));
        return board;
    }

    placeNum(num, col, row)
    {
        console.log(num);
        if (this.checkrow(num, row) && this.checkcolumn(num, col) && this.checksquare(num, row, col))
        {
            this.board[row][col] = num;

            return true;
        }
        return false;
    }
    playerPlaceNum(num,col,row)
    {
        this.checkrow(num, row);
        this.checkcolumn(num, col);
        this.checksquare(num, row, col);
        this.board[row][col] = num;
        console.log(`поставил цифру ${num} в строку ${row} в столбец ${col}`);
    }

    checkrow(num, row) {
        for (let i = 0; i < 9; i++)
        {
            if (this.board[row][i] === num)
            {
                console.log("ошибочная строка: " + i);
                this.errorRows.add(row);
                return false; 
            }
        }
        return true;
    }

    checkcolumn(num, col)
    {
        for (let i = 0; i < 9; i++)
        {
            if (this.board[i][col] === num)
            {
                console.log("ошибочный столбец: " + i);
                this.errorColumns.add(col);
                return false; 
            }
        }
        return true;
    }

    checksquare(num, row, col) {
        const firstrowInBox = Math.floor(row / 3) * 3;
        const firstColInBox = Math.floor(col / 3) * 3;
    
       
        for (let row1 = firstrowInBox; row1 < firstrowInBox + 3; row1++)
        {
            for (let col1 = firstColInBox; col1 < firstColInBox + 3; col1++)
            {
                if (this.board[row1][col1] === num)
                {
                    this.errorSquares.add(Math.floor(firstrowInBox / 3) * 3 + Math.floor(firstColInBox / 3));
                    return false; 
                }
            }
        }
        return true; 
    }
    isCompleted()
    {
        for (let row = 0; row < 9; row++)
        {
            for (let col = 0; col < 9; col++)
            {
                if (this.board[row][col] === 0)
                { 
                    return false;
                }
            }
        }
        return true;
    }

    shuffleArray() {
        let array = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        for (let i = array.length - 1; i >= 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [array[i], array[j]] = [array[j], array[i]];
        }
        return array;
    }
}

document.addEventListener('DOMContentLoaded',()=>
{
    const fd = new Sudoku();
    let boardDiv = document.querySelector(".board");
    let newfield = document.getElementById("newfield");
    let checkerrors = document.getElementById("checkerrors");
    let solve = document.getElementById("solve");
    function updateBoard(board)
    {
        boardDiv.innerHTML = "";

        for(let row = 0;row<9;row++)
        {
            for(let col = 0;col<9;col++)
            {
                createCell(row,col,board[row][col]);
            }
        }
    }
    function createCell(row,col,value)
    {
        let newcell = document.createElement("input");
                newcell.type = "text";
                newcell.className = "cell";
                newcell.maxLength = 1;
                newcell.value = value;
                if(newcell.value !=0)
                {
                    newcell.disabled = true;
                }
                newcell.dataset.row = row;
                newcell.dataset.col = col;

                newcell.addEventListener('input',()=>
                {
                    let value = parseInt(newcell.value);
                    const regex = /^[1-9]$/;
                    if(regex.test(value))
                    {
                        fd.playerPlaceNum(value,col,row);
                        newcell.id = "placed";
                    }
                    else
                    {
                        newcell.value = "";
                        fd.board[row][col] = 0;
                    }
                });
                boardDiv.appendChild(newcell);
    }
    newfield.addEventListener('click',()=>
    {
        fd.board = fd.newfield();
        fd.generatefield();
        updateBoard(fd.board);
    });
    checkerrors.addEventListener('click',()=>
    {
        let норм = fd.checkBoard();

        if(норм ===true && fd.isCompleted())
        {
            alert("решено верно");
        }
        else
        {
            alert("решено неверно либо не до конца(");
        }
    });
    solve.addEventListener('click',()=>
    {
        fd.completesudoku();
        fd.errorRows.clear()
        fd.errorColumns.clear()
        fd.errorSquares.clear()
        updateBoard(fd.board);
    });
    updateBoard(fd.board);
   
});


