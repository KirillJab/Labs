//---------------------------------------------------------------------------

#include "Stack.h"

#ifndef HashTableH
#define HashTableH
//---------------------------------------------------------------------------

class HashTable
{
public:
	unsigned int size;
	Stack* table;

	HashTable(int _size)
	{
		this->size = _size;
		table = new Stack[size];
		for(int i = 0; i < size; i++)
		{
			table[i] = Stack();
        }
	}

	int GetHashCode(int);
	Stack* FindStack(int);
	void AddNode(int);
	void Print(TMemo*);
	void DeleteNode(int);
};


#endif
