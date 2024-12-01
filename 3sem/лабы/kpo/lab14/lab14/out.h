#pragma once
#include "stdafx.h"

namespace Out
{
	struct OUT
	{
		int size;
		wchar_t outfile[PARM_MAX_SIZE];
		std::fstream outStream;
	};
	OUT getOut(wchar_t outfile[]);
	void writeOutFile(Out::OUT out,In::IN in);
	void writeOutError(Out::OUT out, Error::ERROR e);
	std::string deleteExtraSpaces(In::IN& in);
};