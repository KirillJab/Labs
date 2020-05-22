#include "pch.h"
#include "spherecalc.h"


float _stdcall Area(float rad)
{
	return 4 * M_PI * rad * rad;
}
float _stdcall Volume(float rad)
{
	return 4.0 / 3 * M_PI * pow(rad, 3);
}
float _cdecl AreaAtDistance(float rad, float dist)
{
	if (dist < rad && dist >= 0)
	{
		return (rad * rad - dist * dist ) * M_PI;
	}
	return -1;
}
float _cdecl CubeSide(float rad)
{	
	return pow(Volume(rad), 1.0 / 3);
}