//---------------------------------------------------------------------------

#pragma hdrstop

#include "List.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)

void List::add(string text)
	{
		Line *line = new Line(text);
		line->Text = text;
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
			line->Next = NULL;
			this->Tail->Next = line;
			this->Tail = line;
		}
		this->Size++;
	}
	Line* List::get(int j)
	{
		Line *line = this->Head;
		if(j > this->Size - 1)
		{
			throw;
		}
		else
		{
			for (int i = 0; i < j; i++)
			{
				line = line->Next;
			}
		}
		return line;
	}