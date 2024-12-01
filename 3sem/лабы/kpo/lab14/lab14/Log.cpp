#include "stdafx.h"
#include <ctime>
namespace Log
{
	LOG getlog(wchar_t logfile[])
	{
		LOG log;
		log.stream = new ofstream;
		log.stream->open(logfile);
		if (!log.stream->is_open())
		{
			throw ERROR_THROW(112);
		}
		wcscpy_s(log.logfile, logfile);
		return log;
	}
	void WriteLine(LOG log, char* c, ...)
	{
		char** pointerc = &c;
		while (*pointerc != "")
		{
			*log.stream << *pointerc;
			pointerc++;
		}
		*log.stream << endl;
	}
	void WriteLine(LOG log, wchar_t* c, ...)
	{
		wchar_t** pointerc = &c;
		char buf1[1024] = "", buf2[1024] = "";
		while (*pointerc != L"")
		{
			wcstombs_s(0, buf1, *pointerc, IN_MAX_LEN_TEXT);
			strcat_s(buf2, buf1);
			pointerc++;
		}
		*log.stream << buf2;
	}
	void WriteLog(LOG log)
	{
		char dateAndTime[255];
		time_t current = time(0);
		tm localtime;
		localtime_s(&localtime, &current);
		strftime(dateAndTime, 255, "%d.%m.%Y %H:%M:%S", &localtime);
		*log.stream << "---- Протокол ----- " << dateAndTime << endl;

	}
	void WriteParm(LOG log, Parm::PARM parm)
	{
		char buff[PARM_MAX_SIZE];
		*log.stream << "---- Параметры -----" << endl;
		wcstombs_s(0, buff, parm.log, PARM_MAX_SIZE);
		*log.stream << "-log: " << buff << endl;
		wcstombs_s(0, buff, parm.out, PARM_MAX_SIZE);
		*log.stream << "-out: " << buff << endl;
		wcstombs_s(0, buff, parm.in, PARM_MAX_SIZE);
		*log.stream << "-in: " << buff << endl;
	}
	void WriteIn(LOG log, In::IN in)
	{
		*log.stream << "----Исходные данные -----" << endl;
		*log.stream << "Количество символов: " << in.size << endl;
		*log.stream << "Проигнорировано    :" << in.ignor << endl;
		*log.stream << "Количество строк   :" << in.lines << endl;
	}
	void WriteError(LOG log, Error::ERROR error)
	{
		*log.stream << "Ошибка " << error.id << ": " << error.message;
		if (error.inext.line !=-1)
		{
			*log.stream << " строка " << error.inext.line << " позиция" << error.inext.col << endl;
		}
	}
	void Close(LOG log)
	{
		log.stream->close();
	}
}