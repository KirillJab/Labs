

#include <stdio.h>
#include <stdbool.h>
#include <conio.h>
#include "libconv.h"

int main()
{ 	
    int n;
    double e;
    bool end = false;
    bool notNull = false;
    char str[10] = "";

    while (!end)
    {
        printf("\n\n\n 1. Enter natural number.\n 2. Output the number in 10, 8 and 16 number systems.\n 3. Output reversed num (decimal number system).\n 4. Transform the num into n-number system [2..16].\n 5. About us.\n 6. Exit.", str);
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
                ConvertToHigher(0, n, 16, str);
                printf("\n\n\n%d - decimal\n%d - octal\n%s - hexademical", n, ConvertToLower(n, 8), str);
            }
            else
            {
                printf("\n\n\nYou should Enter the number first!");
            }
            StrClear(str);
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
                    ConvertToHigher(0, n, base, str);
                    printf("%s - %d number system form of %d", str, base, n);
                }
                StrClear(str);
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