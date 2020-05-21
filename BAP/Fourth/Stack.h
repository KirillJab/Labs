//---------------------------------------------------------------------------

#ifndef StackH
#define StackH
//---------------------------------------------------------------------------
//template <class T>
class Item
{
	public:
	char Value;
	Item* Next;
	Item(char ch)
	{
		Next = NULL;
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
