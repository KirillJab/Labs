#include <stdio.h>
#include <malloc.h>


typedef struct Node
{
    int value;
    struct Node *left;
    struct Node *right; 
}Node;

typedef struct Tree
{
    int size;
    Node *root;
}Tree;

int addNode(Tree *tree, int value)
{
    Node *newNode = malloc (sizeof(Node));
    newNode->value = value;
    newNode->left = NULL;
    newNode->right = NULL;
    if(tree->root == NULL)
    {
        tree->root = newNode;
    }
    else
    {
        Node *curNode = tree->root;
        while(1)
        {
            if(newNode->value < curNode->value && curNode->left == NULL)
            {
                curNode->left = newNode;
                break;
            }
            if(newNode->value > curNode->value && curNode->right == NULL)
            {
                curNode->right = newNode;
                break;
            }
            if(newNode->value < curNode->value && curNode->left != NULL)
            {
                curNode = curNode->left;
            }
            if(newNode->value > curNode->value && curNode->right != NULL)
            {
                curNode = curNode->right;
            } 
        }
    } 
    return 0;
}

Tree createTree(FILE *fin)
{
    Tree tree  = {0, NULL};
    int cur = 0, i = 0;
    char ch;

    while (ch != EOF)
    {
        while((ch = fgetc(fin)) != EOF)
        {
            if(ch != ' ' && ch != EOF)
            {
                cur *= 10;
                cur += ch - 48;
            }
            else 
            {
                break;
            }
        }
        addNode(&tree, cur);
        tree.size ++;
        cur = 0;
    }
    return tree;
}

void showNode(Node *curNode)
{
    if(curNode == NULL) return;
    printf("%d ", curNode->value);

    showNode(curNode->left);
    showNode(curNode->right);
}

void showTree(Tree *tree)
{
    if(tree->root == NULL) return;
    printf("%d ", tree->root->value);

    showNode(tree->root->left);
    showNode(tree->root->right);
}

int checkNode(Node *curNode)
{
    int n = 0;
    if(curNode == NULL) return 0;
    if(curNode->value%2)
    {
        n = 1;
    }
    return n + checkNode(curNode->left) + checkNode(curNode->right);
}

int countUneven(Tree *tree)
{
    int n = 0;
    if(tree->root == NULL) return 0;
    n += checkNode(tree->root->left) + checkNode(tree->root->right);
    return n;
}

int main()
{
    Tree tree;
    char path[] = "Input.txt";
    int i = 0, cur = 0;
    FILE *fin;

    if((fin = fopen(path, "r")) == NULL)
    {
        printf("Error opening file");
    }

    tree = createTree(fin);
    printf("\nTotal: %d\n", tree.size);
    showTree(&tree);
    printf("\nUneven: %d\n", countUneven(&tree));


    fclose(fin);
    return 0;
}