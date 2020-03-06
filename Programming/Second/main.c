

#include <stdio.h>
#include <stdbool.h>
#include <conio.h>
#include <math.h>

char digit(int num)
{
  switch (num) {
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

int ConvertToLower (int n, int base)
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

void ConvertToHigher (int n, int base, char *str)
{
    int sum=0, leng=0, i=0, rest, ch1 = n, chb = ch1;
    float k=0;
    char b;
    char newNum[10];

    while (chb)
    {
        leng++;
        chb/=10;
    }
    for(int i = leng-1 ; i >=0 ; i--)
    {
        sum+= ch1 % 10 * pow(n, k++);
        ch1/=10;
    }
    printf("sum - %d", sum);
    
    do
    {
        rest = n % base;
        newNum[i] = digit(rest);
        i++;
        sum /= base;
    }
    while(sum >= base);
    int j = i + 1;
    while(i + 1)
    {
        str[i] = newNum[i];
        i--;
    }
}

int main()
{ 	
    int n;
    double e;
    bool end = false;
    bool notNull = false;
    char str[10] = "";

    while (!end)
    {
        printf("\n\n\n 1. Enter natural number.\n 2. Output the number in 10, 8 and 16 number systems.\n 3. Output reversed num (decimal number system).\n 4. Transform the num into n-number system [2..16].\n 5. About us.\n 6. Exit.");
        switch (getch())
        {
        case '1':
        {
            notNull = true;
            printf("\n\n\nEnter natural number n: ");
            while (true)
            {
                scanf("%d", &n);
                if (n < 1)
                {
                    printf("\n\n\nThe number should be natural!\nPlease, try again: ");
                }
                else
                {
                    break;
                }
            }
            break;
        }
        case '2':
        {
            if(notNull)
            {
                ConvertToHigher(n, 16, *str);
                printf("\n\n\n%d - decimal\n%d - octal\n%s - hexademical", n, ConvertToLower(n, 8), str);
            }
            else
            {
                printf("\n\n\nYou should Enter the number first!");
            }
            
            break;
        }
        case '3':
        {
            if(notNull)
            {
            printf("\n\n\n%f - reversed decimal number", 1/(float)n);
            }
            else
            {
                printf("\n\n\nYou should Enter the number first!");
            }
            break;
        }
        case '4':
        {
            if(notNull)
            {
                int base;
                printf("\n\n\nEnter number system base: ");
                while (true)
                {
                    scanf("%d", &base);
                    if (base < 2 || base > 16)
                    {
                        printf("\n\n\nThe number should be between 2 and 16!\nPlease, try again: ");
                    }
                    else
                    {
                        break;
                    }
                }
                if(base<11)
                {
                    printf("%d - %d number system form of %d", ConvertToLower(n, base), base, n);
                }
                else
                {
                    ConvertToHigher(n, base, *str);
                    printf("%s - %d number system form of %d", str, base, n);
                }
                
            }
            else
            {
                printf("\n\n\nYou should Enter the number first!");
            }
            break;
        }
        case '5':
        {
           printf("\n\n\nYablonsky Kirill Dmitrievich Corp.\nGroup 953501. Current Version 133.7 LTS");
            break;
        }
        case '6':
        {
            end = true;
            break;
        }
        default:
        {
            break;
        }
        }
    }
}