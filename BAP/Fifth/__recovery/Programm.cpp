

#include <vcl.h>
#pragma hdrstop

#include "Programm.h"
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
struct Line
{
	Line* prev = NULL;;
	Line* next = NULL;;
	string text;
}Line;

struct List
{
	 struct Line* head = NULL;
	 struct Line* tail = NULL;
	 int size = 0;
}List;

void addToList(struct List *list, struct Line *line)
{
	if (list->head == NULL)
	{
	list->head = line;
	}
	line->prev = list->tail;
	list->tail = line;
	list->size++;
}

__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{
	struct Line line1, line2, line3;
	struct List list;
	line1.text = "Hello";
	addToList(&list, &line1);
	line1.text = "World";
	addToList(&list, &line1);
	line1.text = "HEY!!!";

	for (i; i++)ist.size; i++) {

	}
	ListBox1->Items->Add(line1.text.c_str());
}

