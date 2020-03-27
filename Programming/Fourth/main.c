#include "stdio.h"
#include "stdbool.h"
#include "string.h"

int strLen(char str[])
{
    int i = 0;
    while (str[i] != '\0')
    {
        i++;
    }
    return i;
}

int isLetter(int i)
{
    if ((96 < i && i < 123) || (64 < i && i < 91))
        return 1;
    else
        return 0;
}

int isPunct(char ch)
{
    if (ch == '!' || ch == '?' || ch == '!' || ch == '.' || ch == ',' || ch == ')' || ch == '}' || ch == ']' || ch == ';' || ch == ':')
        return 1;
    else
        return 0;
}

int strCmp(char* word1, char* word2)
{
    if (strLen(word1) == strLen(word2) && !isPunct(word1[strLen(word1) - 1]) || (strLen(word2) - 1 == strLen(word1) && isPunct(word2[strLen(word2) - 1])))
    {
        int i = 0;
        if (word1[i] == word2[i] || word1[i] + 32 == word2[i] || word1[i] - 32 == word2[i])
        {
            i++;
        }
        else
        {
            return 1;
        }
        
        for (; i < strLen(word1); i++)
        {
            if (word1[i] != word2[i])
            {
                return 1;
            }
        }
        return 0;
    }
    else
    {
        return 1;
    }
}

void main()
{
    FILE* input;
    char path[] = "Input.txt";
    char str[2000], text[2010], buff[2000], word1[30] = "", word2[30] = "";
    int i = 0, k = 0, turn = 1, j = 0, leng;
    bool check = false;
    
    if ((input = fopen(path, "r")) == NULL)
    {
        printf("\n\nError occured: can't open the file!\n\n");
        return;
    }
    /*
    printf("\n\n%d\n\n", strCmp("abc", "Abc!"));
    */
    fgets(&str, 2000, input);
    printf("\n%s", str);

    while (str[i] != '\0')
    {
        /*Проверка отсутствия пробелов до*/
        if ((str[i + 1] == '!' || str[i + 1] == '?' || str[i + 1] == ',' || str[i + 1] == ';' || str[i + 1] == ':' || str[i + 1] == ']' || str[i + 1] == '}' || str[i + 1] == ')') && str[i] == ' ')
        {
            text[i + k] = str[i];
            k--;
            i++;
        }
        /*Проверка присутствия пробелов до*/
        if ((str[i] == '(' || str[i] == '[' || str[i] == '{') && str[i - 1] != ' ')
        {
            text[i + k] = ' ';
            k++;
        }
        /*Проверка отсутствия пробелов после*/
        if ((str[i - 1] == '(' || str[i - 1] == '[' || str[i - 1] == '{') && str[i] == ' ')
        {
            i++;
            k--;
            text[i + k] = str[i];
        }
        /*Проверка пробелов после*/
        if ((str[i - 1] == '!' || str[i - 1] == '?' || str[i - 1] == ',' || str[i - 1] == ';' || str[i - 1] == ':' || str[i - 1] == ']' || str[i - 1] == '}' || str[i - 1] == ')') && str[i] != ' ')
        {
            text[i + k] = ' ';
            k++;
        }
        /*Проверка пробелов после многоточия*/
        if (str[i - 1] == '.' && str[i] != '.' && str[i] != ' ')
        {
            text[i + k] = ' ';
            k++;
        }
        /*Проверка заглавной буквы после точки и др. знаков*/
        if ((text[i + k - 3] == '.' || text[i + k - 3] == '!' || text[i + k - 3] == '?') && text[i + k - 2] == ' ' && 96 < text[i + k - 1] && text[i + k - 1] < 123)
        {
            text[i + k - 1] -= 32;
        }
        /*Проверка множественных пробелов*/
        if (text[i + k - 2] == ' ' && text[i + k - 1] == ' ')
        {
            text[i + k] = text[i + k + 1];
            k--;
        }
        text[i + k] = str[i];
        i++;
    }
    printf("\n\n");


    i = 0;
    k = 0;
    while (text[i] != '\0')
    {
        bool punct = false;
        while(isLetter(text[i]))
        {
            if(turn % 2)
            {
                word1[j] = text[i];   
                if (isPunct(text[i + 1]) && !punct)
                {
                    punct = true;
                    j++;
                    word1[j] = text[i + 1];
                }
            }     
            else
            {
                word2[j] = text[i];
                if (isPunct(text[i + 1]) && !punct)
                {
                    punct = true;
                    j++;
                    word2[j] = text[i + 1];
                }
            }
            buff[i + k] = text[i];
            i++;
            j++;
            check = true;
        }
        if (check)
        {
            if(turn % 2)
            {
                printf("%s1 ", word1);
                if (!strCmp(word2, word1))
                {
                    k -= j + 1;
                    if(!isPunct(word2[strLen(word2) - 1]) && isPunct(word1[strLen(word1) - 1]))
                    {
                        printf("punct! ");
                        k++;
                    }
                    else
                    {

                    }
                    
                    printf("are SAME1 ");
                }
            }     
            else
            {
                printf("%s2 ", word2);
                if (!strCmp(word1, word2))
                {
                    k -= j + 1;
                    if(!isPunct(word1[strLen(word1) - 1]) && isPunct(word2[strLen(word2) - 1]))
                    {
                        printf("punct! ");
                        k++;
                    }
                    printf("are SAME! ");
                }
            }
            
            while(j + 2)
            {
                if(turn % 2)
                {
                    word2[j + 2] = '\0';
                }     
                else
                {
                    word1[j + 2] = '\0';
                }
                j--;
            }
            turn++;
            j = 0;
        }
        check = false;
        buff[i + k] = text[i];
        i++;
    }
    printf("\n\n\n%s\n%s\n\n", text, buff);
    fclose(input);
}