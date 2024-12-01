#include "MFST.h"
#include <iomanip>
#include "stdafx.h"



extern int errorLines, errorPos;
extern bool readFailed;
int _tmain(int argc, _TCHAR* argv[])
{
	Log::LOG log = Log::INITLOG;
	setlocale(LC_ALL, "russian");
	try
	{
		Parm::PARM parm = Parm::getparm(argc, argv);
		std::wcout << "-in:" << parm.in << ", -out:" << parm.out << ", -log:" << parm.log << std::endl;
	}
	catch (Error::ERROR e)
	{
		std::cout << "Ошибка " << e.id << ": " << e.message << std::endl;
		return 0;
	}
	Parm::PARM parm = Parm::getparm(argc, argv);

	try
	{
		/*for (int i = 0; i < 1000; i++)
		{
			cout << i << "  :" << Error::geterror(i).message << endl;
		}
		cout << Error::geterror(241).message << endl;*/
		Parm::PARM parm = Parm::getparm(argc, argv);
		Out::OUT out = Out::getOut(parm.out);
		log = Log::getlog(parm.log);
		Log::WriteLog(log);
		Log::WriteParm(log, parm);
		In::IN in = In::getin(parm.in);
		Log::WriteIn(log, in);
		Out::writeOutFile(Out::getOut(parm.out), in);		
		if (readFailed == true)
		{
			throw ERROR_THROW_IN(111, errorLines, errorPos);
		}
		Analysis::LEX lex;
		
		cout << "ale1" << endl;
		Analysis::lexAnalysis(in, lex.lxtable, lex.idtable);
		cout << "ale2" << endl;
		lex.idtable.PrintIdTable(L"C:\\Users\\леха\\2sem\\kpo\\lab14\\Debug\\idtable.txt");
		lex.lxtable.printLexTable(L"C:\\Users\\леха\\2sem\\kpo\\lab14\\Debug\\lxtable.txt");
		/*MFST_TRACE_START
		MFST::Mfst mfst(lex, GRB::getGreibach());
		mfst.start();
		mfst.savededucation();
		mfst.printrules();*/
	}
	catch (Error::ERROR e)
	{
		Out::writeOutError(Out::getOut(parm.out), e);
		Log::WriteError(log, e);
		std::cout << "Ошибка " << e.id << ": " << e.message << std::endl;
	};
	return 0;
};	