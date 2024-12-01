#pragma once
#include "stdafx.h"

namespace Analysis
{
	struct VariableType
	{
		int position = -1;
		enum {DEF = 0,INT8,STR,CHAR} vartype = DEF;
	};
	struct LEX
	{
		LT::LexTable lxtable;
		IT::IdTable idtable;
	};
	bool checkIdentifier(char* word, int stringNum,LT::LexTable& lxtable, IT::IdTable& idtable, VariableType& vartype);
	bool DoAnalysis(char* word, int stringNumber, LT::LexTable& lxtable, IT::IdTable& idtable);
	void lexAnalysis(const In::IN& in, LT::LexTable& lxtable, IT::IdTable& idtable);
}