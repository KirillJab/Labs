//---------------------------------------------------------------------------
#include <string>

using namespace std;

#ifndef OrderH
#define OrderH
//---------------------------------------------------------------------------

class Order
{
	public:
	bool Overlap;
	Order *Next;
	unsigned int Id;
	string Name;
	string Address;
	string Date;
	Order()
	{
		Next = NULL;
		Overlap = false;
	}
};

#endif
