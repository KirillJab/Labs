//---------------------------------------------------------------------------

#pragma hdrstop

#include "MyVariantTable.h"
#include "string"
//---------------------------------------------------------------------------
#pragma package(smart_init)

void MyHashTable::Print(TMemo* Memo)
{
	for(int i = 0; i < this->size; i++)
	{
		AnsiString str = IntToStr(i) + ": ";
		if (!table[i].Empty())
		{
			Item* temp = table[i].Back();
			while(temp)
			{
				str += "|" + IntToStr(temp->key) + "| ";
				temp = temp->next;
			}
		}
		Memo->Lines->Add(str);
	}
}

void MyHashTable::DeleteRange(int k1, int k2)
{
	for(int i = 0; i < this->size; i++)
	{
		if (!table[i].Empty())
		{
			Item* temp = table[i].Back();
			while(temp)
			{
				if (k1 < temp->key && temp->key < k2)
				{
					DeleteNode(temp->key);
				}
				temp = temp->next;
			}
		}
	}
}
