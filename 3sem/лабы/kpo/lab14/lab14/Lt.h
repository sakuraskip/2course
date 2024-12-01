#pragma once
#include "IT.h"
#define LEXEMA_FIXSIZE 1
#define LT_MAXSIZE 4096
#define LT_TI_NULLIDX -1
#define LEX_DATATYPE  't'
#define LEX_INTEGER   't'
#define LEX_STRING    't'
#define LEX_CHAR      't' 
#define LEX_ID        'i'
#define LEX_LITERAL   'l'
#define LEX_FUNCTION  'f'
#define LEX_DECLARE   'd'
#define LEX_RETURN    'r'
#define LEX_PRINT     'p'
#define LEX_MAIN      'm' 
#define LEX_STRLEN    'e'
#define LEX_SEMICOLON ';'
#define LEX_COMMA     ','
#define LEX_LEFTBRACE '{'
#define LEX_RIGHTBRACE '}'
#define LEX_LEFTHESIS '('
#define LEX_RIGHTESIS ')'
#define LEX_PLUS      'v'
#define LEX_MINUS     'v'
#define LEX_STAR      'v'
#define LEX_DIRSLASH  'v'
#define LEX_AND       'v'
#define LEX_OR        'v'
#define LEX_XOR       'v'
#define EQUAL         '='
#define PLUS '+'
#define MINUS '-'
#define STAR '*'
#define DIRSLASH '/'


namespace LT
{
	struct Entry
	{
		char lexema;
		int sn; //номер строки
		int idxTI;//индекс в таблице идентификаторов
		Entry();
		Entry(const char lex, int sn, int idxIT);
	};

	struct LexTable
	{
		int maxsize;
		int size;
		Entry* table; //массив строк таблицы лексем
		Entry GetEntry
		(
			int n
		);
		void printLexTable(const wchar_t* in);
		LexTable();
	};
	LexTable Create
	(
		int size
	);
	void Add
	(
		LexTable& lextable,
		Entry entry
	);
	
	void Delete(LexTable& lextable);
}