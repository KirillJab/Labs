//---------------------------------------------------------------------------

#ifndef ToolH
#define ToolH
//---------------------------------------------------------------------------

class Tool
{
	public:
	int available = 0, sold = 0;
	wchar_t* groupName;
	wchar_t* name;
	wchar_t* color;
    wchar_t* string;
	bool delivery = false;
	wchar_t* extract(wchar_t*);
};


#endif