#include <stdio.h>

int main()
{
    int a, num, N;

    printf("\n\nEnter a: ");
    {
        scanf("%d", &a);
        if (a < 1 || a > 180)
        {
            printf("The number should be between 1 and 180!\nPlease try again: ");
        }
    } 
    while (a < 1 || a > 180);
    N = a;
    int i = 10;
    for (; a; i++)
    {
        num = (i / 10) % 10;
        a--;
        if (a)
        {
            num = i % 10;
            a--;
        }
    }
    printf("%d number in the sequence is:  %d\n\n\n\n", N, num);
    return 0;
}
