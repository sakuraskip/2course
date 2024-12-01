#include "stdafx.h"
#include "Analysis.h"
#define	LT_TI_NULLXDX	-1			// нет элемента таблицы идентификаторов		
namespace Analysis
{
	void lexAnalysis(const In::IN& in, LT::LexTable& lxtable, IT::IdTable& idtable)
	{
		bool isWord = false;

		int tempIndex = 0;
		int lexline = 1;
		int lexPos = 0;

		In::IN intable;

		for (int i = 0; i < in.size; i++)
		{
			char* temp = new char[256] {};

			// Считывание слова
			while (intable.code[in.text[i]] == intable.T && in.text[i] != '\n')
			{
				temp[tempIndex++] = in.text[i++];
				lexPos++;
				isWord = true;
			}

			
			if (isWord)
			{
				if (DoAnalysis(temp, lexline, lxtable, idtable))
				{
					tempIndex = 0;
					i--;
					isWord = false;
					continue;
				}
				else
					throw ERROR_THROW_IN(90, lexline, lexPos); 
			}

			//строковый литерала
			if (in.text[i] == '\'')
			{
				temp[tempIndex++] = in.text[i++];

				while (in.text[i] != '\'')
				{
					if (tempIndex >= TI_STR_MAXSIZE)
						throw ERROR_THROW_IN(91, lexline, lexPos); 

					temp[tempIndex++] = in.text[i++];
				}

				temp[tempIndex] = in.text[i];

				if (DoAnalysis(temp, lexline, lxtable, idtable))
				{
					tempIndex = 0;
					continue;
				}
				else
					throw ERROR_THROW_IN(92, lexline, lexPos);
			}

			//сепаратор или оператор
			if (intable.code[in.text[i]] == intable.S || intable.code[in.text[i]] == intable.O)
			{
				if (in.text[i] == ' ' || in.text[i] == '\t')
					continue;

				temp[tempIndex] = in.text[i];

				if (!DoAnalysis(temp, lexline, lxtable, idtable))
					throw ERROR_THROW_IN(123, lexline, lexPos); 

				lexPos++;
				tempIndex = 0;

				continue;
			}

			if (in.text[i] == '\n')
			{
				lexline++;
				lexPos = 0;
			}
		}
	}

