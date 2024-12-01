#include "stdafx.h"
#include "In.h"

 int errorLines, errorPos;
 bool readFailed = false;
 int failedFileSize = -1;
using namespace std;

namespace In
{

	IN getin(wchar_t infile[])
	{
		setlocale(LC_ALL, "russian");
		IN in;
		in.size = 0, in.lines = 1, in.ignor = 0;
		int pos =1;
		bool insideStr = false;
		unsigned char* filetext = new unsigned char[IN_MAX_LEN_TEXT];
		std::ifstream file(infile);
		if (!file.is_open())
		{
			throw ERROR_THROW(110);
		}
		while (in.size < IN_MAX_LEN_TEXT)
		{
			char symbol;
			unsigned char unsignedSymbol;
			file.get(symbol);
			if (symbol == '\'')
			{
				insideStr = !insideStr;
			}
			unsignedSymbol = symbol;
			if (file.eof())
			{
				filetext[in.size] = '\0';
				break;
			}
			
			switch (in.code[unsignedSymbol])
			{
			case in.P:
			{
				if ((in.code[filetext[in.size - 1]] == in.P) and insideStr == false)
				{
					filetext[in.size] = unsignedSymbol;
					break;
				}
				if (in.code[filetext[in.size - 1]] == in.P and insideStr == true)
				{
					filetext[in.size] = unsignedSymbol;
					in.size++;
					pos++;
					break;
				}
				else
				{
					filetext[in.size] = unsignedSymbol;
					in.size++;
					pos++;
					break;
				}

			}
			case in.S:
			case in.O:
			case in.T:
			{
				filetext[in.size] = unsignedSymbol;
				in.size++;
				pos++;
				break;
			}
			case in.F:
			{
				filetext[in.size] = unsignedSymbol;
				in.size++;
				readFailed = true;
				errorLines = in.lines;
				errorPos = pos;
				in.text = filetext;
				failedFileSize = in.size;
				return in;
				break;
			}
			case in.I:
			{
				in.ignor++;
				break;
			}
			default:
			{
				filetext[in.size] = in.code[unsignedSymbol];
				in.size++;
				pos++;
				break;
			}
			}
			if (unsignedSymbol == IN_CODE_ENDL)
			{
				in.lines++;
				pos = 1;
			}
			
		}
		
		filetext[in.size] = '\0';
		in.text = filetext;
		return in;
	}
}