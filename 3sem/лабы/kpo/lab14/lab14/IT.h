#pragma once
#define ID_MAXSIZE 8
#define TI_MAXSIZE 4096
#define TI_INT_DEFAULT 0x00000000
#define TI_STR_DEFAULT 0x00
#define TI_NULLIDX 0xffffffff
#define TI_STR_MAXSIZE 255
namespace IT
{
	enum IDDATATYPE {DEF =0, INT = 1, STR = 2 };
	enum IDTYPE {D = 0, V = 1, F = 2, P = 3, L = 4 };

	struct Entry		
	{
		char parentFunc[ID_MAXSIZE+5];
		int			idxfirstLE;			// индекс первой строки в таблице лексем
		char		id[ID_MAXSIZE+5];		// идентификатор
		IDDATATYPE	iddatatype;			// тип данных
		IDTYPE		idtype;				// тип идентификатора
		union
		{
			int vint;				// значение int
			char operation = '\0';
			struct
			{
				unsigned char len;						// кол-во символов в str
				char str[TI_STR_MAXSIZE - 1];	// символы string
			}	vstr;			// значение string
		} value;	// значение идентификатора
		int idAmount;
		Entry();
		Entry(const char* parrentFunc, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first);
		Entry(const char* parrentFunc, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, int it);
		Entry(const char* parrentFunc, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, char* str);
		Entry(const char* parrentFunc, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, const char* str);
		Entry(char* parrentFunc, char* id, IDDATATYPE iddatatype, IDTYPE idtype);
	};
	struct IdTable			// экземпляр таблицы идентификаторов
	{
		int noname_lexema_amount;
		int maxsize;		//  емкость таблицы
		int size;			// текущий размер таблицы
		Entry* table;		// массив строк таблицы
		void Add(				// добавить строку в таблицу
			Entry entry			// строка таблицы
		);
		Entry GetEntry(			// получить строку таблицы
			int n				// номер строки
		);
		int IsId                // возврат - номер строки
		(
			const char id[ID_MAXSIZE] //идентифкатор
		);
		int IsId
		(
			const char id[ID_MAXSIZE],
			char parentFunc[ID_MAXSIZE + 5]
		);
		void PrintIdTable(const wchar_t* in);
		IdTable();
		char* getLexemaName();
	};
	IdTable Create(		// создать таблицу
		int size		// емкость таблицы
	);
	
	void Delete(IdTable& idtable);	// удалить таблицу
}