	bool DoAnalysis(char* word, int str_number, LT::LexTable& lexTable, IT::IdTable& idTable)
	{
		static VariableType varType;

		switch (word[0])
		{
		case LEX_COMMA:
			Add(lexTable, { LEX_COMMA ,str_number, LT_TI_NULLXDX });
			return true;
		case LEX_LEFTBRACE:
			Add(lexTable, { LEX_LEFTBRACE,str_number,LT_TI_NULLXDX });
			return true;
		case LEX_RIGHTBRACE:
			Add(lexTable, { LEX_RIGHTBRACE,str_number,LT_TI_NULLXDX });
			return true;
		case LEX_LEFTHESIS:
			Add(lexTable, { LEX_LEFTHESIS,str_number,LT_TI_NULLXDX });
			return true;
		case LEX_RIGHTESIS:
			Add(lexTable, { LEX_RIGHTESIS,str_number,LT_TI_NULLXDX });
			return true;
		case LEX_SEMICOLON:
			Add(lexTable, { LEX_SEMICOLON,str_number,LT_TI_NULLXDX });
			return true;
		case EQUAL:
			Add(lexTable, { EQUAL, str_number, LT_TI_NULLXDX });
			return true;

		case '+':
			Add(lexTable, { LEX_PLUS,str_number,idTable.size - 1 });
			return true;
		case '-':
			Add(lexTable, { LEX_MINUS, str_number, idTable.size - 1 });
			return true;
		case '*':
			Add(lexTable, { LEX_STAR, str_number, idTable.size - 1 });
			return true;
		case '/':
			Add(lexTable, { LEX_DIRSLASH, str_number, idTable.size - 1 });
			return true;
		case '&':
		{
			Add(lexTable, { LEX_AND,str_number,idTable.size - 1 });
			return true;
		}
		case '|': 
		{
			Add(lexTable, { LEX_OR,str_number,idTable.size - 1 });
			return true;
		}
		case '~':
		{
			Add(lexTable, { LEX_XOR,str_number,idTable.size - 1 });
			return true;
		}

		case 'f':
		{
			FST::FST function(FUNCTION(word));
			if (FST::execute(function))
			{
				Add(lexTable, { LEX_FUNCTION, str_number, LT_TI_NULLXDX });
				return true;
			}
			else
				return checkIdentifier(word, str_number, lexTable, idTable, varType);
		}
		case 'i':
		{
			FST::FST integer(INT8(word));
			if (FST::execute(integer))
			{
				Add(lexTable, { LEX_INTEGER, str_number, LT_TI_NULLXDX });

				varType.position = lexTable.size - 1;
				varType.vartype = VariableType::INT8;
				return true;
			}
			else
				return checkIdentifier(word, str_number, lexTable, idTable, varType);
		}
		case 's':
		{
			FST::FST string(STRING(word));
			if (FST::execute(string))
			{
				Add(lexTable, { LEX_STRING, str_number, LT_TI_NULLXDX });

				varType.position = lexTable.size - 1;
				varType.vartype = VariableType::STR;
				return true;
			}
			else
				return checkIdentifier(word, str_number, lexTable, idTable, varType);
		}

		case 'd':
		{
			FST::FST declare(DECLARE(word));
			if (FST::execute(declare))
			{
				Add(lexTable, { LEX_DECLARE, str_number, LT_TI_NULLXDX });
				return true;
			}
			else
				return checkIdentifier(word, str_number, lexTable, idTable, varType);
		}
		case 'c' :
		{
			FST::FST character(CHAR(word));
			if (FST::execute(character))
			{
				Add(lexTable, { LEX_CHAR,str_number,LT_TI_NULLIDX });
				varType.position = lexTable.size - 1;
				varType.vartype = VariableType::CHAR;
				return true;
			}
			else
				return checkIdentifier(word, str_number, lexTable, idTable, varType);
		}
		case 'r':
		{
			FST::FST _return(RETURN(word));
			if (FST::execute(_return))
			{
				Add(lexTable, { LEX_RETURN, str_number, LT_TI_NULLXDX });
				return true;
			}
			else
				return checkIdentifier(word, str_number, lexTable, idTable, varType);
		}
		case 'p':
		{
			FST::FST print(PRINT(word));
			if (FST::execute(print))
			{
				Add(lexTable, { LEX_PRINT, str_number, LT_TI_NULLXDX });
				return true;
			}
			else
				return checkIdentifier(word, str_number, lexTable, idTable, varType);
		}
		case '\'':
		{
			FST::FST stringLiteral(STRING_LITERAL(word));
			if (FST::execute(stringLiteral))
			{
				int i = idTable.IsId(word);

				if (i != LT_TI_NULLXDX)
					Add(lexTable, { LEX_LITERAL, str_number, i });
				else
				{
					idTable.Add({ "\0", (idTable.GetEntry(lexTable.GetEntry(lexTable.size - 2).idxTI).id[0] != '\0' && lexTable.GetEntry(lexTable.size - 1).lexema == '=') ? idTable.GetEntry(lexTable.GetEntry(lexTable.size - 2).idxTI).id : idTable.getLexemaName() , IT::IDDATATYPE::STR, IT::IDTYPE::L,lexTable.size });
					idTable.table[idTable.size - 1].value.vstr.len = 0;
					int i = 0, j = 0;
					for (; word[i] != '\0'; i++)
					{
						idTable.table[idTable.size - 1].value.vstr.str[j] = word[i];
						idTable.table[idTable.size - 1].value.vstr.len++;
						j++;
					}
					idTable.table[idTable.size - 1].value.vstr.str[j] = '\0';

					Add(lexTable, { LEX_LITERAL, str_number,idTable.size - 1 });
				}
				return true;
			}
		}
		default:
		{
			FST::FST numberLiteral(INTEGER_LITERAL(word));
			if (FST::execute(numberLiteral))
			{
				int i = idTable.IsId(word);
				if (i != LT_TI_NULLXDX)
					Add(lexTable, { LEX_LITERAL, str_number, i });
				else
				{
					idTable.Add({ "\0", (idTable.GetEntry(lexTable.GetEntry(lexTable.size - 2).idxTI).id[0] != '\0' && lexTable.GetEntry(lexTable.size - 1).lexema == '=') ? idTable.GetEntry(lexTable.GetEntry(lexTable.size - 2).idxTI).id : idTable.getLexemaName() , IT::IDDATATYPE::INT, IT::IDTYPE::L, lexTable.size });
					idTable.table[idTable.size - 1].value.vint = atoi(word);
					Add(lexTable, { LEX_LITERAL,str_number, idTable.size - 1 });
				}
				return true;
			}
			else
				return checkIdentifier(word, str_number, lexTable, idTable, varType);
		}
		}
	}

