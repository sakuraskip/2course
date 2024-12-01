#include "stdafx.h"
#include "out.h"
#include <sstream>


using namespace std;
extern int failedFileSize;
namespace Out
{
	OUT getOut(wchar_t outfile[])
	{
		OUT out;
		wcscpy_s(out.outfile, outfile);
		out.outStream.open(outfile,ios::app);
		if (!out.outStream.is_open())
		{
			throw ERROR_THROW(113);
		}
		out.outStream.close();
		return out;
	}
	void writeOutFile(Out::OUT out,In::IN in)
	{
		setlocale(LC_ALL, "russian");
		out.outStream.open(out.outfile, ios::out);
		if (failedFileSize != -1)
		{
			for (int i = 0; i < failedFileSize; i++)
			{
				out.outStream << in.text[i];
			}
		}
		else
		{
			out.outStream << in.text;
		}
		cout << "Запись в файл завершена " << endl;
	}
	void writeOutError(Out::OUT out, Error::ERROR e)
	{
		out.outStream.open(out.outfile, ios::app);
		out.outStream << "<- Ошибка " << e.id << ": " << e.message
			<< ", строка " << e.inext.line << ", позиция "
			<< e.inext.col << endl;
	}
	

}
