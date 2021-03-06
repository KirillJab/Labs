//---------------------------------------------------------------------------

#include <string>

using namespace std;

#ifndef ToolH
#define ToolH

//---------------------------------------------------------------------------

class Tool
{
	public:
	int Available = 0;
	int Sold = 0;
	string GroupName;
	string Name;
	string Color;
	bool Delivery = false;
	Tool(int _available, int _sold, string _groupName, string _name, string _color, string _delivery)
	{
		Available = _available;
		Sold = _sold;
		GroupName = _groupName;
		Name = _name;
		Color = _color;
		if(_delivery == "Yes")
		{
			Delivery = true;
		}
		else
		{
			Delivery = false;
        }
	}
	Tool (){}
	void FromString(string);
};


#endif
