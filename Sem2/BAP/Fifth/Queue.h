//---------------------------------------------------------------------------
#include "Line.h"
#ifndef ListH
#define ListH
//---------------------------------------------------------------------------

class Queue
{
	public:
	Line* Head;
	Line* Tail;
	int Size;
	Queue()
	{
		Head = NULL;
		Tail = NULL;
		Size = 0;
	}
	void Push(string);
	void Pop();
	bool Empty();
	void Clear();
};

#endif
