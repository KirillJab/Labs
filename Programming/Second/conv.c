
#include "conv.h"
int ConvertTo (int n, int base)
{
    int num = 0, i = 0, k = 1;
    while (n) //пока а!=0
    {
        num+=n%base*k;
        n/=base;
        k*=10;
    }
    return num;
}