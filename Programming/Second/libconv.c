
#include <string.h>
#include "libconv.h"


char digit (int n)
{
  switch (n) 
  {
  case 0: return '0';
  case 1: return '1';
  case 2: return '2';
  case 3: return '3';
  case 4: return '4';
  case 5: return '5';
  case 6: return '6';
  case 7: return '7';
  case 8: return '8';
  case 9: return '9';
  case 10: return 'A';
  case 11: return 'B';
  case 12: return 'C';
  case 13: return 'D';
  case 14: return 'E';
  case 15: return 'F';
  }
}

int Reverse (char *str, int leng)
{
    int i = 0;
    for(; i < leng / 2; i++)
    {
        char buff;
        buff = str[leng - i - 1];
        str[leng - i - 1] = str [i];
        str[i] = buff;
    }
    return 0;
}

int StrClear (char *str)
{
    int i = strlen(str) - 1;
    for(; i+1; i--)
    {
        str[i] = '\0';
    }
    return 0;
}

int ConvertToHigher (int k, int n, int base, char *str)
{
    str[k] = digit(n % base);
    if(n / base)
    {
        return ConvertToHigher(k+1, n / base, base, str);
    }
    else
    {
        return Reverse(str, k+1);
    }
    
}

int ConvertToLower (int n, int base)
{
    int num = 0, i = 0, k = 1;
    while (n)
    {
        num+=n%base*k;
        n/=base;
        k*=10;
    }
    return num;
}