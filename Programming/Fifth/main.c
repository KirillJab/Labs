#include <stdio.h>
#include <malloc.h>

typedef struct Digit
{
    int value;
    struct Digit *prev;
    struct Digit *next;
} Digit;

typedef struct Numb
{
    int length;
    Digit *head;
    Digit *tail;
} Numb;



int addDigit(Numb *number, int inpDigit)
{
    Digit *curDigit = malloc(sizeof(Digit));

    curDigit->value = inpDigit;
    if(number->head == NULL)
    {
        curDigit->prev = NULL;
        curDigit->next = NULL;
        number->head = curDigit;
        number->tail = curDigit;
    }
    else 
    {
        
        curDigit->prev = number->tail;
        curDigit->next = NULL;
        number->tail->next = curDigit;
        number->tail = curDigit;  
    }
    return 0;
}

Numb createNumber(int inpNum)
{
    Numb number = {0, NULL, NULL};
    int i = 0;

    while (inpNum)
    {
        addDigit(&number, inpNum % 10);
        inpNum /= 10;
        number.length ++;
    }
    return number;
}

int showNumber(Numb *number)
{
    Digit *curDigit = number->tail;

    while(curDigit)
    {
        printf("%d", curDigit->value);
        curDigit = curDigit->prev;
    }
    return 0;
}

long long int convert(Numb *number)
{
    Digit *curDigit = number->tail;
    long long int num = 0;
    int n = 0, k = 1;

    while(curDigit)
    {
        n *= 10;
        n += curDigit->value;
        printf("",n);
        curDigit = curDigit->prev;
    }
    while(n)
    {
        num += n % 2 * k;
        n /= 2;
        k *= 10;
    }
    return num;
}

int main()
{
    int num;
    printf("\nEnter your number: ");
    scanf("%d", &num);
    Numb number = createNumber(num);
    showNumber(&number);
    printf(" is %d in binary ", convert(&number));
    return 0;
}