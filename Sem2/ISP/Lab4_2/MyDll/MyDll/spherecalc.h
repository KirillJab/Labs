#pragma once

#define _USE_MATH_DEFINES

#include <math.h>;


extern "C" __declspec(dllexport) float _stdcall Area(float rad);
extern "C" __declspec(dllexport) float _stdcall Volume(float rad);
extern "C" __declspec(dllexport) float _cdecl AreaAtDistance(float rad, float dist);
extern "C" __declspec(dllexport) float _cdecl CubeSide(float rad);