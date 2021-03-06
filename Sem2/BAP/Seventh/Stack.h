//---------------------------------------------------------------------------

#ifndef StackH
#define StackH
//---------------------------------------------------------------------------

class Item
{
	public:
    int key;
	Item* next;
	Item(int num)
	{
		next = NULL;
		key = num;
	}
};

class Stack
{
	public:
	Item* tail;
	Stack()
	{
		tail = NULL;
	}
	void Push(int);
	void Pop();
	Item* Back();
	bool Empty();
};
#endif
