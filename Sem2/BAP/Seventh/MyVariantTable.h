//---------------------------------------------------------------------------

#include "HashTable.h"

#ifndef MyVariantTableH
#define MyVariantTableH
//---------------------------------------------------------------------------

class MyHashTable : public HashTable
{
public:
	MyHashTable(int key) : HashTable(key){};
	void Print(TMemo*);
	void DeleteRange(int, int);
};

#endif
