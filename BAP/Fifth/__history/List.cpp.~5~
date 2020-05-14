//---------------------------------------------------------------------------

#pragma hdrstop

#include "List.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)

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
