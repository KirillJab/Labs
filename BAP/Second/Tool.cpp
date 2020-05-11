//---------------------------------------------------------------------------

#pragma hdrstop

#include "Tool.h"
#include <algorithm>
#include <iostream>
#include<vector>
#include<sstream>
#include<string>
#include<iterator>
//---------------------------------------------------------------------------
#pragma package(smart_init)

void Tool::FromString(string inp)
{
	string buff;
	int i = 0;

	Available = 0;
	Sold = 0;

	for(; inp[i] != '\t'; i++)
	{
		GroupName += inp[i];
	}
	i++;
	for(; inp[i] != '\t'; i++)
	{
		Name += inp[i];
	}
	i++;
	buff = "";
	for(; inp[i] != '\t'; i++)
	{
		Available *= 10;
		Available += inp[i] - '0';
	}
	i++;
	for(; inp[i] != '\t'; i++)
	{
		Sold *= 10;
		Sold += inp[i] - '0';
	}
	i++;
	for(; inp[i] != '\t'; i++)
	{
		Color += inp[i];
	}
	i++;
	for(; inp[i] != '\0'; i++)
	{
		buff += inp[i];
	}
	if(buff == "Yes")
	{
		Delivery = true;
	}
	else
	{
		Delivery = false;
	}
}


