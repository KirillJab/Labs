//---------------------------------------------------------------------------

#pragma hdrstop

#include "List.h"
#include <vcl.h>
//---------------------------------------------------------------------------
#pragma package(smart_init)

void List::Push(Order *order)
{
	if(this->Head == NULL)
	{
		this->Head = order;
		this->Tail = order;
	}
	else
	{
		this->Tail->Next = order;
		this->Tail = order;
	}
	this->Size++;
	this->Count++;
}

void List::Remove(int i)
{
	if(i >= this->Size)
	{
        return;
    }
	if(i > 0)
	{
		Order *prevOrder = this->Get(i - 1);
		if(prevOrder->Next != this->Tail)
		{
			prevOrder->Next = prevOrder->Next->Next;
		}
		else
		{
			prevOrder->Next = NULL;
			this->Tail = prevOrder;
		}
	}
	else
	{
		this->Head = Head->Next;
	}
	this->Size--;
}

void List::Clear()
{
	this->Head = NULL;
	this->Size = 0;
}

Order* List::Get(int ind)
{
	if (ind > Size - 1)
	{

		throw;
	}
	else
    {
		Order *order = this->Head;
		for(int i = 0; i < ind; i++)
		{
			order = order->Next;
		}
        return order;
    }
}
