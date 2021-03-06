//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Programm.h"

#pragma package(smart_init)
#pragma resource "*.dfm"

TForm1 *Form1;
int _size = 10;//          <<<<<------- Here you can change the size of the table
MyHashTable* table = new MyHashTable(_size);
Stack st;

__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{

}

void __fastcall TForm1::Button3Click(TObject *Sender)
{
	for (int i = 0; i < _size * 2; i++)
	{
		table->AddNode(1 + rand() % 100);
	}
    MemoUpdate(Sender);
}

void __fastcall TForm1::MemoUpdate(TObject *Sender)
{
    Memo->Lines->Clear();
	table->Print(Memo);
}

void __fastcall TForm1::AddButtonClick(TObject *Sender)
{
	table->AddNode(EditKey->Text.ToInt());
	MemoUpdate(Sender);
}

void __fastcall TForm1::DeleteButtonClick(TObject *Sender)
{
	table->DeleteNode(EditKey->Text.ToInt());
	MemoUpdate(Sender);
}

void __fastcall TForm1::TaskDeleteButtonClick(TObject *Sender)
{
	Task(Sender);
}
void __fastcall TForm1::Task(TObject *Sender)
{
	table->DeleteRange(EditK1->Text.ToInt(), EditK2->Text.ToInt());
	MemoUpdate(Sender);
}

void __fastcall TForm1::FormCreate(TObject *Sender)
{
	MemoUpdate(Sender);
}
