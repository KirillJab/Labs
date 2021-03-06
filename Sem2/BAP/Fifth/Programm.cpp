

#include <vcl.h>
#pragma hdrstop

#include "Programm.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
Queue *queue = new Queue();
List *list = new List();
List *boxList = new List();
List *buffList = new List();
bool chosen = false;

void UpdateQueue(TMemo *Memo)
{
	Memo->Lines->Clear();
	AnsiString buff;
	Memo->Lines->Add("Queue:");
	Memo->Lines->Add("");
	buff = "Size of the Queue:      ";
	buff += queue->Size;
	Memo->Lines->Add(buff);
	buff = "Head (front member):  ";
	buff += queue->Head->Text.c_str();
	Memo->Lines->Add(buff);
	buff = "Tail (back member):     ";
	buff += queue->Tail->Text.c_str();
	Memo->Lines->Add(buff);
	buff = "Size of the Queue:      ";
	buff += queue->Size;
	Memo->Lines->Add(buff);
	buff = "Queue.Empty:      ";
	queue->Empty()? buff += "Yes" : buff += "No";
	Memo->Lines->Add(buff);
}

void InitializeTask1(TListBox *ListBox, TMemo *Memo, TEdit *QueueEdit)
{
	queue->Clear();
	list->Clear();
	buffList->Clear();
	boxList->Clear();
	ListBox->Items->Clear();
	Memo->Lines->Clear();
	QueueEdit->Text = "";
}

void InitializeTask2(TListBox *ListBox, TMemo *Memo)
{
	queue->Clear();
	list->Clear();
	buffList->Clear();
	boxList->Clear();
	ListBox->Items->Clear();
	Memo->Lines->Clear();
	ListBox->MultiSelect = true;
	chosen = false;

	list->Push("1  - First string");
	list->Push("2  - Second string");
	list->Push("3  - Third string");
	list->Push("4  - Fourht string");
	list->Push("5  - Fifth string");
	list->Push("6  - Sixth string");
	list->Push("7  - Seventh string");
	list->Push("8  - Eights string");
	for (int i = 0; i < list->Size; i++)
	{
		ListBox->Items->Add(list->get(i)->Text.c_str());
	}
}

__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{

}
//------------------------Click--------------------------//
void __fastcall TForm1::ListBoxClick(TObject *Sender)
{
	if(!InsertButton->Enabled && !chosen)
	{
		ChooseButton->Enabled = true;
		for (int i = 0; i < ListBox->Items->Count; i++)
		{
			if(ListBox->Selected[i])
			{
				UnicodeString str = ListBox->Items->Strings[i];
				AnsiString astr = str;

				if(!list->get(i)->Picked)
				{
					buffList->Push(astr.c_str());
					list->get(i)->Picked = true;

					MemoBuff->Lines->Add(astr.c_str());
				}
			}
		}
	}
	if(chosen)
	{
		InsertButton->Enabled = true;
	}
}

//---------------------ChooseButton_Click----------------------//
void __fastcall TForm1::ChooseButtonClick(TObject *Sender)
{
	chosen = true;
	ChooseButton->Enabled = false;
	ListBox->MultiSelect = false;
}


//---------------------InsertButton_Click----------------------//
void __fastcall TForm1::InsertButtonClick(TObject *Sender)
{
	ChooseButton->Enabled = false;
	InsertButton->Enabled = false;
	Line line;
	int pos;
	int j;
	chosen = false;

	for (int i = 0; i < ListBox->Items->Count; i++) //ListBox to struct List boxList
	{
		Line *line = list->get(i);
		if(!line->Picked)
		{
			boxList->Push(line->Text);
		}
		if(ListBox->Selected[i])
		{
			pos = i;
		}
	}
	//Updating ListBox
	ListBox->Items->Clear();
	int breakPoint = pos < buffList->Size? 0 : pos - buffList->Size;
	for (j = 0; j < breakPoint; j++)
	{
		ListBox->Items->Add(boxList->get(j)->Text.c_str());
	}
	for (int i = 0; i < buffList->Size; i++)
	{
		ListBox->Items->Add(buffList->get(i)->Text.c_str());
	}
	for (; j < boxList->Size; j++)
	{
		ListBox->Items->Add(boxList->get(j)->Text.c_str());
	}
	MemoBuff->Lines->Clear();
	buffList->Clear();
	boxList->Clear();
	list->Clear();
	for (int i = 0; i < ListBox->Items->Count; i++) //Updating the list
	{
		list->Push(((AnsiString)ListBox->Items->Strings[i]).c_str());
		list->get(i)->Picked = false;
	}
	ListBox->MultiSelect = true;
}

//---------------------ExitButton_Click----------------------//
void __fastcall TForm1::ExitButtonClick(TObject *Sender)
{
	Form1->Close();
}

void __fastcall TForm1::ChangeButtonClick(TObject *Sender)
{
	ChangeTask(Sender);
}

//-------------------------Event----------------------------//
void __fastcall TForm1::ChangeTask(TObject *Sender)
{
	PushButton->Visible = !PushButton->Visible;
	PopButton->Visible = !PopButton->Visible;
	CheckEmptyButton->Visible = !CheckEmptyButton->Visible;
	QueueEdit->Visible = !QueueEdit->Visible;
	InsertButton->Visible = !InsertButton->Visible;
	ChooseButton->Visible = !ChooseButton->Visible;

	if(PushButton->Visible)
	{
		InitializeTask1(ListBox, MemoBuff, QueueEdit);
	}
	else
	{
		InitializeTask2(ListBox, MemoBuff);
	}
}


void __fastcall TForm1::PushButtonClick(TObject *Sender)
{
	if(QueueEdit->Text != "")
	{
	queue->Push(((AnsiString)QueueEdit->Text).c_str());
	ListBox->Items->Add(queue->Tail->Text.c_str());
	UpdateQueue(MemoBuff);
	QueueEdit->Text = "";
	}
	else
	{
        ShowMessage("Can not add null member to the queue!!!");
    }
}

void __fastcall TForm1::PopButtonClick(TObject *Sender)
{
	if(queue->Size > 0)
	{
	queue->Pop();
	ListBox->Items->Delete(0);
	UpdateQueue(MemoBuff);
	}
}

