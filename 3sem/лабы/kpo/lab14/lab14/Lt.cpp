#include "stdafx.h"

namespace LT
{
	
	LexTable Create(int size)
	{
		if (size > LT_MAXSIZE)
		{

		}
		LexTable lextable;
		lextable.maxsize = size;
		lextable.table = new Entry[size];
		return lextable;
	}
	LexTable::LexTable()
	{
		maxsize = LT_MAXSIZE;
		size = 0;
		table = new Entry[LT_MAXSIZE];
	}
	void Add(LexTable& lextable, Entry entry)
	{
		if (lextable.size >= lextable.maxsize)
		{
			throw ERROR_THROW(60);
		}
		lextable.table[lextable.size] = entry;
		lextable.size++;
	}
	Entry LexTable::GetEntry(int n)
	{
		if (n > LT_MAXSIZE or n < 0)
		{
			throw ERROR_THROW(115);
		}
		return table[n];
	}
	void Delete(LexTable& lextable)
	{
		lextable.maxsize = 0;
		lextable.size = 0;
		delete[] lextable.table;
	}
	void LexTable::printLexTable(const wchar_t* in)
	{
		ofstream lexStream(in);

		if (!lexStream.is_open())
			throw ERROR_THROW(63);

		int num_string = 0;

		for (int i = 0; i < size;)
		{
			if (num_string == table[i].sn) {
				lexStream << table[i++].lexema;
				continue;
			}

			lexStream << '\n' << ++num_string << ".\t";
		}

		lexStream.close();
	}
	Entry::Entry()
	{
		lexema = '\0';
		sn = LT_TI_NULLIDX;
		idxTI = LT_TI_NULLIDX;
	}
	Entry::Entry(char lex, int sn, int idxTI)
	{
		lexema = lex;
		this->sn = sn;
		this->idxTI = idxTI;
	}
}