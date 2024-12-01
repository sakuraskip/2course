#include "stdafx.h"
#include <iomanip>
namespace IT
{
	IdTable::IdTable()
	{
		noname_lexema_amount = 0;
		maxsize = TI_MAXSIZE;
		size = 0;
		table = new Entry[TI_MAXSIZE];
	}
	Entry::Entry()
	{
		parentFunc[0] = '\0';
		id[0] = '\0';
		idxfirstLE = 0;
		iddatatype = IT::IDDATATYPE::DEF;
		idtype = IT::IDTYPE::D;
		idAmount = 0;
	}

	Entry::Entry(const char* parentFunc, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first)
	{
		int i = 0;
		if (parentFunc)
			for (i = 0; parentFunc[i] != '\0'; i++)
				this->parentFunc[i] = parentFunc[i];
		this->parentFunc[i] = '\0';
		i = 0;
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		idxfirstLE = first;
		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		idAmount = 0;
	}
	Entry::Entry(const char* parentFunc, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, int it)
	{
		int i = 0;
		if (parentFunc)
			for (i = 0; parentFunc[i] != '\0'; i++)
				this->parentFunc[i] = parentFunc[i];
		this->parentFunc[i] = '\0';
		i = 0;
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		idxfirstLE = first;
		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		idAmount = 0;
		value.vint = it;
	}
	Entry::Entry(const char* parentFunc, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, char* ch)
	{
		int i = 0;
		if (parentFunc)
			for (i = 0; parentFunc[i] != '\0'; i++)
				this->parentFunc[i] = parentFunc[i];
		this->parentFunc[i] = '\0';
		i = 0;
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		this->idxfirstLE = first;
		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		idAmount = 0;
		strcpy_s(this->value.vstr.str, 255, ch);
		this->value.vstr.len = strlen(ch);
	}
	Entry::Entry(const char* parentFunc, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, const char* ch)
	{
		int i = 0;
		if (parentFunc)
			for (i = 0; parentFunc[i] != '\0'; i++)
				this->parentFunc[i] = parentFunc[i];
		this->parentFunc[i] = '\0';
		i = 0;
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		idxfirstLE = first;
		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		idAmount = 0;
		strcpy_s(value.vstr.str, 255, ch);
		value.vstr.len = strlen(ch);
	}
	Entry::Entry(char* parentFunc, char* id, IDDATATYPE iddatatype, IDTYPE idtype)
	{
		int i = 0;
		if (parentFunc)
			for (i = 0; parentFunc[i] != '\0'; i++)
				this->parentFunc[i] = parentFunc[i];
		this->parentFunc[i] = '\0';
		i = 0;
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		idAmount = 0;
	}
	IdTable Create(int size)
	{
		IdTable table;
		if (size > TI_MAXSIZE)
		{
			throw ERROR_THROW(114);
		}
		table.maxsize = TI_MAXSIZE;
		table.size = size;
		table.table = new Entry[TI_MAXSIZE];
		return table;
	}
	void IdTable::Add(Entry entry)
	{
		if (strlen(entry.id) > ID_MAXSIZE and entry.idtype != IDTYPE::F)
		{
			entry.id[8] = '\0';
		}
		if (size >= maxsize)
		{
			throw ERROR_THROW(114);
		}
		if (entry.idtype != IDTYPE::F)
		{
			entry.id[8] = '\0';
		}
		table[size] = entry;
		
		if (IDDATATYPE::INT)
		{
			table[size].value.vint = TI_INT_DEFAULT;
		}
		if (IDDATATYPE::STR)
		{
			table[size].value.vstr.str[0] = TI_STR_DEFAULT;
			table[size].value.vstr.len = 0;
		}
		size++;
		
	}
	Entry IdTable::GetEntry(int n)
	{
		if(n>=0 and n<maxsize)
		return table[n];
	}
	int IdTable::IsId(const char id[ID_MAXSIZE])
	{
		for (int i = 0; i < size; i++)
		{
			if (strcmp(table[i].id,id)== 0)
			{
				return i;
			}
		}
		return TI_NULLIDX;
	}
	char* IdTable::getLexemaName()
	{
		char buff[8];
		_itoa(noname_lexema_amount, buff, 5);
		strcat(buff,"_l");
		noname_lexema_amount++;
		return buff;
	}
	/// Добавить this??
	int IdTable::IsId(const char id[ID_MAXSIZE], char parentFunc[ID_MAXSIZE + 5])
	{
		for (int i = 0; i < size; i++)
		{
			if ((strcmp(this->table[i].id,id)==0) and strcmp(this->table[i].parentFunc,parentFunc)==0)
			{
				return i;
			}
		}
		return TI_NULLIDX;
	}
	void Delete(IdTable& idtable)
	{
		idtable.size = 0;
		idtable.maxsize = 0;
		delete[] idtable.table;
	}
	void IdTable::PrintIdTable(const wchar_t* inFile)
	{
		std::ofstream* idStream = new std::ofstream;
		idStream->open(inFile);

		if (idStream->is_open())
		{
			bool flagForFirst = false;
			char buffer[3];
			char tempBuf[5];
			int lexema_count = 0;
			tempBuf[0] = 'L';
			tempBuf[1] = '_';

			*(idStream) << "\t\t\t Таблица идентификаторов" << std::endl;

			*(idStream) << "Тип идентификатора:" << "|" << "Идентификатор:" << "|" << "Тип данных:" << "|\t" << "Значение:" << "\t|" << "Кол-во переданных параметров:" << "|" << "Первое вхождение:" << std::endl;

			for (int i = 0; i < this->size; i++)
			{
				switch (this->table[i].idtype)
				{
				case IT::IDTYPE::V:
					std::cout.width(25);
					switch (this->table[i].iddatatype)
					{
					case 1://10
						*(idStream) << "Переменная" << std::setw(10) << "   " << this->table[i].id << std::setw(24) << "INT " << "\t\t" << 0 << std::setw(15) << "\t\t\t\t\t" << this->table[i].idxfirstLE << std::endl;
						break;
					case 2:
						*(idStream) << "Переменная" << std::setw(10) << "   " << this->table[i].id << std::setw(23) << "STR " << "\t    " << "   \"\"" << " \t\t\t\t\t\t" << this->table[i].idxfirstLE << std::endl;
						break;
					}
					break;


				case IT::IDTYPE::P:
					std::cout.width(25);
					switch (this->table[i].iddatatype)
					{
					case 1://8
						*(idStream) << "Параметр" << std::setw(12) << "   " << this->table[i].id << std::setw(24) << "INT " << "\t\t" << 0 << std::setw(15) << "\t\t\t\t\t" << this->table[i].idxfirstLE << std::endl;
						break;
					case 2:
						*(idStream) << "Параметр" << std::setw(12) << "     " << this->table[i].id << std::setw(24) << "STR " << "\t    " << "   \"\"" << " \t\t\t\t\t\t" << this->table[i].idxfirstLE << std::endl;
						break;
					}
					break;

				case IT::IDTYPE::L:
					_itoa_s(lexema_count, buffer, 10);
					tempBuf[2] = buffer[0];
					tempBuf[3] = buffer[1];
					tempBuf[4] = buffer[2];
					switch (this->table[i].iddatatype)
					{
					case 1://7
						*(idStream) << "Лексема" << std::setw(13) << "     " << tempBuf << "\t\t\t " << "INT " << "\t\t" << this->table[i].value.vint << " \t\t\t\t\t\t" << this->table[i].idxfirstLE << std::endl;
						break;
					case 2:
						*(idStream) << "Лексема" << std::setw(13) << "     " << tempBuf << "\t\t\t " << "STR " << "\t    " << this->table[i].value.vstr.str << " \t\t\t\t\t\t" << this->table[i].idxfirstLE << std::endl;
						break;
					}
					lexema_count++;
					break;
				case IT::IDTYPE::F:
					switch (this->table[i].iddatatype)
					{
					case 1://7
						*(idStream) << "Функция" << std::setw(13) << "   " << this->table[i].id << std::setw(25 - strlen(this->table[i].id)) << "INT " << "\t\t\t\t\t" << this->table[i].idAmount << "\t\t\t" << this->table[i].idxfirstLE << std::endl;
						break;
					case 2:
						*(idStream) << "Функция" << std::setw(13) << "   " << this->table[i].id << std::setw(25 - strlen(this->table[i].id)) << "STR " << "\t\t\t\t\t" << this->table[i].idAmount << "\t\t\t" << this->table[i].idxfirstLE << std::endl;
						break;
					}
					break;


				}
			}
			*(idStream) << "\n\n\n";

		}
		else
			throw ERROR_THROW(125);
		idStream->close();
		delete idStream;
	}
}