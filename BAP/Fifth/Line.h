//---------------------------------------------------------------------------

#include <string>

using namespace std;

#ifndef LineH
#define LineH
//---------------------------------------------------------------------------

class Line
{
	public:
	Line* Prev;
	Line* Next;
	string Text;
	bool Picked;
	Line (string text)
	{
		Next = NULL;
		Prev = NULL;
		Text = text;
		Picked = false;
	}
	Line(){};
};

#endif
