//---------------------------------------------------------------------------

#pragma hdrstop

#include "Queue.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)

void Queue::Push(string text)
{
	Line *line = new Line(text);
	if(this->Head == NULL)
	{
		line->Prev = NULL;
		line->Next = NULL;
		this->Head = line;
		this->Tail = line;
	}
	else
	{
		line->Prev = this->Tail;
		this->Tail->Next = line;
		this->Tail = line;
	}
	this->Size++;
}

void Queue::Pop()
{
	if(this->Head != NULL)
	{
		this->Head = Head->Next;
		this->Size--;
		delete(this->Head);
	}
}

bool Queue::Empty()
{
	if(this->Head == NULL)
	{
		return true;
	}
    return false;
}

void clearLine(Line *line)
{
	if (line == NULL)
	{
		return;
	}
	clearLine(line->Next);
	delete(line);
}

void Queue::Clear()
{
	if (this->Head == NULL || this->Size == 0)
	{
		return;
	}
	clearLine(this->Head->Next);
	this->Head = NULL;
	this->Size = 0;
}