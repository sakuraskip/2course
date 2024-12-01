#pragma once
#define NULL 0
#include <iostream>
#include <string>
namespace FST
{
	struct RELATION    //ребро:символ -> вершина графа переходов
	{
		char symbol;   //символ перехода
		short nnode;   //символ смежной вершины
		RELATION
		(
			char c = 0x00,   //символ перехода
			short ns = NULL  //новое состояние
		);
	};

	struct NODE    // вершина графа переходов
	{
		short n_relation;     // количество смежных ребер
		RELATION* relations;  // смежные ребра
		NODE();
		NODE
		(
			short n,
			RELATION rel, ...
		);
	};

	struct FST      // конечный автомат
	{
		char* string;    //цепочка
		short position;  //позиция в цепочке
		short nstates;   //кол-во состояний автомата
		NODE* nodes;     //граф переходов: 0 - начальное, [nstate-1] - конечное
		short* rstates;  //возможрные состояния автомата
		FST
		(
			char* s,      //цепочка
			short ns,     //кол-во состояний автомата
			NODE n, ...   //список состояний
		);
	};

	bool execute(         //выполнить распознавание цепочки
		FST& fst          //автомат конечный
	);
};