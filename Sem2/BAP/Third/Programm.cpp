

#include <vcl.h>
#pragma hdrstop

#include "Programm.h"

#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
int choice;
List *waitList = new List();
List *doneList = new List();

void ListAdd(Order *order, TListBox *ListBox)
{
	AnsiString buff;
	buff = order->Id;
	buff += "\t";
	buff += order->Name.c_str();
	buff += "\t";
	buff += order->Address.c_str();
	buff += "\t";
	buff += order->Date.c_str();
	ListBox->Items->Add(buff);
}

void ListSearch(unsigned int id, TListBox *ListBox, TListBox *DoneListBox)
{
	ListBox->Items->Clear();
	for(int i = 0; i < waitList->Size; i++)
	{
		if(waitList->Get(i)->Id == id)
		{
			ListAdd(waitList->Get(i), ListBox);
		}
	}

	for(int i = 0; i < doneList->Size; i++)
	{
		if(doneList->Get(i)->Id == id)
		{
			ListAdd(doneList->Get(i), ListBox);
		}
	}
}

void ListSearch(string date, TListBox *ListBox, TListBox *DoneListBox)
{
	ListBox->Items->Clear();
	DoneListBox->Items->Clear();

	for(int i = 0; i < waitList->Size; i++)
	{
		if(waitList->Get(i)->Date == date)
		{
			ListAdd(waitList->Get(i), ListBox);
		}
	}

	for(int i = 0; i < doneList->Size; i++)
	{
		if(doneList->Get(i)->Date == date)
		{
			ListAdd(doneList->Get(i), DoneListBox);
		}
	}
}

void ListSearch(string name, TListBox *ListBox, TListBox *DoneListBox, bool a)
{
	ListBox->Items->Clear();
	DoneListBox->Items->Clear();

	for(int i = 0; i < waitList->Size; i++)
	{
		if(waitList->Get(i)->Name == name)
		{
			ListAdd(waitList->Get(i), ListBox);
		}
	}

	for(int i = 0; i < doneList->Size; i++)
	{
		if(doneList->Get(i)->Name == name)
		{
			ListAdd(doneList->Get(i), DoneListBox);
		}
	}
}

//----------------------------------------//
__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{

}

void __fastcall TForm1::AddClick(TObject *Sender)
{
	bool check = true;
	Order *order = new Order();

	//
	//      To automate IDs use this: order->Id = waitList->Count + 1;
	//
	for(int i = 0; i < waitList->Size; i++)
	{
		if(waitList->Get(i)->Id == Id->Text.ToInt())
		{
			if(i < doneList->Size)
			{
				if(doneList->Get(i)->Id == Id->Text.ToInt())
				{
					check = false;
				}
			}
			else
			{
				check = false;
            }
			break;
		}
	}
	if(check)
	{
		order->Id = Id->Text.ToInt();
	}
	else
	{
		throw ("Id is taken");
	}
	if(Name->Text != "")
	{
		order->Name = ((AnsiString)Name->Text).c_str();
	}
	else
	{
		throw ("Name can't be Empty");
	}
	if(Name->Text != "Address can't be Empty")
	{
		order->Address = ((AnsiString)Address->Text).c_str();
	}
    else
	{
		throw;
	}
	order->Date = ((AnsiString)DateTimePicker->Date.FormatString("dd.mm.yyyy")).c_str();

	if(CheckOverlaps->Checked)
	{
		bool check = true;
		for(int i = 0; i < waitList->Size; i++)
		{
			if(waitList->Get(i)->Name == order->Name && waitList->Get(i)->Address == order->Address)
			{
				check = false;
				break;
			}
		}
		if(check)
		{

			waitList->Push(order);
			ListAdd(order, ListBox);
		}
	}
	else
	{
        waitList->Push(order);
		ListAdd(order, ListBox);
	}
}

void __fastcall TForm1::CompleteTheOrderClick(TObject *Sender)
{
	for(int i = 0; i < waitList->Size; i++)
	{
		if(ListBox->Selected[i])
		{
			doneList->Push(waitList->Get(i));
			ListAdd(waitList->Get(i), DoneListBox);
			waitList->Remove(i);
			ListBox->Items->Delete(i);
			break;
		}
	}
}

void __fastcall TForm1::UpdateClick(TObject *Sender)
{
	ListBox->Clear();
	DoneListBox->Clear();

	if(CheckOverlaps->Checked)
	{
		int size = waitList->Size;
		for (int i = 0; i < waitList->Size; i++)
		{
			Order *orderi = waitList->Get(i);
			for (int j = i + 1; j < waitList->Size; j++)
			{
				Order *orderj = waitList->Get(j);

				if(orderi->Name == orderj->Name && orderi->Address == orderj->Address)
				{
					orderj->Overlap = true;
				}
			}
			if(!orderi->Overlap)
			{
				ListAdd(orderi, ListBox);
				waitList->Push(orderi);
			}
		}
		for(int i = 0; i < size; i++)
		{
			waitList->Remove(i);
		}
		CompleteTheOrder->Enabled = false;
	}
	else
	{
		for(int i = 0 ; i < waitList->Size; i++)
		{
			ListAdd(waitList->Get(i), ListBox);
		}
		for(int i = 0 ; i < doneList->Size; i++)
		{
			ListAdd(doneList->Get(i), DoneListBox);
		}
		CompleteTheOrder->Enabled = true;
	}
}


void __fastcall TForm1::ComboBoxSelect(TObject *Sender)
{
	choice = ComboBox->ItemIndex;
	ShowInfo->Enabled = true;
	Add->Enabled = false;
	Update->Enabled = false;
	CompleteTheOrder->Enabled = false;

	switch(choice)
	{
		case 0:
		{
			Id->Enabled = true;
			Name->Enabled = false;
			DateTimePicker->Enabled = false;
			Address->Enabled = false;
			break;
		}
		case 1:
		{
			DateTimePicker->Enabled = true;
			Name->Enabled = false;
			Id->Enabled = false;
			Address->Enabled = false;
			break;
		}
		case 2:
		{
			Name->Enabled = true;
			Id->Enabled = false;
			DateTimePicker->Enabled = false;
			Address->Enabled = false;
			break;
		}
	}
}

void __fastcall TForm1::ShowInfoClick(TObject *Sender)
{
	Add->Enabled = true;
	Update->Enabled = true;
	CompleteTheOrder->Enabled = false;
	Id->Enabled = true;
	Name->Enabled = true;
	DateTimePicker->Enabled = true;
	Address->Enabled = true;

	 switch(choice)
	 {
		 case 0:
		 {
			ListSearch(Id->Text.ToInt(), ListBox, DoneListBox);
			break;
		 }
		 case 1:
		 {
			ListSearch(((AnsiString)DateTimePicker->Date.FormatString("dd.mm.yyyy")).c_str(), ListBox, DoneListBox);
			break;
		 }
		 case 2:
		 {
			ListSearch(((AnsiString)Name->Text).c_str(), ListBox, DoneListBox, true);
			break;
		 }
		 deafult:
		 {
			break;
		 }
	 }
}

void __fastcall TForm1::ExitClick(TObject *Sender)
{
	Form1->Close();
}

