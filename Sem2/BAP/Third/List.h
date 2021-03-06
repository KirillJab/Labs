//---------------------------------------------------------------------------
#include "Order.h"
#ifndef ListH
#define ListH
//---------------------------------------------------------------------------

class List
{
	public:
	Order *Head;
	Order *Tail;
	unsigned int Size;
	unsigned int Count;
	List()
	{
		Head = NULL;
		Tail = NULL;
		Size = 0;
        Count = 0;
	}
	void Push(Order*);
	void Remove(int);
	void Clear();
	Order* Get(int);
};

#endif
