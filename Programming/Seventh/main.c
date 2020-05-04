#include <stdio.h>
#include <malloc.h>
#include <string.h>
#include <stdbool.h>

struct Card
{
    char name[20];
    char password[20];
    int sum;
}Card;

int isnum(char ch)
{
    /*if ( ch == '0' || ch == '1' || ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '6' || ch == '7' || ch == '8' || ch == '9' )*/
    if (47 < ch && ch < 59)
    return 1;
    return 0;
}

void add(struct Card *bank, struct Card card, int *size, int *cap)
{
    if (*size > *cap)
    {
        realloc(bank, *cap * sizeof(struct Card));
        *cap *= 2;
    }
    bank[*size] = card;
    *size++;
}

void save(struct Card *bank, char path[], int size)
{
    FILE *fout;
    fout = fopen("Input.txt", "w");
    int i = 0;
    for (; i < size; i++)
    {
        fprintf(fout, "%s %s %d", bank[i].name, bank[i].password, bank[i].sum);
        if(i+1 != size)
        {
            fprintf(fout, "\n");
        }
    }
    fclose(fout);
}

void main()
{
    int size = 0, cap = 10, i, num;
    bool logged = false, taken = false;
    struct Card *bank = malloc(cap * sizeof(struct Card));
    struct Card card;
    char ch = 'a';
    char path[] = "Input.txt";
    char login[20], password[20];
    FILE *fin;
    if((fin = fopen(path, "r")) == NULL)
    {
        printf("Error opening file");
    }




    while (ch != EOF)
    {
        for(i = 0; i < 20; i++)
        {
            card.name[i] = '\0';
            card.password[i] = '\0';
        }
        int j = 0;
        ch = fgetc(fin);
        while (ch != ' ')
        {
            card.name[j++] = ch;
            ch = fgetc(fin);
        }
        j = 0;
        ch = fgetc(fin);
        while (ch != ' ')
        {
            card.password[j++] = ch;
            ch = fgetc(fin);
        }
        i++;
        card.sum = 0;
        ch = fgetc(fin);
        /*while(ch != '\n' && ch != EOF)*/
        while (isnum(ch))
        {
            card.sum *= 10;
            card.sum += ch - 48;
            ch = fgetc(fin);
        }
        printf("%s %s %d\n", card.name, card.password, card.sum);
        add(bank, card, &size, &cap);
        size++;
    }
    printf("\nAlready have an account?\n1) Yes\n2) No, I want to register new one\n");
    while (!logged)
        switch(_getch())
        {
            case '1':
            {
                while (!logged)
                {
                    printf("Enter login: ");
                    scanf("%s", &login);
                    for (i = 0; i <= size; i++)
                    {
                        if (!strcmp(login, bank[i].name))
                        {
                            logged = true;
                            num = i;
                        }
                    }
                    if(!logged)
                    {
                        printf("\nLogin is INCORRECT! Please, try again.\n");
                    }
                }
                for (i = 0; i <= size; i++)
                {
                    printf("Enter password: ");
                    scanf("%s", &password);
                    if (!strcmp(password, bank[num].password))
                    {
                        printf("Password is correct! \n\n\tACCESS GRANTED\n\n");
                        break;    
                    }
                    else
                    {
                        if(i == 2)
                        {
                            printf("You've failed to Enter the password correctly for three times in a row. Bye have a god day!");
                            return;
                        }
                        else
                        {
                            printf("Password is INCORRECT! Please, try again. (Attempts left - %d)", 2 - i);
                        }
                    }
                }
                break;
            }
            case '2':
            {
                for(i = 0; i < 20; i++)
                {
                    card.name[i] = '\0';
                    card.password[i] = '\0';
                }
                printf("Enter login: ");
                scanf("%s", &card.name);
                for (i = 0; i <= size; i++)
                {
                    if (!strcmp(card.name, bank[i].name))
                    {
                        taken = true;
                    }
                }
                if (!taken)
                {
                    int sum;
                    printf("Enter password: ");
                    scanf("%s", &card.password);
                    printf("Enter sum: ");
                    scanf("%d", &card.sum);
                    add(bank, card, &size, &cap);
                    num = size;
                    size++;
                    logged = true;
                }
                else
                {
                    printf("\n\nThis name is already taken, you may log in with it\n");
                    return;
                }
                break;
            }
            default:
            {
                break;
            }
        }
    while(true)
    {
        printf("What do you want to do?\n1) Make a money remittance to another account\n2) Show info about your account\nq) Exit and save transfers\n");
        switch(_getch())
        {
            case '1':
            {
                int address, sum;
                char name[20];
                bool exist = false;

                printf("\nPlease, Enter the name of the addressee: ");
                scanf("%s", &name);
                for (i = 0; i <= size; i++)
                {
                    if (!strcmp(name, bank[i].name) && i != num)
                    {
                        exist = true;
                        address = i;
                    }
                }
                if (exist)
                {
                    printf("\nPlease, Enter the sum: ");
                    scanf("%d", &sum);
                    if (sum < 1)
                    {
                        printf("\nSum can not be zero or negative!");
                    }
                    else
                    {
                        if(sum > bank[num].sum)
                        {
                            printf("\nSum can not be greater than one you have on your bank account!");
                        }
                        else
                        {
                            bank[num].sum -= sum;
                            bank[address].sum += sum;
                        }
                    }
                    
                }
                else
                {
                    printf("\nSorry, your input is incorrect: there is no such account in our database.");
                }
                
                break;
            }
            case '2':
            {
                printf("\n\n\nYour login:\t\t%s\nPassword:\t\t%s\nSum on your e-wallet:\t%d\n", bank[num].name,  bank[num].password, bank[num].sum);
                break;
            }
            case 'q':
            {
                printf("\n\n\n\nBye, have a good day!");
                fclose(fin);
                save(bank, path, size);
                return;
                break;
            }
            default:
            {
                break;
            }
        }
    }
    free(bank);
}