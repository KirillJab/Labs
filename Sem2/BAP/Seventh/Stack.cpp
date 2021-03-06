//------------------------------------------------------------------------------

#pragma hdrstop
//------------------------------------------------------------------------------
#include "Stack.h"
#pragma package(smart_init)

void Stack::Push(int num)
{
	Item* item = new Item(num);
	if(this->Empty())
	{
		item->next = NULL;
		this->tail = item;
	}
	else
	{
		item->next = this->tail;
		this->tail = item;
	}
}

void Stack::Pop()
{
	if(!this->Empty())
	{
		Item *temp = this->tail;
		this->tail = this->tail->next;
        delete(temp);
	}
	else
	{
		throw 13;
	}
}

Item* Stack::Back()
{
	if(!this->Empty())
	{
		return this->tail;
	}
	else
	{
		throw 13;
    }
}

bool Stack::Empty()
{
	return !this->tail;
}