	bool checkIdentifier(char* word, int str_number, LT::LexTable& lxtable, IT::IdTable& idTable, VariableType& varType)
	{
		FST::FST id(IDENTIFICATOR(word));

		if (!FST::execute(id))
		{
			throw ERROR_THROW_IN(93, str_number, -1);
		}

		FST::FST main(MAIN(word));
		// main
		if (FST::execute(main))
		{
			for (int i = 0; i < lxtable.size; i++)
			{
				if(lxtable.GetEntry(i).lexema == LEX_MAIN)
				{
					throw ERROR_THROW_IN(94, str_number, -1);
				}
			}

			idTable.Add({ "\0", word, IT::IDDATATYPE::INT, IT::IDTYPE::F, lxtable.size });
			Add(lxtable, { LEX_MAIN, str_number, idTable.size - 1 });
			return true;
		}

		// Функция
		if (lxtable.GetEntry(lxtable.size - 1).lexema == LEX_FUNCTION
			&& lxtable.GetEntry(lxtable.size - 2).lexema == LEX_DATATYPE)
		{
			if (idTable.IsId(word) != -1)
				throw ERROR_THROW_IN(95, str_number, -1);

			switch (varType.vartype)
			{
			case VariableType::INT8:
				idTable.Add({ "\0", word, IT::IDDATATYPE::INT, IT::IDTYPE::F, lxtable.size });
				break;
			case VariableType::STR:
				idTable.Add({ "\0", word, IT::IDDATATYPE::STR, IT::IDTYPE::F, lxtable.size });
				break;
			}

			varType.vartype = VariableType::DEF;
			Add(lxtable, { LEX_ID, str_number, idTable.size - 1 });

			return true;
		}

		// Переменная
		if (lxtable.GetEntry(lxtable.size - 1).lexema == LEX_DATATYPE
			&& lxtable.GetEntry(lxtable.size - 2).lexema == LEX_DECLARE)
		{
			for (int i = lxtable.size - 1; i >= 0; i--)
			{
				// Поиск родительской функции
				if ((lxtable.GetEntry(i).lexema == LEX_ID || lxtable.GetEntry(i).lexema == LEX_MAIN)
					&& idTable.GetEntry(lxtable.GetEntry(i).idxTI).idtype == IT::IDTYPE::F)
				{
					if (idTable.IsId(word, idTable.GetEntry(lxtable.GetEntry(i).idxTI).id) != -1)
						throw ERROR_THROW_IN(96, str_number, -1);

					switch (varType.vartype)
					{
					case VariableType::INT8:
						idTable.Add({ idTable.GetEntry(lxtable.GetEntry(i).idxTI).id, word, IT::IDDATATYPE::INT, IT::IDTYPE::V, lxtable.size });
						break;
					case VariableType::STR:
						idTable.Add({ idTable.GetEntry(lxtable.GetEntry(i).idxTI).id, word, IT::IDDATATYPE::STR, IT::IDTYPE::V, lxtable.size });
						break;
					}

					varType.vartype = VariableType::DEF;
					Add(lxtable, { LEX_ID, str_number, idTable.size - 1 });

					return true;
				}
			}
		}

		// параметр функции
		if (lxtable.GetEntry(lxtable.size - 1).lexema == 't')
		{
			for (int i = lxtable.size - 1; i > 0; i--)
			{
				if (lxtable.GetEntry(i - 2).lexema == LEX_DATATYPE
					&& lxtable.GetEntry(i - 1).lexema == LEX_FUNCTION
					&& lxtable.GetEntry(i).lexema == LEX_ID
					&& idTable.GetEntry(lxtable.GetEntry(i).idxTI).idtype == IT::IDTYPE::F)
				{
					if (idTable.IsId(word, idTable.GetEntry(lxtable.GetEntry(i).idxTI).id) != -1)
						throw ERROR_THROW_IN(96, str_number, -1);

					switch (varType.vartype)
					{
					case VariableType::INT8:
						idTable.Add({ idTable.GetEntry(lxtable.GetEntry(i).idxTI).id, word, IT::IDDATATYPE::INT, IT::IDTYPE::P, lxtable.size });
						idTable.table[(lxtable.GetEntry(i).idxTI)].idAmount++;
						break;
					case VariableType::STR:
						idTable.Add({ idTable.GetEntry(lxtable.GetEntry(i).idxTI).id, word, IT::IDDATATYPE::STR, IT::IDTYPE::P, lxtable.size });
						idTable.table[(lxtable.GetEntry(i).idxTI)].idAmount++;
						break;
					}

					varType.vartype = VariableType::DEF;
					Add(lxtable, { LEX_ID, str_number, idTable.size - 1 });

					return true;
				}
			}
		}
		bool LeftBrace = false;
		for (int i = lxtable.size - 1; i >= 0; i--)
		{
			if (lxtable.GetEntry(i).lexema == LEX_LEFTBRACE)
				LeftBrace = true;
			if (LeftBrace && (lxtable.GetEntry(i).lexema == LEX_ID || lxtable.GetEntry(i).lexema == LEX_MAIN)
				&& idTable.GetEntry(lxtable.GetEntry(i).idxTI).idtype == IT::IDTYPE::F)
			{
				int temp = idTable.IsId(word, idTable.GetEntry(lxtable.GetEntry(i).idxTI).id);
				if (temp != -1)
				{
					Add(lxtable, { LEX_ID,str_number,temp });
					return true;
				}
				else
				{
					temp = idTable.IsId(word);
					if (idTable.GetEntry(temp).idtype != IT::IDTYPE::F)
					{
						word[5] = '\0';
					}
					if (temp != -1 && idTable.GetEntry(temp).idtype == IT::IDTYPE::F)
					{
						Add(lxtable, { LEX_ID,str_number,temp });
						return true;
					}
					else throw ERROR_THROW_IN(97, str_number, -1);
				}
			}
		}
		return false;
	}
}