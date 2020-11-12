//---------------------------------------------------------------------------

#pragma hdrstop

#include "HashTable.h"

//---------------------------------------------------------------------------
#pragma package(smart_init)


int HashTable::GetHashCode(int key)
{
	return key % size;
}

Stack* HashTable::FindStack(int key)
{
	Stack* stack = &table[GetHashCode(key)];
	return stack;
}

void HashTable::AddNode(int key)
{
	Stack* stack = FindStack(key);
	stack->Push(key);
}

void HashTable::DeleteNode(int key)
{
	Stack* stack = FindStack(key);
	if(!stack->Empty())
	{
		while(!stack->Empty() && stack->Back()->key == key)
		{
			stack->Pop();
		}
		if(stack->Empty())
		{
			return;
		}
		Item* prev = stack->Back();
		Item* cur = prev->next;
        while(cur)
		{
			if(cur->key == key)
			{
				prev->next = cur->next;
				free(cur);
				cur = prev->next;
			}
			else
			{
				prev = cur;
				cur = cur->next;
			}
		}
	}
}
