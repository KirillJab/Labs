

#include <vcl.h>
#pragma hdrstop

#include "Programm.h"

#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
int showtype;
Node* tree = NULL;
int KeyCount;

void ViewTree(Node *tree, int count)
{
	if (tree == NULL)
	{
		return;
	}
	if (count == -1)
	{
		Form1->TreeView->Items->AddFirst(NULL, IntToStr(tree->value) + ") " + tree->str);
	}
	else
	{
		Form1->TreeView->Items->AddChildFirst(Form1->TreeView->Items->Item[count], IntToStr(tree->value) + ") " + tree->str);
	}
	count++;
	ViewTree(tree->left, count);
	ViewTree(tree->right, count);
	count--;
}

void ShowAs(Node* node, int n)
{
	if(node == NULL)
	{
		return;
	}
	switch (n)
	{
		case 0:
		{
			Form1->Memo->Lines->Add(IntToStr(node->value) + ") " + node->str);
			ShowAs(node->left, n);
			ShowAs(node->right, n);
			break;
		}
		case 1:
		{
			ShowAs(node->right, n);
			ShowAs(node->left, n);
			Form1->Memo->Lines->Add(IntToStr(node->value) + ") " + node->str);
			break;
		}
		case 2:
		{
			ShowAs(node->left, n);
			Form1->Memo->Lines->Add(IntToStr(node->value) + ") " + node->str);
			ShowAs(node->right, n);
			break;
		}
		default:
		{
			break;
		}
	}
}

__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{
	StringGrid->FixedCols=0; StringGrid->ColCount=2;
	StringGrid->RowCount=15;
	StringGrid->Cells[1][0] = "Name";
	StringGrid->Cells[0][0]="Key";
	StringGrid->Cells[0][10]="5"; StringGrid->Cells[1][1]="Gleb";
	StringGrid->Cells[0][11]="2"; StringGrid->Cells[1][2]="Kirill";
	StringGrid->Cells[0][12]="4"; StringGrid->Cells[1][3]="Timophey";
	StringGrid->Cells[0][4]="1"; StringGrid->Cells[1][4]="Katya";
	StringGrid->Cells[0][5]="7"; StringGrid->Cells[1][5]="Fedya";
	StringGrid->Cells[0][2]="6"; StringGrid->Cells[1][6]="Nikita";
	StringGrid->Cells[0][1]="8"; StringGrid->Cells[1][7]="Oleg";
	StringGrid->Cells[0][3]="3"; StringGrid->Cells[1][8]="Masha";
	StringGrid->Cells[0][9]="9"; StringGrid->Cells[1][9]="Sasha";
	StringGrid->Cells[0][6]="3"; StringGrid->Cells[1][10]="Mikahil";
	StringGrid->Cells[0][8]="10"; StringGrid->Cells[1][11]="Olya";
	StringGrid->Cells[0][7]="11"; StringGrid->Cells[1][12]="Vera";

	KeyCount = 12;
	for(int i = 1; i < KeyCount; i++)
	{
		tree = tree->Add(tree, StrToInt(StringGrid->Cells[0][i]), StringGrid->Cells[1][i]);
	}
	ViewTree(tree, -1);
}

void __fastcall TForm1::TaskEvent(TObject *Sender)//Task event
{
	ShowMessage(IntToStr(Tree::Task(tree->right)) + " nodes in the right branch of the tree");
}

void __fastcall TForm1::AddClick(TObject *Sender) //If key (position in the Line) is already taken - won't add anything
{
	if(KeyEdit->Text != "" && NameEdit->Text != "")
	{
		Node* node;
		tree = tree->Add(tree, KeyEdit->Text.ToInt(), NameEdit->Text);
		KeyEdit->Text = "";
		NameEdit->Text = "";
		TreeView->Items->Clear();
		ViewTree(tree, -1);
	}
}

void __fastcall TForm1::FindClick(TObject *Sender)
{
	Node* node = tree->Find(tree, KeyEdit->Text.ToInt());
	if (node)
	{
		Memo->Lines->Clear();
		Memo->Lines->Add(IntToStr(node->value) + ") " + node->str);
	}
	else
	{
		Memo->Lines->Clear();
		Memo->Lines->Add("No such person in the Line");
	}
}

void __fastcall TForm1::DeleteClick(TObject *Sender)
{
	if(KeyEdit->Text != "")
	{
		tree = tree->Delete(tree, KeyEdit->Text.ToInt());
		KeyEdit->Text = "";
		NameEdit->Text = "";
		TreeView->Items->Clear();
		ViewTree(tree, -1);
	}
}

void __fastcall TForm1::ShowAsClick(TObject *Sender)
{
	Form1->Memo->Lines->Clear();
	::ShowAs(tree, showtype);
}

void __fastcall TForm1::RadioButton1Click(TObject *Sender)
{
	showtype = 0;
}

void __fastcall TForm1::RadioButton2Click(TObject *Sender)
{
	showtype = 1;
}

void __fastcall TForm1::RadioButton3Click(TObject *Sender)
{
	showtype = 2;
}


void __fastcall TForm1::TaskClick(TObject *Sender)
{
	TaskEvent(Sender);
}

void __fastcall TForm1::BalanceClick(TObject *Sender)
{
	tree->Balance(tree);
    TreeView->Items->Clear();
	ViewTree(tree, -1);
}

