//---------------------------------------------------------------------------

#ifndef StackH
#define StackH
//---------------------------------------------------------------------------
class Item
{
	public:
	char Value;
	Item* Prev;
	Item(char ch)
	{
		Prev = NULL;
		Value = ch;
    }
};
class Stack
{
	public:
	Item* Tail;
	Stack()
	{
        Tail = NULL;
    }
	void Push(char);
	void Pop();
	Item* Back();
	bool Empty();
};
#endif
