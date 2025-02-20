class Sudoku {
    constructor() {
        this.board = this.newfield();
    }

    generatefield() {
        for (let i = 0; i < 40; i++) {
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

    newfield() {
        const board = Array.from({ length: 9 }, () => Array(9).fill(0));
        return board;
    }

    placeNum(num, col, row)
    {
        if (this.checkrow(num, row) && this.checkcolumn(num, col) && this.checksquare(num, row, col))
        {
            this.board[row][col] = num;
            console.log(`поставил цифру ${num} в строку ${row + 1} в столбец ${col + 1}`);
            return true;
        }
        return false;
    }

    checkrow(num, row) {
        for (let i = 0; i < 9; i++) {
            if (this.board[row][i] === num) {
                console.log("ошибочная строка: " + i);
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

const fd = new Sudoku();
fd.completesudoku();
fd.generatefield();